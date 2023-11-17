using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("ClientAuditors")]
    public class ClientAuditors
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int AuditorId { get; set; }

    }
}