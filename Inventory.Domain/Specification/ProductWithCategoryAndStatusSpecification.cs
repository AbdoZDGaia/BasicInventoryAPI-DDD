using Inventory.Domain.Domains.Products;
using Inventory.Domain.Enums;

namespace Inventory.Domain.Specification
{
    public class ProductWithCategoryAndStatusSpecification : BaseSpecifcation<Product>
    {
        public ProductWithCategoryAndStatusSpecification() : base()
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.ProductStatus);
        }
    }

    public static class ProductWithCategoryAndStatusSpecificationExtension
    {
        public static IQueryable<Product> GetSoldProducts(this IQueryable<Product> query)
        {
            return query.Where(new ProductWithCategoryAndStatusSpecification() { Criteria = x => x.ProductStatus.StatusName == ProductStatusEnum.Sold.ToString() });
        }

        public static IQueryable<Product> GetInStockProducts(this IQueryable<Product> query)
        {
            return query.Where(new ProductWithCategoryAndStatusSpecification() { Criteria = x => x.ProductStatus.StatusName == ProductStatusEnum.InStock.ToString() });
        }

        public static IQueryable<Product> GetDamagedroducts(this IQueryable<Product> query)
        {
            return query.Where(new ProductWithCategoryAndStatusSpecification() { Criteria = x => x.ProductStatus.StatusName == ProductStatusEnum.InStock.ToString() });
        }
    }
}