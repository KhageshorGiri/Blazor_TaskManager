using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blazor_TaskManager.Data;

namespace Blazor_TaskManager.Data
{
    public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : IdentityDbContext<TaskManagerUser>(options)
    {
    }
}
