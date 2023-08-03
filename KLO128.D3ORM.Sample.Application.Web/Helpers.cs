using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Services;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Application.Web
{
    public static class Helpers
    {
        public static void Authorize<TResult>(IUserDomainService userDomainService, int? userId, Roles role, bool authorize, int? teamId = null)
        {
            if (!authorize)
            {
                return;
            }
            else if (userId == null)
            {
                throw Errors.GetUnauthorizedAccess;
            }

            Authorize<TResult>(userDomainService.FindUser(userId ?? 0, teamId), role, true, userDomainService, teamId);
        }

        public static void Authorize<TResult>(User? user, Roles role, bool authorize, IUserDomainService? userDomainService = null, int? teamId = null)
        {
            if (!authorize)
            {
                return;
            }

            if (user == null || !IsInRole(GetRoleId(user), role) || teamId != null && userDomainService != null && !userDomainService.IsInRole(user, teamId ?? 0, (int)role))
            {
                throw Errors.GetUnauthorizedAccess;
            }
        }

        public static bool IsInRole(int userRoleId, Roles role)
        {
            return userRoleId >= (int)role;
        }

        public static int GetRoleId(this User user)
        {
            return user.UserRoles.FirstOrDefault(x => x.IsActive)?.RoleId ?? 0;
        }
    }
}
