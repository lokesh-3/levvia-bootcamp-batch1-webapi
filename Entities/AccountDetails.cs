using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("AccountDetails")]
    public class AccountDetails
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal AccountRecievable { get; set; }
        public decimal Cash { get; set; }
        public decimal OtherExpenses { get; set; }
        public decimal Inventory { get; set; }
        public int AuditOutcomeId { get; set; }
        public int ClientId { get; set; }
        public int AuditStatus { get; set; }

    }
}
