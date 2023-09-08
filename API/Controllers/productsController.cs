
using Core.Entity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[Controller]")]
  
  public class ProductsController : ControllerBase
  {
        private readonly StoreContext _context;
    private object await_context;


    public ProductsController(StoreContext context)
    {
            _context = context;
      
    }
        [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductS()
    {   
      var products =await _context.Products.ToListAsync();
      return products;
    }
    [HttpGet("{id}")]
    
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      return await _context.Products.FindAsync(id);
    }
  }

}