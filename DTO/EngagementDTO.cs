using Microsoft.AspNetCore.Http;

namespace DTO
{
    public class EngagementDTO
    {
        public int ClientId { get; set; }
        public int CountyId { get; set; }
        public string ClientName { get; set; }
        public string EngagementStartDate { get; set; }
        public string EngagementEndDate { get; set; }

        public List<int> Auditorids { get; set; }
        public int Audittype { get; set; }

        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountRecievable { get; set; }
        public decimal Cash { get; set; }
        public decimal OtherExpenses { get; set; }
        public decimal Inventory { get; set; }
        public int AuditOutcomeId { get; set; }

        public int AuditStatus { get; set; }
        //public IFormFile Attachment { get; set; }
    }
}