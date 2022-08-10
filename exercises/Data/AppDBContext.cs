using exercises.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace exercises.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
        }
        public DbSet<EntryPass> EntryPass { get; set; } //One to one
        public DbSet<University> University { get; set; }    // One to many
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Course { get; set; }   //Many to many
        public DbSet<Role> Roles { get; set; }

    }
       
}
