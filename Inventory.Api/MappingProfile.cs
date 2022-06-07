using AutoMapper;
using Inventory.Domain.Domains.Products;
using Inventory.Shared.DataTransferObjects;

namespace Inventory.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Source --> Destination
            CreateMap<Product, ProductDto>()
                .ForMember(c => c.CategoryName, opt => opt.MapFrom(r => r.Category.CategoryName))
                .ForMember(c => c.ProductStatus, opt => opt.MapFrom(r => r.ProductStatus.StatusName));

            CreateMap<ProductForCreationDto, Product>();
        }
    }
}
