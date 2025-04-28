using Microsoft.EntityFrameworkCore;
using AtelierHub.Models;

namespace AtelierHub.Data
{
    public class AtelierHubContext : DbContext
    {
        public DbSet<Master> Masters { get; set; }

        public AtelierHubContext(DbContextOptions<AtelierHubContext> options)
            : base(options)
        {
        }
    }
}