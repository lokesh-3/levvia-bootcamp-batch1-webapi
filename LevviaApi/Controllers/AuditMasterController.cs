using DataBase.Interface;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Services.Interface;
using Services.ServicesRepos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class AuditMasterController : ControllerBase
    {
        private readonly IAudtiMasterService _audtiMasterService;
        public AuditMasterController(IAudtiMasterService audtiMasterService)
        {
            _audtiMasterService = audtiMasterService;
        }
        // GET: api/<AuditMasterController>
        [HttpGet("GetAllAudits")]
        public async Task<ActionResult<IEnumerable<AuditMasterDTO>>> GetAllAudits()
        {
            try
            {
                var  auditMaster = await _audtiMasterService.GetAuditMaster();
                return Ok(auditMaster);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error while retrieving user skills.");
                return StatusCode(500, "Internal server error");
            }
        }
       
    }
}
