using Blazor_TaskManager.Data;
using Microsoft.AspNetCore.Identity;

namespace Blazor_TaskManager.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<TaskManagerUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<TaskManagerUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
