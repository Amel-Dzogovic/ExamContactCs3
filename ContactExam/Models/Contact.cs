using System.ComponentModel.DataAnnotations;

namespace ContactExam.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Strasse { get; set; }
    }
}
