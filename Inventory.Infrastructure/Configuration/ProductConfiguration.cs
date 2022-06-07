using Inventory.Domain.Domains.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product("Product 1", "Barcode 1", "Description 1", 4.1m, 1)
                {
                    Id = 1,
                    ProductStatusId = 1,
                    CategoryId = 1,
                    Barcode = "Barcode 1",
                    Description = "Description 1",
                    ProductName = "Product 1",
                    Weight = 4.1m,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new Product("Product 2", "Barcode 2", "Description 2", 4.2m, 2)
                {
                    Id = 2,
                    ProductStatusId = 2,
                    CategoryId = 2,
                    Barcode = "Barcode 2",
                    Description = "Description 2",
                    ProductName = "Product 2",
                    Weight = 4.2m,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new Product("Product 3", "Barcode 3", "Description 3", 4.3m, 3)
                {
                    Id = 3,
                    ProductStatusId = 3,
                    CategoryId = 3,
                    Barcode = "Barcode 3",
                    Description = "Description 3",
                    ProductName = "Product 3",
                    Weight = 4.3m,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new Product("Product 4", "Barcode 4", "Description 4", 4.4m, 3)
                {
                    Id = 4,
                    ProductStatusId = 3,
                    CategoryId = 3,
                    Barcode = "Barcode 4",
                    Description = "Description 4",
                    ProductName = "Product 4",
                    Weight = 4.4m,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new Product("Product 5", "Barcode 5", "Description 5", 4.5m, 2)
                {
                    Id = 5,
                    ProductStatusId = 2,
                    CategoryId = 2,
                    Barcode = "Barcode 5",
                    Description = "Description 5",
                    ProductName = "Product 5",
                    Weight = 4.5m,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new Product("Product 6", "Barcode 6", "Description 6", 4.6m, 2)
                {
                    Id = 6,
                    ProductStatusId = 2,
                    CategoryId = 2,
                    Barcode = "Barcode 6",
                    Description = "Description 6",
                    ProductName = "Product 6",
                    Weight = 4.6m,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new Product("Product 7", "Barcode 7", "Description 7", 4.7m, 1)
                {
                    Id = 7,
                    ProductStatusId = 1,
                    CategoryId = 1,
                    Barcode = "Barcode 7",
                    Description = "Description 7",
                    ProductName = "Product 7",
                    Weight = 4.7m,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new Product("Product 8", "Barcode 8", "Description 8", 4.8m, 1)
                {
                    Id = 8,
                    ProductStatusId = 1,
                    CategoryId = 1,
                    Barcode = "Barcode 8",
                    Description = "Description 8",
                    ProductName = "Product 8",
                    Weight = 4.8m,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                },
                new Product("Product 9", "Barcode 9", "Description 9", 4.9m, 1)
                {
                    Id = 9,
                    ProductStatusId = 1,
                    CategoryId = 1,
                    Barcode = "Barcode 9",
                    Description = "Description 9",
                    ProductName = "Product 9",
                    Weight = 4.9m,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                });
        }
    }
}
