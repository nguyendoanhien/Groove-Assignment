using Microsoft.AspNetCore.Builder;
using PersonalNotesAPI.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotesAPI
{
    public partial class Startup
    {
        public void RegisterMiddlewares(IApplicationBuilder builder)
        {
            //builder.UseAuthorizationTokenCheckMiddleware();
            //builder.UseClientCheckMiddlewareMiddleware();
        }

    }
}
