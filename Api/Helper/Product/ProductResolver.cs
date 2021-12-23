

using Api.DTos;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Api.Helper.Product
{
    public class ProductResolver : IValueResolver<Core.Entites.Product, DTos.ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Core.Entites.Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.ImageUrl))
                return null;
                
            return _configuration["ApiUrl"] + source.ImageUrl;
        }
    }
}