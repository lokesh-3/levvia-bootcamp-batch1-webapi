using DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using Services.ServicesRepos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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


        // GET api/<CommanController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommanController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
