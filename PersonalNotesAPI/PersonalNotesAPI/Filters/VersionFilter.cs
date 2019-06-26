using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace PersonalNotesAPI.Filters
{
    public class VersonFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string version = context.HttpContext.Request.Headers["User-Agent"];
            Regex expression = new Regex(@"(?<= Chrome\/)(.*?)(?=\.)");
            Match results = expression.Match(version);

            if (int.Parse(results.Value) < 70)
            {
                context.Result = new ObjectResult("Can't process this!")
                {
                    StatusCode = 422,
                };
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
