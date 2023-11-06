using DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngagementController : ControllerBase
    {
        private readonly IEngagementSevice  _engagementSevice;
        public EngagementController(IEngagementSevice engagementSevice)
        {
            _engagementSevice = engagementSevice;
            
        }
        // GET: api/<EngagementController>
        [HttpGet("GetAll")]
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


        // GET api/<EngagementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EngagementController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EngagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EngagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
