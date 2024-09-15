using Blazor_TaskManager.Data;
using Blazor_TaskManager.Entities;
using Blazor_TaskManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blazor_TaskManager.Services;

public class CategoryService : ICategoryService
{
    private readonly TaskManagerDbContext _dbContext;
    public CategoryService(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddCategoryAsync(Category category)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
            }
        }
    }

    public async Task DeleteCategoryAsync(int id)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
                _dbContext.Categories.Remove(existingCategory);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
        }
    }

    public async Task<IEnumerable<Category>> GetAllCategoryAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _dbContext.Categories.Update(category);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }

            return category;
        }
    }
}
