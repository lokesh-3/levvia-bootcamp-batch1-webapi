using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly IAccountDetailsService _accountDetailsService;
        public AccountDetailsController(IAccountDetailsService accountDetails)
        { 
             _accountDetailsService = accountDetails;
        }

        [HttpGet("AccountDetails")]
        public async Task<ActionResult> GetAccount(int id)
        {
            try
            {
                var accountDetails = await _accountDetailsService.GetAccountDetails(id);
                return Ok(accountDetails);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
