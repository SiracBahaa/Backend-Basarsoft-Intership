using Microsoft.EntityFrameworkCore;

namespace WebApplication1.cs.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options) 
        {
    
        
        }

        public DbSet<Point> Points { get; set; }

    }
}
