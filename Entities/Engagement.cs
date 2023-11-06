using System.ComponentModel.DataAnnotations;

namespace Entities
{

    public class Engagement
    {
        [Key]
        public int ClientId { get; set; }
        public string ClinetName { get; set; }

    }
}