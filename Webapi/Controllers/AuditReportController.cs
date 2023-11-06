using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditReportController : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult> AuditReport()
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
            GeneratePdfFile(filePath, auditType, clientName, startDate, endDate, auditOutcome, owerName, auditor);
            byte[] fileBytes = GetGeneratedFile(filePath);
            return File(fileBytes, "application/pdf", fileName);
        }
        private byte[] GetGeneratedFile(string filePath)
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

        private void GeneratePdfFile(string pdfPath, string auditType, string clientName, string startDate, string endDate, string auditOutcome, string owerName, string auditor)
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
        }
    }
}
