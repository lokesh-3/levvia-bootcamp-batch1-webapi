using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Services.Interface;
using Services.ServicesRepos;

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]

    public class AuditOutcomeMasterController : ControllerBase
    {
        private readonly IAuditOutcomeMasterService _auditOutcomeMasterService;

        public AuditOutcomeMasterController(IAuditOutcomeMasterService auditOutcomeMasterService)
        {
            _auditOutcomeMasterService = auditOutcomeMasterService;
        }


        [HttpGet("GetAllAuditOutcomes")]
        public async Task<ActionResult<IEnumerable<AuditOutcomeMasterDTO>>> GetAllAuditOutcomesMaster()
        {
            try
            {
                var auditOutcomes = await _auditOutcomeMasterService.GetAllAuditOutcomesMaster();
                return Ok(auditOutcomes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
