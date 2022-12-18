using Microsoft.EntityFrameworkCore;

namespace TallyAssignment_4.Models
{
    public class StudentDbContext : DbContext

    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> subjects { get; set; }
    }
}
