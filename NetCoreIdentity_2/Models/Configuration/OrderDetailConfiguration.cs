﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreIdentity_2.Models.Entities;

namespace NetCoreIdentity_2.Models.Configuration
{
    public class OrderDetailConfiguration : BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.OrderID,
                x.ProductID
            });
        }
    }
}
