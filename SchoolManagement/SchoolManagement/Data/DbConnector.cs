using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class DbConnector : DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QOTO3EH; Database=SclManagement; Integrated Security=True;");
        }

    }
}
