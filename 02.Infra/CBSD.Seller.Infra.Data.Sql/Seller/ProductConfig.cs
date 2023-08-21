﻿using CBSD.Seller.Core.Domain.Entities;
using CBSD.Seller.Core.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CBSD.Seller.Infra.Data.Sql.Seller
{

    public class ProductConfig : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.Property(c => c. Name).HasConversion(c => c.Value, d =>  ProductName.Create(d));
              //  builder.OwnsOne(c => c. );
            }
        }
    }
 