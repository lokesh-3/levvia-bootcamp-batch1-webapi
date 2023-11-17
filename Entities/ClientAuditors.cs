using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
