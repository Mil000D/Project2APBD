using System.ComponentModel.DataAnnotations;

namespace Zadanie3.Models
{
    public record Student
    {
        [Required]
        public string Index { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string MothersName { get; set; }
        [Required]
        public string FathersName { get; set; }
        [Required]
        public StudiesRecord Studies { get; set; }
       
    }
    
}