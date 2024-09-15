
using Blazor_TaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazor_TaskManager.Components.Pages;

public partial class Home
{
    private DateTime CurrentDateTime = DateTime.Now;

    private int TotalOpened = 0;
    private int TotalClosed = 0;
    private int TotalInProgress = 0;
    private int TotalReOpened = 0;

    [Inject]
    private ITaskService _taskService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        int[] taskStatusCount = await _taskService.GetTaskStatus(CurrentDateTime);

        TotalOpened = taskStatusCount[0];
        TotalClosed = taskStatusCount[1];
        TotalInProgress = taskStatusCount[2];
        TotalReOpened = taskStatusCount[3];
    }
}
