using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> product)
        {
            product.Property(p => p.Name).IsRequired().HasMaxLength(100);
            product.Property(p => p.Price).HasColumnType("decimal(18,2)");
            product.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
            product.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId);
        }
    }
}