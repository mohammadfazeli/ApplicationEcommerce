using Api.DTos;
using Api.Errors;
using Api.Helper;
using AutoMapper;
using Core.Entites;
using Core.InterFace;
using Core.Specefication;
using Core.Specefication.Product;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Core.Enums.Enums;

namespace Api.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IRepository<Product> _ProductRepos;
        private readonly ISpecefication<Product> _productSpecefication;
        private readonly IMapper _mapper;

        public ProductController(
            IProductRepository ProductRepository,
            IRepository<Product> Productrepos,
            ISpecefication<Product> productSpecefication,
            IMapper mapper)
        {
            _productSpecefication = productSpecefication;
            _mapper = mapper;
            _ProductRepository = ProductRepository;
            _ProductRepos = Productrepos;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductDTO), statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {

            var products = await _ProductRepos.GetAllAsync(new ProductSpecefication());
            var item = _mapper.Map<List<Product>, List<ProductDTO>>(products);
            return Ok(item);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), statusCode: StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            // var product = await _ProductRepository.GetProductByIdAsync(id);
            var product = await _ProductRepos.GetAync(new ProductSpecefication(x => x.Id == id));
            var x = product.Price;
            if (product == null)
                return NotFound();
            var item = _mapper.Map<Product, ProductDTO>(product);

            return Ok(item);
        }
    }
}