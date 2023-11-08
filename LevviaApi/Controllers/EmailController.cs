﻿using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost("Notification")]
        public IActionResult SendMail(EmailDto dtoRequest)
        {
            _emailService.SendEmail(dtoRequest);
            return Ok();
        }
    }
}
