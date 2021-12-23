using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.DTos;
using AutoMapper;
using Core.Entites;
using Core.InterFace;
using Core.Specefication;
using Core.Specefication.Product;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
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
            this._mapper = mapper;
            _ProductRepository = ProductRepository;
            _ProductRepos = Productrepos;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            // var products = await _ProductRepository.GetProductsAsync();
            var products = await _ProductRepos.GetAllAsync(new ProductSpecefication());
            // Expression<Func<Product, object>> brand = s => s.Brand;
            // Expression<Func<Product, object>> productType = s => s.ProductType;
            // var products = await _ProductRepos.GetAllAsync(
            //     new ProductSpecefication(
            //         x => (x.Id == 5),
            //     new List<Expression<Func<Product, object>>>()
            //     {
            //       brand,
            //       productType
            //     }));
            var item = _mapper.Map<List<Product>, List<ProductDTO>>(products);
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            // var product = await _ProductRepository.GetProductByIdAsync(id);
            var product = await _ProductRepos.GetAync(new ProductSpecefication(x => x.Id == id));
            if (product == null)
                return NotFound();
            var item = _mapper.Map<Product, ProductDTO>(product);

            return Ok(item);
        }
    }
}