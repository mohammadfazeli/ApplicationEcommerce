using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entites;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _db;

        public ProductController(StoreContext db)
        {
            _db = db;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _db.prodducts.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _db.prodducts.FindAsync(id);

            if (product == null)
                return NotFound();
            return Ok($"product name is : {product.Name} .");
        }
    }
}