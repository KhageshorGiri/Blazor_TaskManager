using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blazor_TaskManager.Entities;

namespace Blazor_TaskManager.Data
{
    public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) 
        : IdentityDbContext<TaskManagerUser>(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

    }
    
}
