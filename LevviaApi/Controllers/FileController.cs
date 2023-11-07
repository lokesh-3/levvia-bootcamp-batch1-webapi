using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            this._fileService = fileService;
        }
        [HttpPost]
        [Route("UploadDocument")]
        public async Task<IActionResult> UploadDocument(IFormFile file, int clientId)
        {
            var response = false;
            if (clientId <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            response = await _fileService.UploadFile(file, clientId);

            if (response == true)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
