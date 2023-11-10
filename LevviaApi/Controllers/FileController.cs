using Azure;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Services.Interface;

namespace LevviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            this._fileService = fileService;
        }

        /// <summary>
        /// Upload single file to engagement
        /// </summary>
        /// <param name="file"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UploadSingleDocument")]
        public async Task<IActionResult> UploadSDocument(IFormFile file, int clientId)
        {
            if (clientId <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }

            try
            {
                await _fileService.UploadFile(file, clientId);
                return StatusCode(StatusCodes.Status200OK, true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
        }

        /// <summary>
        /// Upload multiple files to engagement
        /// </summary>
        /// <param name="files"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UploadMultipleDocuments")]
        public async Task<IActionResult> UploadDocument(List<IFormFile> files, int clientId)
        {
            if (clientId <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
            try
            {
                await _fileService.UploadFile(files, clientId);
                return StatusCode(StatusCodes.Status200OK, true);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, false);
            }
        }
    }
}
