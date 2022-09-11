using exercises.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace exercises.Data
{
    public class AppDBContext : IdentityDbContext<Student>
    {
        public DbSet<EntryPass> EntryPass { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Course { get; set; }
        public AppDBContext(DbContextOptions options) : base(options) 
        {
        }


    }
       
}
