using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Version
{
    public class VersionFilter : ActionFilterAttribute
    {


        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var User_agent = context.HttpContext.Request.Headers["User-Agent"];

            Regex expression = new Regex(@"?<= Chrome\/)(.*?)(?=\.)");
            Match results = expression.Match(User_agent);

            if (int.Parse(results.Value) < 70)
            {
                context.Result = new ObjectResult("Can't process this!")
                {
                    StatusCode = 422,
                };
            }
        }
    }

}

