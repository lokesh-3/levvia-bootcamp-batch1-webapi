using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Services.Interface;
using DTO;

namespace Services.ServicesRepos
{
    public class AuditReportService : IAuditReportService
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

        public async Task GenerateAuditReportPdfFile(AuditReportDTO auditReportDTO, PdfFileDTO pdfFileDTO)
        {
            FileStream fileStream = new FileStream(pdfFileDTO.FilePath, FileMode.Create, FileAccess.Write, FileShare.None);
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
            string firstLine = "This is to certify that we have completed " + auditReportDTO.AuditType + " audit of " + auditReportDTO.ClientName + " for the duration of " + auditReportDTO.StartDate + " and " + auditReportDTO.EndDate + ".";
            string outcome = "\nAs per our audit, the audit outcome is " + auditReportDTO.AuditOutcome + ".";
            string footer = "\n\nEngagement owner:\n " + auditReportDTO.OwerName + "\n\nAuditors : \n";
            foreach (string auditor in auditReportDTO.AuditorList)
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

        public async Task<AuditReportDTO> GetReportValues(long auditId)
        {
            //use auditId to fetch details from database
            AuditReportDTO auditReportDTO = new AuditReportDTO();
            auditReportDTO.AuditType = "{{TestAuditType}}";
            auditReportDTO.ClientName = "{{TestClientName}}";
            auditReportDTO.StartDate = "{{TestStartDate}}";
            auditReportDTO.EndDate = "{{TestEndDate}}";
            auditReportDTO.AuditOutcome = "{{TestAuditOutcome}}";
            auditReportDTO.OwerName = "{{TestOwerName}}";
            auditReportDTO.AuditorList = new List<string>();
            auditReportDTO.AuditorList.Add("{{TestAuditor1}}");
            auditReportDTO.AuditorList.Add("{{TestAuditor2}}");
            auditReportDTO.AuditorList.Add("{{TestAuditor3}}");
            auditReportDTO.AuditorList.Add("{{TestAuditor4}}");
            auditReportDTO.AuditorList.Add("{{TestAuditor5}}");
            return auditReportDTO;

        }

        public PdfFileDTO GetFileDetails()
        {
            PdfFileDTO pdfFileDTO = new PdfFileDTO();
            //Values can be fetched from Appsetting.json OR From Database
            pdfFileDTO.FileName = "AuditReport_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
            pdfFileDTO.FilePath = "D:/" + pdfFileDTO.FileName;
            pdfFileDTO.ContentType = "application/pdf";
            return pdfFileDTO;

        }

    }
}
