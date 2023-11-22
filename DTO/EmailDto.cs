using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmailDto
    {
        [Required]
        //[EmailAddress]
        public string[] To { get; set; }
        //public string Subject { get; set; } = string.Empty;
        //public string Body { get; set; } = string.Empty;
    }
}
