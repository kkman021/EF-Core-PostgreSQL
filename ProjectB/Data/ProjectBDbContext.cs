using Microsoft.EntityFrameworkCore;
using ProjectB.Models;

namespace ProjectB.Data
{
    public class ProjectBDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ProjectBDbContext(DbContextOptions<ProjectBDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<SMSConfig> SMSConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 直接從 Configuration 讀取 CustomSchemaName
            var customSchemaName = _configuration["CustomSchemaName"];
            if(!string.IsNullOrWhiteSpace(customSchemaName))
            {
                modelBuilder.HasDefaultSchema(customSchemaName);
            }

            base.OnModelCreating(modelBuilder);

            // Set table names (schema will be applied by HasDefaultSchema)
            modelBuilder.Entity<MailTemplate>().ToTable("MailTemplates");
            modelBuilder.Entity<SMSConfig>().ToTable("SMSConfigs");
        }
    }
}
