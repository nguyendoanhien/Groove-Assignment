using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestAss1.Fillter
{
    public class VersionFillterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var item = context.HttpContext.Request.Headers["User-Agent"];
            Regex rgx = new Regex("(?<=Chrome\\/)(.*?)(?=\\.)");
            var match = rgx.Split(item);
            var result = Int32.Parse(match[1]);
            if (Int32.Parse(match[1]) < 70)
            {
                context.Result = new BadRequestObjectResult("Can't Load this Page");
            }

        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

    }
}
