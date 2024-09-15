using Blazor_TaskManager.Entities;
using Blazor_TaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace Blazor_TaskManager.Components.TaskCategory;

public partial class TaskCategory
{
   
    private IEnumerable<Category> _categories;
    private Category selectedCategory = new Category();  // Category being edited

    [Inject]
    private ICategoryService _categoryService { get; set; }

    PaginationState categoryTablePaginationState = new PaginationState
    {
        ItemsPerPage = 10
    };

    string categoryFilter = "";

    protected override async Task OnInitializedAsync()
    {
        await LoadCategories();
    }

    private async Task LoadCategories()
    {
        var allCategories = await _categoryService.GetAllCategoryAsync();
        _categories = allCategories.Where(cat => cat.Name.Contains(categoryFilter));
    }


    [SupplyParameterFromForm]
    public Category Category { get; set; } = new();

    public async Task AddCatgory()
    {
        await _categoryService.AddCategoryAsync(Category);

        // Reset the form fields by reinitializing the Category object
        Category = new Category();
        await LoadCategories();
    }

    // Method to open the modal with selected category for editing
    private async Task EditCategory(Category category)
    {
        selectedCategory = category; 
    }

    private async Task SaveCategory()
    {
        await _categoryService.UpdateCategoryAsync(selectedCategory);
        selectedCategory = new Category();
        await LoadCategories();  // Reload categories after the update
    }

    private async Task DeleteCategory(Category category)
    {
        await _categoryService.DeleteCategoryAsync(category.Id);
        await LoadCategories();  
    }

}
