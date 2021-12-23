using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entites;
using Core.InterFace;
using Infrastructure.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly  IRepository<Brand>  _brandRepos;

        public BrandController( IRepository<Brand> brandrepos )
        {
            _brandRepos = brandrepos;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _brandRepos.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _brandRepos.GetAync(id);

            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}