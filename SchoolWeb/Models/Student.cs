using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.Models
{
    [Table("Student")]
    public class Student : Person
    {
        public double Average { get; set; }
        public bool IsClassDelegate { get; set; }

        public Classroom? Classroom { get; set; }
    }
}
