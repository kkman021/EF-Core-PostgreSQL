using Microsoft.EntityFrameworkCore;
using ProjectB.Models;

namespace ProjectB.Data
{
    public class ProjectBDbContext : DbContext
    {
        public ProjectBDbContext(DbContextOptions<ProjectBDbContext> options)
            : base(options)
        {
        }

        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<SMSConfig> SMSConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set schema for ProjectB tables (optional but helps distinguish between projects)
            modelBuilder.Entity<MailTemplate>().ToTable("MailTemplates", "ProjectB");
            modelBuilder.Entity<SMSConfig>().ToTable("SMSConfigs", "ProjectB");
        }
    }
}
