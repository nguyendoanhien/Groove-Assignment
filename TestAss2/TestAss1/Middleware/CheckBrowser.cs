using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAss1.Middleware
{
    public class CheckBrowser
    {
        private readonly RequestDelegate _nextMiddleware;
        public CheckBrowser(RequestDelegate next)
        {
            _nextMiddleware = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {

            var item = httpContext.Request.Headers["User-Agent"].ToString();
            if (httpContext.Request.Headers["User-Agent"].Any(options => options.ToLower().Contains("chrome")))
            {
                await _nextMiddleware.Invoke(httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = 403;
            }
        }
    }
}
