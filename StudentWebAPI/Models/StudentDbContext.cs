using Microsoft.EntityFrameworkCore;

namespace StudentWebAPI.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; initial Catalog = lbs; User Id:ylmgrbz; password =ylmgrbz; TrustServerCertificate= True");
        }
    }
}
