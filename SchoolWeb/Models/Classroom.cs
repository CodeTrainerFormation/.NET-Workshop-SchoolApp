namespace SchoolWeb.Models
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        public string? Name { get; set; }
        public int Floor { get; set; }
        public string? Corridor { get; set; }

        public Teacher? Teacher { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}
