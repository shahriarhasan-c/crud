namespace SchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
