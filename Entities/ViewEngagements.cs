using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ViewEngagements
    {
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public string EngagementStartDate { get; set; }
        public string EngagementEndDate { get; set; }
        public String AuditName { get; set; }
        public String AuditStatus { get; set; }
    }

    public class CreateEngagements
    {
        public string ClientName { get; set; }
        public int CountryID { get; set; }
        public string EngagementStartDate { get; set; }
        public string EngagementEndDate { get; set; }
        public int AuditType { get; set; }
    }
}
