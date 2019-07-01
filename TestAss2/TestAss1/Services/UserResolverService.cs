using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAss1.Data;

namespace TestAss1.Services
{
    public class UserResolverService : IUserResolverService
    {
        private IHttpContextAccessor _context;

        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string CurrentUserName()
        {
            return _context.HttpContext.User?.Identity?.Name;
        }
    }
}
