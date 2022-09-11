using SchoolManagement.Models;

namespace SchoolManagement.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
        public int TeacherId { get; set; }
        public IEnumerable <Teacher> teachers { get; set; }

        public string Linker
        {
            get
            {
                return (Id != 0) ? "UpdateStudent" : "SaveStudent";


            }
        }
    }
}
