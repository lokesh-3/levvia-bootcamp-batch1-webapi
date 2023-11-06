using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Webapi.Services.EmailService
{
    public class AuditReportService : IAuditReportService
    {
        private readonly IConfiguration _config;

        public AuditReportService(IConfiguration config)
        {
            _config = config;
        }

        public Task AuditReport(string pdfPath, string auditType, string clientName, string startDate, string endDate, string auditOutcome, string owerName, string auditor)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            FileStream fileStream = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter pdfWriter = PdfWriter.GetInstance(document, fileStream);
            document.Open();
            BaseFont baseFontHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fontHead = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16, 1, iTextSharp.text.BaseColor.BLACK);
            Paragraph paragraphHeading = new Paragraph();
            paragraphHeading.Alignment = Element.ALIGN_CENTER;
            paragraphHeading.Add(new Chunk("Audit Report \n\n", fontHead));
            document.Add(paragraphHeading);
            string firstLine = "This is to certify that we have completed " + auditType + " audit of " + clientName + " for the duration of " + startDate + " and " + endDate + ".";
            string outcome = "\nAs per our audit, the audit outcome is " + auditOutcome + ".";
            string footer = "\n\nEngagement owner:\n " + owerName + "\n\nAuditors : \n" + auditor + "\n\nThanks,\nThe Bootcamp";
            Font fontPararaph = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, 1, iTextSharp.text.BaseColor.GRAY);
            Paragraph paragraphContents = new Paragraph();
            paragraphContents.Alignment = Element.ALIGN_JUSTIFIED;
            paragraphContents.Add(new Chunk(firstLine, fontPararaph));
            paragraphContents.Add(new Chunk(outcome, fontPararaph));
            paragraphContents.Add(new Chunk(footer, fontPararaph));
            document.Add(paragraphContents);
            document.Close();
            pdfWriter.Close();
            fileStream.Close();
            return Task.CompletedTask;
        }
    }
}
