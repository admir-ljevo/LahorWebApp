using Microsoft.AspNetCore.Mvc.Filters;

namespace Lahor.Shared.Attributes
{
    public class DistributedSessionAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await context.HttpContext.Session.LoadAsync();
            await next();
            await context.HttpContext.Session.CommitAsync();
        }
    }
}
