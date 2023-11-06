using Microsoft.AspNetCore.Mvc;
using Webapi.Models;
using Webapi.IServices;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportDownloadController : ControllerBase
    {
        IFileService _fileService;
        public ReportDownloadController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [Route("DownloadAuditReport")]
        [HttpGet]
        public async Task<ActionResult> DownloadAuditReport(long auditId)
        {
            AuditReportModel auditReport = await _fileService.GetReportValues(auditId);
            FileModel fileModel = _fileService.GetFileDetails();
            await _fileService.GenerateAuditReportPdfFile(auditReport, fileModel);
            byte[] fileBytes = await _fileService.GetGeneratedFile(fileModel.FilePath);
            return File(fileBytes, fileModel.ContentType, fileModel.FileName);
        }
    }
}
