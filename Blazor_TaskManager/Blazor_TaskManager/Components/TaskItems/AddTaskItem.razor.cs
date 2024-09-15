
using Blazor_TaskManager.Entities;
using Blazor_TaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazor_TaskManager.Components.TaskItems;

public partial class AddTaskItem
{
    [Inject]
    private ICategoryService _categoryService { get; set; }
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
        // Save the taskModel to the server or perform any action
        // For now, just display a message
        Console.WriteLine("Form submitted successfully!");
    }


    private async Task LoadCategories()
    {
        _categories = await _categoryService.GetAllCategoryAsync();
    }

}
