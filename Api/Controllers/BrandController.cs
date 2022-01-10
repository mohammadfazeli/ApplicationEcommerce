using Core.Entites;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IRepository<Brand> _brandrepos;

        public BrandController(IRepository<Brand> brandrepos)
        {
            _brandrepos = brandrepos ?? throw new System.ArgumentNullException(nameof(brandrepos));
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _brandrepos.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _brandrepos.GetAync(id);

            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}