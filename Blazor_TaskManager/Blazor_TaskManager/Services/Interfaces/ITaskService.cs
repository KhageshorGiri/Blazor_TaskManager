using Blazor_TaskManager.Entities;

namespace Blazor_TaskManager.Services.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync();
    Task<TaskItem> GetTaskItemByIdAsync(int id);
    Task AddTaskItemAsync(TaskItem task);
    Task<TaskItem> UpdateTaskItemAsync(TaskItem task);
    Task DeleteTaskItemAsync(int id);
}
