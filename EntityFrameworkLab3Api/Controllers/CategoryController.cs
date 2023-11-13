using System.IdentityModel.Tokens.Jwt;
using EntityFrameworkLab3Api.Models;
using EntityFrameworkLab3Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkLab3Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/[controller]")]

public class CategoryController: ControllerBase
{
    private readonly IStoreService _storeService;

    public CategoryController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _storeService.GetCategoriesAsync();
        if (categories == null)
        {   
            return StatusCode(StatusCodes.Status204NoContent, "No categories in database");
        }

        return StatusCode(StatusCodes.Status200OK, categories);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        Category category = await _storeService.GetCategoryAsync(id);
        if (category==null)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No Category found for id: {id}");
        }
        
        return StatusCode(StatusCodes.Status200OK, category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> AddCategory(Category category)
    {
        var dbCategory = await _storeService.AddCategoryAsync(category);
        if (dbCategory == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"{category.Name} could not be added.");
        }

        return CreatedAtAction("GetCategory", new { id = category.Id }, category);
    }

    [HttpPost("id")]
    public async Task<IActionResult> UpdateCategory(Guid id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        Category dbCategory = await _storeService.UpdateCategoryAsync(category);
        if (dbCategory == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"{category.Name} could not be updated");
        }

        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var category = await _storeService.GetCategoryAsync(id);
        (bool status, string message) = await _storeService.DeleteCategoryAsync(category);
        if (status == false)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, message);
        }

        return StatusCode(StatusCodes.Status200OK, category);
    }
}