using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Attachment")]
    public class Attachment
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public byte[] FileContent { get; set; }
        public int ClientId { get; set; }
    }
}
