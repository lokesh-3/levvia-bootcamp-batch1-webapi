using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Engagement")]
    public class Engagement
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        [ForeignKey("Country")]

        public int CountyId { get; set; }
        public string EngagementStartDate { get; set; }
        public string EngagementEndDate { get; set; }
        //public virtual Country Country { get; set; }
        public int AuditType { get; set; }

    }
}