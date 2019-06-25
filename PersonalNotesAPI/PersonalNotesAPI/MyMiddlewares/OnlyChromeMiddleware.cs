using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace PersonalNotesAPI.MyMiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class OnlyChromeMiddleware
    {
        private readonly RequestDelegate _next;

        public OnlyChromeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            //string browserName = httpContext.Request.Headers["User-Agent"].ToString();
            //if (!browserName.ToLower().Contains("chrome"))
            //{
            //    httpContext.Response.ContentType = "text/plain; charset=utf-8";
            //    await httpContext.Response.WriteAsync("Chỉ hỗ trợ chrome",Encoding.UTF8);

            //}


            //await _next(httpContext);

            // 10m to exe
            //var step1 = Step1();

            //var step2 = Step2();

            //var step1Result = await step1;

            //var step3 = Step3(step1Result);

        


            httpContext.Items["Chrome"] = httpContext.Request.Headers["User-Agent"].Any(v => v.ToLower().Contains("chrome"));
            await _next.Invoke(httpContext);
        }

        //public Task<int> Step1()
        //{
        //    Thread.Sleep(600000);
        //    return Task.FromResult<int>(1);
        //}

        //public int Step2()
        //{
        //    return 100;
        //}
        //public Task<int> Step3(int step1Result)
        //{
        //    return Task.FromResult<int>(step1Result + 1);
        //}
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class OnlyChromeMiddlewareExtensions
    {
        public static IApplicationBuilder UseOnlyChromeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OnlyChromeMiddleware>();
        }
    }
}
