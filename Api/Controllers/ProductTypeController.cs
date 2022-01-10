using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entites;
using Core.InterFace;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProductTypeController : BaseController
    {
        private readonly IRepository<ProductType> _ProductRepos;

        public ProductTypeController(IRepository<ProductType> Productrepos)
        {
            _ProductRepos = Productrepos;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _ProductRepos.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _ProductRepos.GetAync(id);

            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}