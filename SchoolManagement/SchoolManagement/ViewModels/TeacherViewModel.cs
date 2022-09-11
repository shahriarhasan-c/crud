namespace SchoolManagement.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Subject { get; set; }

        public string Linker
        {
            get
            {
                return (Id != 0) ? "UpdateTeacher" : "SaveTeacher";


            }
        }
    }
}
