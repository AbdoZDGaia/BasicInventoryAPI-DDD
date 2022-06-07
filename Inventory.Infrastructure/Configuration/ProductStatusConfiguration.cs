using Inventory.Domain.Domains.ProductStatuses;
using Inventory.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configuration
{
    public class ProductStatusConfiguration : IEntityTypeConfiguration<ProductStatus>
    {
        public void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            builder.HasData(
                new ProductStatus(ProductStatusEnum.Sold.ToString()) { Id = 1, StatusName = ProductStatusEnum.Sold.ToString() },
                new ProductStatus(ProductStatusEnum.InStock.ToString()) { Id = 2, StatusName = ProductStatusEnum.InStock.ToString() },
                new ProductStatus(ProductStatusEnum.Damaged.ToString()) { Id = 3, StatusName = ProductStatusEnum.Damaged.ToString() }
                );
        }
    }
}
