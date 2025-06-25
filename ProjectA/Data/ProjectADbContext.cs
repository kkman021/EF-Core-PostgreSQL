using Microsoft.EntityFrameworkCore;
using ProjectA.Models;

namespace ProjectA.Data
{
    public class ProjectADbContext : DbContext
    {
        public ProjectADbContext(DbContextOptions<ProjectADbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<TokenManager> TokenManagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<TokenManager>()
                .HasOne(t => t.Client)
                .WithMany()
                .HasForeignKey(t => t.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Set schema for ProjectA tables (optional but helps distinguish between projects)
            modelBuilder.Entity<Client>().ToTable("Clients", "ProjectA");
            modelBuilder.Entity<TokenManager>().ToTable("TokenManagers", "ProjectA");
        }
    }
}
