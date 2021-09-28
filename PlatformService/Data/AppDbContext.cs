using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        // relates to our model
        // telling DbContext to mediate or mirror
        // our internal model down to the database
        public DbSet<Platform> Platforms { get; set; }
    }
}