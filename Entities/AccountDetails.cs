using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AccountDetails
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public decimal AccountReceivables { get; set; }
        public decimal Cash { get; set; }
        public decimal OtherExpeness { get; set;}
        public decimal Inventory { get; set;}
    }
}
