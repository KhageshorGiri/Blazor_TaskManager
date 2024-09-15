using Blazor_TaskManager.Entities;
using System.Data;

namespace Blazor_TaskManager.Services.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync();
    Task<TaskItem> GetTaskItemByIdAsync(int id);
    Task AddTaskItemAsync(TaskItem task);
    Task<TaskItem> UpdateTaskItemAsync(TaskItem task);
    Task DeleteTaskItemAsync(int id);

    Task<int[]> GetTaskStatus(DateTime currentDate);
}
