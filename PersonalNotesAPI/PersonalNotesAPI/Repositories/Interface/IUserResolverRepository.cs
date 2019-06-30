using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalNotesAPI.Repositories.Interface
{
    public interface IUserResolverRepository
    {
        string CurrentUserName();

        IEnumerable<Claim> CurrentUserClaims();
    }
}
