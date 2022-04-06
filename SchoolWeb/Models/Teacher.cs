using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.Models
{
    public class Teacher : Person
    {
        public string? Discipline { get; set; }

        [DisplayName("Date d'embauche")]
        [DisplayFormat(DataFormatString = "dd/MM/yy", ApplyFormatInEditMode = true)]
        public DateTime HiringDate { get; set; }

        public Classroom? Classroom { get; set; }
    }
}
