using Inventory.Domain.Interfaces;

namespace Inventory.Domain.Domains.ProductStatuses
{
    public interface IProductStatusRepository : IGenericRepository<ProductStatus>
    {
        ProductStatus AddStatus(string statusName, string statusDescription);
    }
}
