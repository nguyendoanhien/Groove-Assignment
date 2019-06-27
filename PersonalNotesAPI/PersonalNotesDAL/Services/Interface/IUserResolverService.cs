using System.Collections.Generic;
using System.Security.Claims;

namespace PersonalNotesDAL.Services.Interface
{
    public interface IUserResolverService
    {
        string CurrentUserName();

        IEnumerable<Claim> CurrentUserClaims();
    }
}