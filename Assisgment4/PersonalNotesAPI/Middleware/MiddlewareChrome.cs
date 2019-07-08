using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Middleware
{
    public class MiddlewareChrome
    {
        private readonly RequestDelegate _next;
      

        public MiddlewareChrome(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            var User_agent = context.Request.Headers["User-Agent"];

            if(User_agent.Any(h => h.ToLower().Contains("chrome"))) {
                await _next.Invoke(context);
            } else {
             
                context.Response.StatusCode = 403;
            }
        }
    }
    public static class MiddlewareChromeExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareChrome>();
        }
    }
}
