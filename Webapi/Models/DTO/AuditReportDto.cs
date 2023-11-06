namespace Webapi.Models.DTO
{
    public class AuditReportDto
    {
        public string fileName = "AuditReport_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
        //public string filePath = "D:/" + fileName;
        public string auditType = "<AuditType>";
        public string clientName = "<ClientName>";
        public string startDate = "<StartDate>";
        public string endDate = "<EndDate>";
        public string auditOutcome = "<AuditOutcome>";
        public string owerName = "<OwerName>";
        public string auditor = " <Auditor> ";
    }
}
