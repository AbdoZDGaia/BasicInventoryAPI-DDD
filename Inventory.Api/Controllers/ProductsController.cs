using Inventory.Api.ActionFilters;
using Inventory.Api.Contracts;
using Inventory.Domain.Interfaces;
using Inventory.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(ApiRoutes.Products.GetProduct, Name = "ProductById")]
        public IActionResult GetProduct(int productId)
        {
            var product = _productService.GetProduct(productId);
            return Ok(product);
        }

        [HttpGet(ApiRoutes.Products.GetCounts)]
        public IActionResult GetCounts()
        {
            var counts = _productService.GetProductCounts();
            return Ok(counts);
        }

        [HttpPost(ApiRoutes.Products.AddProduct)]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public IActionResult Create([FromBody] ProductForCreationDto request)
        {
            var createdProduct = _productService.AddProduct(request);
            return CreatedAtRoute("ProductById", new { productId = createdProduct.Id }, createdProduct);
        }

        [HttpPut(ApiRoutes.Products.SellProduct)]
        public IActionResult SellProduct(int productId)
        {
            var soldProduct = _productService.SellProduct(productId);
            return Ok(soldProduct);
        }
    }
}
