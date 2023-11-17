namespace DTO
{
    public class AccountDetailsDTO
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountRecievable { get; set; }
        public decimal Cash { get; set; }
        public decimal OtherExpenses { get; set; }
        public decimal Inventory {  get; set; }
        public string AuditOutcome { get; set; }
        public int ClientId { get; set; }
    }
}
