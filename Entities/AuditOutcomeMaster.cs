using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("AuditOutcomeMaster")]
    public class AuditOutcomeMaster
    {
            [Key]
            public int Id { get; set; }
            public string AuditOutcome { get; set; }
    }
}