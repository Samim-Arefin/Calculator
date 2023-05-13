using Microsoft.EntityFrameworkCore;

namespace CalculatorAPI.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalculatorConfiguration());
        }

        public virtual DbSet<Calculator> Calculator { get; set; }
    }
}
