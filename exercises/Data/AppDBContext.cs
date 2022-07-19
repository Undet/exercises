using Microsoft.EntityFrameworkCore;

namespace exercises.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
        }
        public DbSet<Student> Students { get; set; }

    }
       
}
