using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aurum.Domain.Entity.Product;
using System.Reflection.Emit;

namespace Aurum.Infra.Map {
    public class ProductMap : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.ToTable("TB_PRODUCT");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(300);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Category).IsRequired();

        }
    }
}
