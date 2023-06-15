using System.ComponentModel.DataAnnotations;

namespace Zadanie3.Models
{

    public record StudiesRecord
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mode { get; set; }
    }
        
}
