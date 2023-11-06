using Microsoft.AspNetCore.Mvc;
using Webapi.Services.EmailService;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdReportController : ControllerBase
    {

        private readonly IAuditReportService _auditReportService;

        public AdReportController(IAuditReportService auditReportService)
        {
            _auditReportService = auditReportService;
        }

        [HttpGet("TestingAuditReport")]
        public async Task<ActionResult> AdReport()
        {
            string fileName = "AuditReport_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
            string filePath = "D:/" + fileName;
            string auditType = "<AuditType>";
            string clientName = "<ClientName>";
            string startDate = "<StartDate>";
            string endDate = "<EndDate>";
            string auditOutcome = "<AuditOutcome>";
            string owerName = "<OwerName>";
            string auditor = " <Auditor> ";
            _auditReportService.AuditReport(filePath, auditType, clientName, startDate, endDate, auditOutcome, owerName, auditor);
            byte[] fileBytes = GeneratedAuditReport(filePath);
            return File(fileBytes, "application/pdf", fileName);
        }

        private byte[] GeneratedAuditReport(string filePath)    
        {
            byte[] fileBytes = null;
            if (System.IO.File.Exists(filePath))
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    fileBytes = new byte[stream.Length];
                    stream.ReadAsync(fileBytes, 0, fileBytes.Length);
                }
            }
            return fileBytes;
        }
       
    }
}
