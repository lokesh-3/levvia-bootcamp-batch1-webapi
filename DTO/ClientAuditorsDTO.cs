
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientAuditorsDTO
    {
        public int Id {  get; set; }
        public int ClientId {  get; set; }
        public int AuditorId { get; set; }
    }
}