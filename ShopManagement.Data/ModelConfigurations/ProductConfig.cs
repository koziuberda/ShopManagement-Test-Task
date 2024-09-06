using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Core.Enums;
using ShopManagement.Data.Models;

namespace ShopManagement.Data.ModelConfigurations;

public class ProductConfig : IEntityTypeConfiguration<ProductDb>
{
    public void Configure(EntityTypeBuilder<ProductDb> builder)
    {
        builder
            .Property(p => p.Category)
            .HasConversion(
                v => v.ToString(),
                v => (ProductCategory)Enum.Parse(typeof(ProductCategory), v));
    }
}