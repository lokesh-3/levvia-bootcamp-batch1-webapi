using DTO;
namespace Services.Interface
{
    public interface IAuditReportService
    {
        public Task<byte[]> GetGeneratedFile(string FilePath);
        public Task GenerateAuditReportPdfFile(AuditReportDTO auditReportModel, PdfFileDTO fileModel);
        public Task<AuditReportDTO> GetReportValues(long auditId);
        public PdfFileDTO GetFileDetails();
    }
}
