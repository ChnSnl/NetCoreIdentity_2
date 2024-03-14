using NetCoreIdentity_2.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetCoreIdentity_2.Models.Configuration
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> Builder)
        { 
        base.Configure(Builder);

            Builder.Ignore(x => x.ID);

            Builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId).IsRequired();
            Builder.HasMany(x => x.Orders).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserID);
            Builder.HasOne(x => x.Profile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.ID);
        
        }
    }
}
