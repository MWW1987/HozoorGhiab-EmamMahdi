using Microsoft.EntityFrameworkCore;

namespace HozoorGhiabEmamMahdi.Models
{
    public class HozoorContext : DbContext
    {
        public HozoorContext(DbContextOptions<HozoorContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ostad> Ostads { get; set; }
        public DbSet<Doroos> Dorooses { get; set; }
        public DbSet<Hozoor> Hozoors { get; set; }
        public DbSet<Doroos_User> Doroos_Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doroos_User>().HasKey(k => new { k.DoroosId, k.UserId });
            modelBuilder.Entity<Doroos_User>().HasOne(c => c.User).WithMany(c => c.Doroos_Users).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<Doroos_User>().HasOne(c => c.Doroos).WithMany(c => c.Doroos_Users).HasForeignKey(c => c.DoroosId);
        }

    }
}
