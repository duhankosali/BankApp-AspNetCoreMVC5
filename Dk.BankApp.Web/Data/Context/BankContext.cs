using Dk.BankApp.Web.Data.Configurations;
using Dk.BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dk.BankApp.Web.Data.Context
{
    public class BankContext : DbContext // Context sınıfı oluşturmak için DbContext'den kalıtım aldık.
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public BankContext(DbContextOptions<BankContext> options) : base(options) // Buradaki options'un datası "Startup.cs" den geliyor.
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
