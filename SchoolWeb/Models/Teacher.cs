using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.Models
{
    public class Teacher : Person
    {
        public string? Discipline { get; set; }

        [DisplayName("Date d'embauche")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime HiringDate { get; set; }

        //[ForeignKey]
        public int ClassroomId { get; set; }
        public Classroom? Classroom { get; set; }
    }
}
