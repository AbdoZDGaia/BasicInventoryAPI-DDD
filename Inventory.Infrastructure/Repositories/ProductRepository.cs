using Inventory.Domain.Domains.Products;
using Inventory.Domain.Enums;
using Inventory.Domain.Interfaces;
using Inventory.Domain.Specification;

namespace Inventory.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ILoggerManager _logger;

        public ProductRepository(DbFactory dbFactory, ILoggerManager logger) : base(dbFactory)
        {
            _logger = logger;
        }

        public Product AddProduct(string productName, string barcode, string description, decimal weight, int statusId)
        {
            try
            {
                var product = new Product(productName, barcode, description, weight, statusId);
                if (product.ValidOnAdd())
                {
                    Create(product);
                    _logger.LogInfo($"Product {product.ProductName} added successfully.");
                    return product;
                }

                _logger.LogError("Product is not valid");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public Product ChangeProductStatus(int productId, int statusId)
        {
            try
            {
                if (productId <= 0 || statusId <= 0)
                {
                    _logger.LogError("ProductId or StatusId is not valid");
                    return null;
                }

                var product = GetById(productId);
                if (product == null)
                {
                    _logger.LogError($"Product with id {productId} not found");
                    return null;
                }

                product.ProductStatusId = statusId;
                Update(product);
                _logger.LogInfo($"Product {product.ProductName} status changed successfully.");
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public int GetCountOfDamagedProducts()
        {
            try
            {
                var specification = new ProductWithCategoryAndStatusSpecification();
                var damagedCount = FindWithSpecificationPattern(specification).GetDamagedroducts().ToList()?.Count();
                _logger.LogInfo($"Count of damaged products is {damagedCount}");
                return damagedCount ?? 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        public int GetCountOfInStockProducts()
        {
            try
            {
                var specification = new ProductWithCategoryAndStatusSpecification();
                var inStockCount = FindWithSpecificationPattern(specification).GetInStockProducts().ToList()?.Count();
                _logger.LogInfo($"Count of in stock products is {inStockCount}");
                return inStockCount ?? 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        public int GetCountOfSoldProducts()
        {
            try
            {
                var specification = new ProductWithCategoryAndStatusSpecification();
                var soldCount = FindWithSpecificationPattern(specification).GetSoldProducts().ToList()?.Count();
                _logger.LogInfo($"Count of sold products is {soldCount}");
                return soldCount ?? 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }
        }

        public Product SellProduct(int productId)
        {
            try
            {
                if (productId <= 0)
                {
                    _logger.LogError("ProductId is not valid");
                    return null;
                }

                var specification = new ProductWithCategoryAndStatusSpecification()
                {
                    Criteria = x => x.Id == productId
                };

                var product = FindWithSpecificationPattern(specification).SingleOrDefault();

                if (product == null)
                {
                    _logger.LogError($"Product with id {productId} not found");
                    return null;
                }

                product.ProductStatusId = (int)ProductStatusEnum.Sold;
                Update(product);
                _logger.LogInfo($"Product {product.ProductName} sold successfully.");
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
