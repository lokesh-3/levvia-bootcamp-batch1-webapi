﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("AuditMaster")]
    public class AuditMaster
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string AuditName { get; set; }
        public bool IsActive { get; set; }
    }
}
