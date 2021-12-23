using Api.DTos;

namespace Api.Helper.Product
{
    public class ProductMapping : AutoMapperProfile
    {
        public ProductMapping()
        {
            CreateMap<Core.Entites.Product, ProductDTO>()
            .ForMember(s => s.ProductType, d => d.MapFrom(p => p.ProductType.Name))
            .ForMember(s => s.Brand, d => d.MapFrom(p => p.Brand.Name + " - " + p.Brand.Id.ToString()))
            .ForMember(s => s.ImageUrl, d => d.MapFrom<ProductResolver>());
        }
    }
}