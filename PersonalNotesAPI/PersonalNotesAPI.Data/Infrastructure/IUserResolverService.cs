using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace PersonalNotesAPI.Data
{
    public interface IUserResolverService
    {
        string CurrentUserName();

        IEnumerable<Claim> CurrentUserClaims();
    }
}
