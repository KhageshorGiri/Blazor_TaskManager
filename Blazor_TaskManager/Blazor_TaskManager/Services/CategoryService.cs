using Blazor_TaskManager.Data;
using Blazor_TaskManager.Entities;
using Blazor_TaskManager.Services.Interfaces;

namespace Blazor_TaskManager.Services;

public class CategoryService : ICategoryService
{
    private readonly TaskManagerDbContext _dbContext;
    private List<Category> _categories = new(); 
    public CategoryService(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;

        _categories.Add(new() { Id = 1, Name = "Feature" });
        _categories.Add(new() { Id = 2, Name = "Bug" });
        _categories.Add(new() { Id = 3, Name = "Enhancement" });
        _categories.Add(new() { Id = 4, Name = "Report" });
        _categories.Add(new() { Id = 5, Name = "Support" });
    }
    public Task AddCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAllCategoryAsync()
    {
        return _categories;
    }

    public Task<Category> GetCategoryByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateCategoryAsync(int id, Category category)
    {
        throw new NotImplementedException();
    }
}
