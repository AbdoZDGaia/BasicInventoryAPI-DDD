using Inventory.Domain.Interfaces;

namespace Inventory.Domain.Domains.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product AddProduct(string productName, string barcode, string description, decimal weight, int statusId);
        int GetCountOfSoldProducts();
        int GetCountOfDamagedProducts();
        int GetCountOfInStockProducts();
        Product ChangeProductStatus(int productId, int statusId);
        Product SellProduct(int productId);
    }
}
