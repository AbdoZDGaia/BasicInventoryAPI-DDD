
using Inventory.Domain.Domains.Products;

namespace Inventory.Domain.Specification
{
    public class ProductByStatusSpecification : BaseSpecifcation<Product>
    {
        public ProductByStatusSpecification()
        {
            AddOrderByDescending(x => x.ProductStatus.StatusName);
        }
    }
}