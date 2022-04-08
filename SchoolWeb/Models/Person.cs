using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.Models
{
    public class Person
    {
        [Key]
        public int? PersonId { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "Le prénom est obligatoire !")]
        [Display(Name = "Prénom")]
        [Column("Prénom")]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Range(0, 140)]
        public int? Age { get; set; }
    }
}
