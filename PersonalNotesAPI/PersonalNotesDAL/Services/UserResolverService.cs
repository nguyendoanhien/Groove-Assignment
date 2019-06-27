using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using PersonalNotesDAL.Services.Interface;

namespace PersonalNotesDAL.Services
{
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string CurrentUserName()
        {
            return _context.HttpContext.User?.Identity?.Name;
        }

        public IEnumerable<Claim> CurrentUserClaims()
        {
            return _context.HttpContext.User.Claims;
        }
    }
}
