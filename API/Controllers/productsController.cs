using Core.Entity;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
    [Route("API/[Controller]")]
  
  public class ProductsController : ControllerBase
  {
        public IProductRepository _repo;
    
    public ProductsController(IProductRepository repo)
    {
            _repo = repo;
    }
        [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductS()
    {   
      var products =await _repo.GetProductsAsync();
      
      return Ok (products);
    }
    [HttpGet("{id}")]
    
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      return await _repo.GetProductByIdAsync(id);
    }

    [HttpGet("brands")]

    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
      return Ok(await _repo.GetProductBrandsAsync());
    }

     [HttpGet("types")]

    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
      return Ok(await _repo.GetProductTypesAsync());
    }
  }

}