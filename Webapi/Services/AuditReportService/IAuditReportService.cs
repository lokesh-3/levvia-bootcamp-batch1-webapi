using Webapi.Models.DTO;

namespace Webapi.Services.EmailService
{
    public interface IAuditReportService
    {
        Task AuditReport(string pdfPath, string auditType, string clientName, string startDate, string endDate, string auditOutcome, string owerName, string auditor);
    }
}
