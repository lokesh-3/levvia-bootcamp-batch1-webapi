using iTextSharp.text.pdf;
using iTextSharp.text;
using Webapi.Models;
using Webapi.IServices;
using System.IO;

namespace Webapi.FileService.Services
{
    public class FileService : IFileService
    {
        public async Task<byte[]> GetGeneratedFile(string FilePath)
        {
            byte[] fileBytes = null;
            if (File.Exists(FilePath))
            {
                using (FileStream stream = new FileStream(FilePath, FileMode.Open))
                {
                    fileBytes = new byte[stream.Length];
                    stream.ReadAsync(fileBytes, 0, fileBytes.Length);
                }
            }
            return fileBytes;
        }

        public async Task GenerateAuditReportPdfFile(AuditReportModel auditReportModel, FileModel fileModel)
        {
            FileStream fileStream = new FileStream(fileModel.FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, fileStream);
            document.Open();
            BaseFont baseFontHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fontHead = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 20, 1, iTextSharp.text.BaseColor.BLACK);
            Paragraph paragraphHeading = new Paragraph();
            paragraphHeading.Alignment = Element.ALIGN_CENTER;

            paragraphHeading.Add(new Chunk("Audit Report \n\n\n\n", fontHead));
            document.Add(paragraphHeading);
            string firstLine = "This is to certify that we have completed " + auditReportModel.AuditType + " audit of " + auditReportModel.ClientName + " for the duration of " + auditReportModel.StartDate + " and " + auditReportModel.EndDate + ".";
            string outcome = "\nAs per our audit, the audit outcome is " + auditReportModel.AuditOutcome + ".";
            string footer = "\n\nEngagement owner:\n " + auditReportModel.OwerName + "\n\nAuditors : \n";
            foreach (string auditor in auditReportModel.AuditorList)
            {
                footer += auditor + "\n";
            }
            footer += "\nThanks,\nThe Bootcamp";

            Font fontPararaph = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, 1, iTextSharp.text.BaseColor.BLACK);
            Paragraph paragraphContents = new Paragraph();
            paragraphContents.Alignment = Element.ALIGN_JUSTIFIED;
            paragraphContents.Add(new Chunk(firstLine, fontPararaph));
            paragraphContents.Add(new Chunk(outcome, fontPararaph));
            paragraphContents.Add(new Chunk(footer, fontPararaph));
            document.Add(paragraphContents);
            document.Close();
            pdfWriter.Close();
            fileStream.Close();
        }

        public async Task<AuditReportModel> GetReportValues(long auditId)
        {
            //use auditId to fetch details from database
            AuditReportModel auditReportModel = new AuditReportModel();
            auditReportModel.AuditType = "{{TestAuditType}}";
            auditReportModel.ClientName = "{{TestClientName}}";
            auditReportModel.StartDate = "{{TestStartDate}}";
            auditReportModel.EndDate = "{{TestEndDate}}";
            auditReportModel.AuditOutcome = "{{TestAuditOutcome}}";
            auditReportModel.OwerName = "{{TestOwerName}}";
            auditReportModel.AuditorList = new List<string>();
            auditReportModel.AuditorList.Add("{{TestAuditor1}}");
            auditReportModel.AuditorList.Add("{{TestAuditor2}}");
            auditReportModel.AuditorList.Add("{{TestAuditor3}}");
            auditReportModel.AuditorList.Add("{{TestAuditor4}}");
            auditReportModel.AuditorList.Add("{{TestAuditor5}}");
            return auditReportModel;

        }

        public FileModel GetFileDetails()
        {
            FileModel fileModel = new FileModel();
            //Values can be fetched from Appsetting.json OR From Database
            fileModel.FileName = "AuditReport_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
            fileModel.FilePath = "D:/" + fileModel.FileName;
            fileModel.ContentType = "application/pdf";
            return fileModel;

        }

    }
}
