using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class Person
    {
        public int? PersonId { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Le prénom est obligatoire !")]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Range(0, 140)]
        public int? Age { get; set; }
    }
}
