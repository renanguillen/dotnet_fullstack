using Microsoft.EntityFrameworkCore;
using DotnetFullstack.Domain.Entities;

namespace DotnetFullstack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Professor> Professors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>()
                .Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Professor>()
                .Property(p => p.Biography)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
