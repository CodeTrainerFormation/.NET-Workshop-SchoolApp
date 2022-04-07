using Microsoft.AspNetCore.Mvc.Filters;

namespace SchoolWeb.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MyActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // before action execution
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // after action execution
        }
    }
}
