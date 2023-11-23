using DataBase;
using DTO;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EngagementController : ControllerBase
    {
        private readonly IEngagementSevice  _engagementSevice;
        private readonly ApplicationContext _context;
        public EngagementController(IEngagementSevice engagementSevice , ApplicationContext context)
        {
            _engagementSevice = engagementSevice;
            _context = context;

        }

        // GET: api/<EngagementController>
        [HttpGet("GetAll")]
       // [Authorize(Roles = "EngagmentOwner")]
        public async Task<ActionResult<IEnumerable<EngagementDTO>>> GetAllengagement()
        {
            try
            {
                var engagementDTOs = await _engagementSevice.GetAllEngagements();
                return Ok(engagementDTOs);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error while retrieving user skills.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetEngagementById")]
        //[Authorize(Roles = "EngagmentOwner")]
        public async Task<ActionResult<EngagementDTO>> GetEngagementById(int id)
        {
            try
            {
                var engagementDTOs = await _engagementSevice.GetEngagementById(id);
                return Ok(engagementDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddEngagement")]
       // [Authorize(Roles = "EngagmentOwner")]
        public async Task<ActionResult> AddEngagement([FromBody] EngagementDTO  engagementDTO)
        {
            try
            {
                var remainingMentees = await _engagementSevice.AddEngagement(engagementDTO);
                return Ok(remainingMentees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching remaining mentees.");
            }
        }

        [HttpPut("UpdateEngagement")]
        // [Authorize(Roles = "EngagmentOwner")]
        public async Task<ActionResult> UpdateEngagement([FromBody] EngagementDTO engagementDTO)
        {
            try
            {
                var remainingMentees = await _engagementSevice.UpdateEngagement(engagementDTO);
                return Ok(remainingMentees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching remaining mentees.");
            }
        }

        [HttpGet("ViewEngagements")]
        public IActionResult GetEngagements()
        {
            var engagements = _context.ViewEngagements.FromSqlRaw("EXEC GetViewEngagements").ToList();
           
            return Ok(engagements);
            
        }

        [HttpPost("CreateEngagementBySP")]
        public IActionResult CallStoredProcedureWithParams(CreateEngagements obj)
        {
            //var eng = obj as Engagement;
            var clientName = new SqlParameter("@clientName", obj.ClientName);
            var engagementStartDate = new SqlParameter("@engagementStartDate", obj.EngagementStartDate);
            var engagementEndDate = new SqlParameter("@engagementEndDate", obj.EngagementEndDate);
            var countyId = new SqlParameter("@countyId", obj.CountryID);
            var auditType = new SqlParameter("@audittype", obj.AuditType);
            var result = _context.Database.ExecuteSqlRaw("EXEC CreateEngagement @clientName, @engagementStartDate, @engagementEndDate, @countyId, @audittype",
                                        clientName, engagementStartDate, engagementEndDate, countyId, auditType);

            return Ok(result);
        }
    }
}
