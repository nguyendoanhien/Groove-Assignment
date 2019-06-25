using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PersonalNotesAPI.Services
{
    public class BrowserAttribute : ActionFilterAttribute, IExceptionFilter
    {
        private ActionExecutingContext _contextAccessor;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _contextAccessor = context;
            int chromeVersion = CheckChromeVersion();
            if (chromeVersion >= 70) base.OnActionExecuting(context);
            else
                context.Result = new EmptyResult();

        }
        public int CheckChromeVersion()
        {
            string browserInfo = _contextAccessor.HttpContext.Request.Headers["User-Agent"];
            var regex = new Regex(@"(?<=Chrome\/)(.*?)(?=\.)");
            int chromeVersion = Convert.ToInt32(regex.Matches(browserInfo).FirstOrDefault().Value);
            return chromeVersion;
        }

        public void OnException(ExceptionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}
