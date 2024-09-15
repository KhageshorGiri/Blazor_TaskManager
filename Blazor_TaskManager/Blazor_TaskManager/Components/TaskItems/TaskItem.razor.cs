using Microsoft.AspNetCore.Components;

namespace Blazor_TaskManager.Components.TaskItems;

public partial class TaskItem
{
    [Inject]
    private NavigationManager Navigation { get; set; }

    private void NavigateToAddTask()
    {
        Navigation.NavigateTo("/add-new-task");
    }

}
