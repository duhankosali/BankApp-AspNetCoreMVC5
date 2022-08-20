using Dk.BankApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dk.BankApp.Web.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            //throw new System.NotImplementedException();
            builder.Property(x=>x.Name).HasMaxLength(256);
            builder.Property(x => x.Name).IsRequired(); // ZORUNLU
            builder.Property(x => x.Name).HasMaxLength(256);
            builder.Property(x => x.Name).IsRequired(); // ZORUNLU

            builder.HasMany(x=>x.Accounts).WithOne(x=>x.ApplicationUser).HasForeignKey(x=>x.ApplicationUserId);
            // Accounts'da bulunan ApplicationUserId, ApplicationUser'a bağlanan bir ForeignKey ' dir.
        }
    }
}
