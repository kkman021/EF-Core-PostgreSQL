using Microsoft.EntityFrameworkCore;
using ProjectA.Models;

namespace ProjectA.Data
{
    public class ProjectADbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ProjectADbContext(DbContextOptions<ProjectADbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<TokenManager> TokenManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 直接從 Configuration 讀取 CustomSchemaName
            var customSchemaName = _configuration["CustomSchemaName"];
            if(!string.IsNullOrWhiteSpace(customSchemaName))
            {
                modelBuilder.HasDefaultSchema(customSchemaName);
            }

            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<TokenManager>()
                .HasOne(t => t.Client)
                .WithMany()
                .HasForeignKey(t => t.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Set table names (schema will be applied by HasDefaultSchema)
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<TokenManager>().ToTable("TokenManagers");
        }
    }
}
