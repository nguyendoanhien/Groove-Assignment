using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace PersonalNotesAPI.MyMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ShortCircuitMiddleware
    {
        private readonly RequestDelegate _next;

        public ShortCircuitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Items["Chrome"] as bool? == false)
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(httpContext);
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ShortCircuitMiddlewareExtensions
    {
        public static IApplicationBuilder UseShortCircuitMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShortCircuitMiddleware>();
        }
    }
}
