using Blazor_TaskManager.Entities.Enums;
using Blazor_TaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor_TaskManager.Components.TaskItems;

public partial class TaskItem
{
    [Inject]
    private NavigationManager Navigation { get; set; }

    [Inject]
    private ITaskService _taskService { get; set; }

    private IEnumerable<Blazor_TaskManager.Entities.TaskItem> _allTaskItems { get; set; } = new List<Blazor_TaskManager.Entities.TaskItem>();
    protected override async Task OnInitializedAsync()
    {
        await LoadAllTaskList();
    }


    private async Task LoadAllTaskList()
    {
        _allTaskItems = await _taskService.GetAllTaskItemsAsync();
    }


    private void NavigateToAddTask()
    {
        Navigation.NavigateTo("/add-new-task");
    }

    // Method to return a CSS class based on the priority value
    private string GetPriorityColor(PriorityOptionType priority)
    {
        return priority switch
        {
            PriorityOptionType.Low => "text-success",   // Green for Low Priority
            PriorityOptionType.Medium => "text-info", // Yellow for Medium Priority
            PriorityOptionType.High => "text-danger",    // Red for High Priority
            _ => "text-secondary" // Default color (gray)
        };
    }

    // Method to return a CSS class based on the priority value
    private string GetStatusColor(StatusOptionType status)
    {
        return status switch
        {
            StatusOptionType.Todo => "text-primary",   
            StatusOptionType.InProgress => "text-info", 
            StatusOptionType.Rejected => "text-danger",    
            StatusOptionType.Completed => "text-success",    
            StatusOptionType.ReOpened => "text-warning",    
            _ => "text-secondary" 
        };
    }

}
