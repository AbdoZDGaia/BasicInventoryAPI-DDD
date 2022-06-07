using Inventory.Domain.Domains.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category("Category 1")
            {
                Id = 1,
                CategoryName = "Category 1"
            },
            new Category("Category 2")
            {
                Id = 2,
                CategoryName = "Category 2"
            },
            new Category("Category 3")
            {
                Id = 3,
                CategoryName = "Category 3"
            });
        }
    }
}
