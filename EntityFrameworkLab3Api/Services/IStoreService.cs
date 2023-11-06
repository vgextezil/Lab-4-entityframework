using EntityFrameworkLab3Api.Models;

namespace EntityFrameworkLab3Api.Services;

public interface IStoreService
{
    //Category Services
    Task<List<Category>> GetCategoriesAsync(); // GET All Categories
    Task<Category> GetCategoryAsync(Guid id); // GET Single Category
    Task<Category> AddCategoryAsync(Category category); // POST New Category
    Task<Category> UpdateCategoryAsync(Category category); // PUT Category
    Task<(bool, string)> DeleteCategoryAsync(Category category); // DELETE Category
    
    //Product Services
    Task<List<Product>> GetProductsAsync(); // GET All Products
    Task<Product> GetProductAsync(Guid id); // Get Single Product
    Task<Product> AddProductAsync(Product product); // POST New Product
    Task<Product> UpdateProductAsync(Product product); // PUT Product
    Task<(bool, string)> DeleteProductAsync(Product product); // DELETE Product
}