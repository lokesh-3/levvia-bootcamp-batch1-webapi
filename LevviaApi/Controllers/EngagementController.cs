using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public EngagementController(IEngagementSevice engagementSevice)
        {
            _engagementSevice = engagementSevice;
            
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

    }
}
