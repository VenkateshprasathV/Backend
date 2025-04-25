using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Student> StudentDatabase { get; set; } //db name in sql server
    }   
}
