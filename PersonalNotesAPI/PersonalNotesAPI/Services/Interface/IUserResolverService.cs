using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Services.Interface
{
    public interface IUserResolverService
    {
        string CurrentUserName();

        IEnumerable<Claim> CurrentUserClaims();
    }
}
