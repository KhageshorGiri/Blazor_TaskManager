using Blazor_TaskManager.Data;
using Blazor_TaskManager.Entities;
using Blazor_TaskManager.Entities.Enums;
using Blazor_TaskManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blazor_TaskManager.Services;

public class TaskService : ITaskService
{
    private readonly TaskManagerDbContext _dbContext;
    public TaskService(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddTaskItemAsync(TaskItem task)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _dbContext.TaskItems.Add(task);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
        }
    }

    public async Task DeleteTaskItemAsync(int id)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                var existingItem = await _dbContext.TaskItems.FirstOrDefaultAsync(c => c.Id == id);
                _dbContext.TaskItems.Remove(existingItem);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
        }
    }

    public async Task<IEnumerable<TaskItem>> GetAllTaskItemsAsync()
    {
        return await _dbContext.TaskItems.ToListAsync();
    }

    public async Task<TaskItem> GetTaskItemByIdAsync(int id)
    {
        return await _dbContext.TaskItems.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<TaskItem> UpdateTaskItemAsync(TaskItem task)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _dbContext.TaskItems.Update(task);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }

            return task;
        }
    }

    public async Task<int[]> GetTaskStatus(DateTime currentDate)
    {
        int[] taskStatusCount = new int[4];
        var startOfDay = currentDate.Date; 
        var endOfDay = startOfDay.AddDays(1);

        var todaysTaskList = await _dbContext.TaskItems
            .Where(t => t.UpdateDate >= startOfDay && t.UpdateDate < endOfDay)
            .ToListAsync();

        taskStatusCount[0] = todaysTaskList.Where(t => t.Status == StatusOptionType.Todo).Count(); 
        taskStatusCount[1] = todaysTaskList.Where(t => t.Status == StatusOptionType.Completed).Count(); 
        taskStatusCount[2] = todaysTaskList.Where(t => t.Status == StatusOptionType.InProgress).Count(); 
        taskStatusCount[3] = todaysTaskList.Where(t => t.Status == StatusOptionType.ReOpened).Count(); 

        return taskStatusCount;
    }
}
