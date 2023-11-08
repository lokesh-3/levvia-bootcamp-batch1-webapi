using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountyName { get; set; }
        public bool IsActive { get; set; }

        //public virtual ICollection<Engagement>  Engagements { get;}

    }
}
