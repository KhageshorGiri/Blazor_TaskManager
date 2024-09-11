using Blazor_TaskManager.Entities;
using Blazor_TaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace Blazor_TaskManager.Components.TaskCategory;

public partial class TaskCategory
{
    private IEnumerable<Category> _categories;

    [Inject]
    private ICategoryService _categoryService { get; set; }

    PaginationState categoryTablePaginationState = new PaginationState
    {
        ItemsPerPage = 2
    };

    string categoryFilter = "";

    protected override async Task OnInitializedAsync()
    {
        var allCategories = await _categoryService.GetAllCategoryAsync();
        _categories = allCategories.Where(cat => cat.Name.Contains(categoryFilter));
    }
}
