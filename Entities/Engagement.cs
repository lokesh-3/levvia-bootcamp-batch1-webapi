using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Engagement")]
    public class Engagement
    {
        [Key]
        public int ClientId { get; set; }
        public string ClinetName { get; set; }
        [ForeignKey("Country")]
        public int CountyId { get; set; }
        //public virtual Country Country { get; set; }


    }
}