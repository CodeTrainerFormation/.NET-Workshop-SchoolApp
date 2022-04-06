namespace SchoolWeb.Models
{
    public class Student : Person
    {
        public double Average { get; set; }
        public bool IsClassDelegate { get; set; }

        public Classroom? Classroom { get; set; }
    }
}
