
using Blazor_TaskManager.Entities;
using Blazor_TaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazor_TaskManager.Components.TaskItems;

public partial class AddTaskItem
{
    [Inject]
    private ICategoryService _categoryService { get; set; }


    [Inject]
    private ITaskService _taskService { get; set; }

    [Inject]
    private NavigationManager Navigation { get; set; }


    private IEnumerable<Category> _categories = new List<Category>();

    protected override async Task OnInitializedAsync()
    {
        await LoadCategories();
    }


    // Task model to be edited
    [SupplyParameterFromForm]
    private Blazor_TaskManager.Entities.TaskItem TaskItem { get; set; } = new();
    // Handle valid form submission
    private async Task HandleValidSubmit()
    {
        TaskItem.UpdateDate = DateTime.Now;
        await _taskService.AddTaskItemAsync(TaskItem);
        Navigation.NavigateTo("/task-items");
    }


    private async Task LoadCategories()
    {
        _categories = await _categoryService.GetAllCategoryAsync();
    }

}
