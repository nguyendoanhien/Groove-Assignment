using Microsoft.AspNetCore.Http;
using PersonalNotesAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Service
{
    public class UserResolverService : IUserResolverService
    {

        private readonly IHttpContextAccessor   _context;
        public UserResolverService(IHttpContextAccessor  context)
        {
            _context = context;
        }

        public string CurrentUserName()
        {

            return _context.HttpContext.User.Identity.Name;
        }

        public IEnumerable<Claim> CurrentUserClaims()
        {
            return _context.HttpContext.User.Claims;
        }
    }
}

   
