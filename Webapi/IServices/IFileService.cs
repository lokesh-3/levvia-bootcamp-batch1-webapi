using System.IO;
using Webapi.Models;

namespace Webapi.IServices
{
    public interface IFileService
    {
        public Task<byte[]> GetGeneratedFile(string FilePath);
        public Task GenerateAuditReportPdfFile(AuditReportModel auditReportModel,FileModel fileModel);
        public Task<AuditReportModel> GetReportValues(long auditId);
        public FileModel GetFileDetails();
    }
}
