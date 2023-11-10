using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using DTO;
using Microsoft.Identity.Web.Resource;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ReportDownloadController : ControllerBase
    {
        IAuditReportService _auditReportService;
        public ReportDownloadController(IAuditReportService auditReportService)
        {
            _auditReportService = auditReportService;
        }

        
        [HttpGet()]
        public async Task<ActionResult> DownloadAuditReport(long auditId)
        {
            AuditReportDTO auditReport = await _auditReportService.GetReportValues(auditId);
            PdfFileDTO fileModel = _auditReportService.GetFileDetails();
            await _auditReportService.GenerateAuditReportPdfFile(auditReport, fileModel);
            byte[] fileBytes = await _auditReportService.GetGeneratedFile(fileModel.FilePath);
            return File(fileBytes, fileModel.ContentType, fileModel.FileName);
        }
    }
}
