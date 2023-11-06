using EntityFrameworkLab3Api.Data;
using EntityFrameworkLab3Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLab3Api.Services;

public class StoreService: IStoreService
{
    private readonly AppDbContext _db;

    public StoreService(AppDbContext db)
    {
        _db = db;
    }

    #region Categories

    public async Task<List<Category>> GetCategoriesAsync()
    {
        try
        {
            return await _db.Categories.ToListAsync();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Category> GetCategoryAsync(Guid id)
    {
        try
        {
            return await _db.Categories.FindAsync(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        try
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return await _db.Categories.FindAsync(category.Id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        try
        {
            _db.Entry(category).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return category;
        }
        catch (Exception e)
        {
            return null;    
        }
    }

    public async Task<(bool, string)> DeleteCategoryAsync(Category category)
    {
        try
        {
            var dbCategory = await _db.Categories.FindAsync(category.Id);
            if (dbCategory == null)
            {
                return (false, "Category could not be found");
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return (true, "Category got deleted.");

        }
        catch (Exception e)
        {
            return (false, $"An error occured. Error Message: {e.Message}");

        }
    }
    #endregion Categories

    #region Products

    public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            return await _db.Products.ToListAsync();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Product> GetProductAsync(Guid id)
    {
        try
        {
            return await _db.Products.FindAsync(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        try
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return await _db.Products.FindAsync(product.Id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        try
        {
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return product;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<(bool, string)> DeleteProductAsync(Product product)
    {
        try
        {
            var dbProduct = await _db.Products.FindAsync(product.Id);
            if (dbProduct == null)
            {
                return (false, "Product could not be found");
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return (true, "Product got deleted.");
        }
        catch (Exception e)
        {
            return (false, $"An error occured. Error Message: {e.Message}");
        }
    }
    
    #endregion Products
}