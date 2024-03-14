using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreIdentity_2.Models.Entities;

namespace NetCoreIdentity_2.Models.Configuration
{
    public class AppUserProfileConfiguration : BaseConfiguration<AppUserProfile>
    {
        public override void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            base.Configure(builder);
        }
    }
}
