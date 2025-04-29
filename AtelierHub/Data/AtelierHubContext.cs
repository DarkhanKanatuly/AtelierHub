using Microsoft.EntityFrameworkCore;
using AtelierHub.Models;

namespace AtelierHub.Data
{
    public class AtelierHubContext : DbContext
    {
        public AtelierHubContext(DbContextOptions<AtelierHubContext> options)
            : base(options)
        {
        }
        public DbSet<Master> Masters { get; set; }
        public DbSet<User> Users { get; set; }
    }
}