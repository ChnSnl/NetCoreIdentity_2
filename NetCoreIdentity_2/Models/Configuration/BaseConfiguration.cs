using Microsoft.EntityFrameworkCore;
using NetCoreIdentity_2.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetCoreIdentity_2.Models.Configuration
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnName("Yaratılma Tarihi");
        }
    }
}
