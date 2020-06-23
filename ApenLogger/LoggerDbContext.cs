using Apen.Entity;
using Microsoft.EntityFrameworkCore;

namespace Apen
{
    public class LoggerDbContext : DbContext
    {
        public LoggerDbContext()
        {

        }

        public LoggerDbContext(DbContextOptions<LoggerDbContext> options)
            : base(options)
        {
        }

        // public LoggerDbContext(DbContextOptions options)
        //     : base(options)
        // {
        // }

        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<ItemVersion> ItemVersions { get; set; }
    }
}