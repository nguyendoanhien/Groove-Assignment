using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace PersonalNotesAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class OnlySupportChrome
    {
        private readonly RequestDelegate _next;

        public OnlySupportChrome(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Headers["User-Agent"]
            .Any(h => h.ToLower().Contains("chrome")))
            {
                await _next.Invoke(httpContext);
            }
            else
            {
                httpContext.Response.ContentType = "text/plain; charset=utf-8";
                await httpContext.Response.WriteAsync("Không có trang này", Encoding.UTF8); 
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class OnlySupportChromeExtensions
    {
        public static IApplicationBuilder UseOnlySupportChrome(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OnlySupportChrome>();
        }
    }
}
