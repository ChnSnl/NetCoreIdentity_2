using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreIdentity_2.Models.Entities;

namespace NetCoreIdentity_2.Models.Configuration
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryID);
        }
    }
}
