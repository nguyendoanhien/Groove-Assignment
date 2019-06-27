using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace PersonalNotesAPI.VersionFilter
{
    public class ChromeFilter : ActionFilterAttribute
    {        
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string version = context.HttpContext.Request.Headers["User-Agent"];
            Regex rg = new Regex(@"(?<=Chrome\/)(.*?)(?=\.)");
            Match vs = rg.Match(version);
            if (int.Parse(vs.Value) < 70)
            {
                context.Result = new ObjectResult("Action requires Chrome version > 70 ") { StatusCode = 422 };
            }
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}
