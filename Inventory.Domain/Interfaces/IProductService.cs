using Inventory.Shared.DataTransferObjects;

namespace Inventory.Domain.Interfaces
{
    public interface IProductService
    {
        ProductDto AddProduct(ProductForCreationDto productDto);
        ProductDto ChangeProductStatus(int productId, int statusId);
        ProductDto GetProduct(int id);
        ProductCountsDto GetProductCounts();
        ProductDto SellProduct(int productId);
    }
}