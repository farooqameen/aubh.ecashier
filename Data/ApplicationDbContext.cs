using eCashier.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCashier.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<eCashier.Models.Category> Categories { get; set; }
        public DbSet<eCashier.Models.Customer> Customers { get; set; }
        public DbSet<eCashier.Models.Item> Items { get; set; }
        public DbSet<eCashier.Models.Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Orders)
                .WithMany(e => e.Items)
                .UsingEntity<ItemOrder>(j => j.Property(e => e.CreatedOn).HasDefaultValueSql("GETUTCDATE()"));
        }

    }
}
