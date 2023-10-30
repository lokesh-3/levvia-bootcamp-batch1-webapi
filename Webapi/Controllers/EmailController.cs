using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webapi.Managers;
using Webapi.Model;

namespace Webapi.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly MailServiceManager _mailServiceManager;
        public EmailController(MailServiceManager mailServiceManager) 
        { 
            _mailServiceManager = mailServiceManager;
        }

        [HttpPost("MailSend")]
        public async Task<IActionResult> MailSend([FromForm] MailRequest request)
        {
            try
            {
                await _mailServiceManager.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
