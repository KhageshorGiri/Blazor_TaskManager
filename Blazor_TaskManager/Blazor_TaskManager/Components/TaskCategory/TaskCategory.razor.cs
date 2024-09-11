using Blazor_TaskManager.Entities;
using Blazor_TaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazor_TaskManager.Components.TaskCategory;

public partial class TaskCategory
{
    private IEnumerable<Category> _categories;

    [Inject]
    private ICategoryService _categoryService { get; set; }
    protected override async Task OnInitializedAsync()
    {
        _categories = await _categoryService.GetAllCategoryAsync();
    }
}
