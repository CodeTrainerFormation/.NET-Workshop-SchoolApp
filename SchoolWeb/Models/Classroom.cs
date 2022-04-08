using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.Models
{
    [Table("Classroom")]
    public class Classroom
    {
        [Key]
        public int ClassroomId { get; set; }
        public string? Name { get; set; }
        public int Floor { get; set; }
        public string? Corridor { get; set; }

        public Teacher? Teacher { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}
