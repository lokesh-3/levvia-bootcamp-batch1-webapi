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
    public class CommanController : ControllerBase
    {
        private readonly ICommanService _commanSevice;

        public CommanController(ICommanService commanSevice)
        {
            _commanSevice = commanSevice;
        }

        // GET: api/<EngagementController>
        [HttpGet("GetAllCountry")]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetAllCountry()
        {
            try
            {
                var engagementDTOs = await _commanSevice.GetAllCountry();
                return Ok(engagementDTOs);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error while retrieving user skills.");
                return StatusCode(500, "Internal server error");
            }
        }


       
    }
}
