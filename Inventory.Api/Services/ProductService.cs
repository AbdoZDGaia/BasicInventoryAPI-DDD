using AutoMapper;
using Inventory.Domain.Domains.Products;
using Inventory.Domain.Exceptions;
using Inventory.Domain.Interfaces;
using Inventory.Domain.Specification;
using Inventory.Shared.DataTransferObjects;

namespace Inventory.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductDto GetProduct(int id)
        {
            if (id < 0)
                throw new IdParametersBadRequestException("id");

            var product = _productRepository.FindWithSpecificationPattern(
               new ProductWithCategoryAndStatusSpecification() { Criteria = x => x.Id == id })
               .SingleOrDefault();

            if (product == null)
                throw new ProductNotFoundException(id);

            var productToReturn = _mapper.Map<ProductDto>(product);
            return productToReturn;
        }

        public ProductDto AddProduct(ProductForCreationDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            _productRepository.Create(productEntity);
            _unitOfWork.Commit();
            var savedProduct = _productRepository.FindWithSpecificationPattern(
                new ProductWithCategoryAndStatusSpecification() { Criteria = x => x.Id == productEntity.Id })
                .SingleOrDefault();
            var productToReturn = _mapper.Map<ProductDto>(savedProduct);
            return productToReturn;
        }

        public ProductCountsDto GetProductCounts()
        {
            var counts = new ProductCountsDto
            {
                Damaged = _productRepository.GetCountOfDamagedProducts(),
                InStock = _productRepository.GetCountOfInStockProducts(),
                Sold = _productRepository.GetCountOfSoldProducts()
            };

            return counts;
        }

        public ProductDto ChangeProductStatus(int productId, int statusId)
        {
            if (productId < 0)
                throw new IdParametersBadRequestException("productId");

            if (statusId < 0)
                throw new IdParametersBadRequestException("statusId");

            var product = _productRepository.ChangeProductStatus(productId, statusId);
            var changedProduct = _mapper.Map<ProductDto>(product);
            return changedProduct;

        }
        public ProductDto SellProduct(int productId)
        {
            if (productId < 0)
                throw new IdParametersBadRequestException("productId");

            var product = _productRepository.SellProduct(productId);
            var soldProduct = _mapper.Map<ProductDto>(product);
            return soldProduct;
        }

    }
}
