using _06_08_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_08_2024.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Titan10\\SQLEXPRESS;Database=DB1;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
