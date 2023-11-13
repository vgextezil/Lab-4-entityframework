using EntityFrameworkLab3Api.Models;
using EntityFrameworkLab3Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkLab3Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/[controller]")]
public class ProductController: ControllerBase
{
    private readonly IStoreService _storeService;

    public ProductController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _storeService.GetProductsAsync();
        if (products == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, "No products in database.");
        }
        return StatusCode(StatusCodes.Status200OK, products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        Product product = await _storeService.GetProductAsync(id);

        if (product == null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No product found for id: {id}");
        }

        return StatusCode(StatusCodes.Status200OK, product);
    }
    
    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
        var dbProduct = await _storeService.AddProductAsync(product);

        if (dbProduct == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"{product.Name} could not be added.");
        }

        return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        Product dbProduct = await _storeService.UpdateProductAsync(product);

        if (dbProduct == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"{product.Name} could not be updated");
        }

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var product = await _storeService.GetProductAsync(id);
        (bool status, string message) = await _storeService.DeleteProductAsync(product);

        if (status == false)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, message);
        }

        return StatusCode(StatusCodes.Status200OK, product);
    }
    
}