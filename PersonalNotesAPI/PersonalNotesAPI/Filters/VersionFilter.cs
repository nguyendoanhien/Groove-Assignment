using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Filters
{
    public class VersonFilter : Attribute, IActionFilter
    {
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string version = context.HttpContext.Request.Headers["User-Agent"];
            Regex expression = new Regex(@"(?<= Chrome\/)(.*?)(?=\.)");
            Match results = expression.Match(version);
            if(int.Parse(results.Value)>70)
            {
                //context.Controller("")
            }
            else
            {
                context.HttpContext.Response.ContentType = "text/plain; charset=utf-8";
                context.HttpContext.Response.WriteAsync("Không có trang này", Encoding.UTF8);
            }
        }
    }
}
