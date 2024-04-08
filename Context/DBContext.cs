using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace _4458_midterm.Context
{
    public class DBContext : DbContext
    {
        private readonly IConfiguration config;

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            
        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Bank> Bank { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.id);
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.id);
            });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
