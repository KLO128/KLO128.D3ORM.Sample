using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace KLO128.D3ORM.Sample.Presentation.WebApi.Extensions
{
    public static class UserExt
    {
        public static int GetUserId(this IPrincipal user)
        {
            return GetUserId(user.GetClaims());
        }

        public static int GetUserId(this IEnumerable<Claim> user)
        {
            var str = GetClaim(user, Constants.MyClaimTypes.Id);

            if (string.IsNullOrEmpty(str))
            {
                str = GetClaim(user, ClaimTypes.NameIdentifier);
            }

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            return int.Parse(str);
        }

        public static int GetUserRoleId(this IPrincipal user)
        {
            return GetUserRoleId(user.GetClaims());
        }

        public static IEnumerable<Claim> GetClaims(this IPrincipal user)
        {
            return (user as ClaimsPrincipal)?.Claims ?? new List<Claim>();
        }

        public static int GetUserRoleId(this IEnumerable<Claim> user)
        {
            var str = GetClaim(user, Constants.MyClaimTypes.RoleId);

            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            return int.Parse(str);
        }

        public static string? GetUserEmail(this IPrincipal user)
        {
            return user.Identity?.Name ?? GetUserEmail(user.GetClaims());
        }

        public static string? GetUserEmail(this IEnumerable<Claim> user)
        {
            return user.GetClaim(ClaimTypes.Name);
        }

        public static string? GetClaim(this IPrincipal user, string claimType)
        {
            return (user.Identity as ClaimsIdentity)?.Claims?.GetClaim(claimType);
        }

        public static string? GetClaim(this IEnumerable<Claim> claims, string claimType)
        {
            var ret = string.Join(",", claims.Where(x => x.Type == claimType).Select(x => x?.Value));

            if (ret == string.Empty)
            {
                return null;
            }

            return ret;
        }

        public static int? GetClaimInt32(this IPrincipal user, string claimType)
        {
            return (user.Identity as ClaimsIdentity)?.Claims?.GetClaimInt32(claimType);
        }

        public static int? GetClaimInt32(this IEnumerable<Claim> claims, string claimType)
        {
            var ret = GetClaim(claims, claimType);

            return ParseClaimStrForInt(ret);
        }

        private static int? ParseClaimStrForInt(string? str)
        {
            if (str == null)
            {
                return null;
            }

            var ret = str.Split(',') ?? new string[0];

            for (int i = ret.Length - 1; i >= 0; i--)
            {
                var item = ret[i];

                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }

                if (int.TryParse(item, out int result))
                {
                    return result;
                }
            }

            return null;
        }


        public static void SetSignedInUser(this ISession session, ZUserDTO? user)
        {
            if (user == null)
            {
                session.Set(Constants.WebApi.UserSessionKey, new byte[0]);

                return;
            }

            var identity = new List<ClaimDTO>();

            identity.Add(new ClaimDTO(ClaimTypes.Name, user.Email));
            identity.Add(new ClaimDTO(Constants.MyClaimTypes.Id, user.UserId.ToString()));
            identity.Add(new ClaimDTO(Constants.MyClaimTypes.RoleId, user.UserRoles.FirstOrDefault(x => x.IsActive)?.RoleId.ToString() ?? "0"));

            var userEncoded = JsonConvert.SerializeObject(identity);

            session.Set(Constants.WebApi.UserSessionKey, Encoding.UTF8.GetBytes(userEncoded));
        }

        public static IEnumerable<Claim>? GetSignedInUser(this ISession session)
        {
            var bytes = session.Get(Constants.WebApi.UserSessionKey);

            if (bytes is byte[] userEncoded && userEncoded.Length > 0)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ClaimDTO>>(Encoding.UTF8.GetString(userEncoded))?.Select(x => new Claim(x.Type, x.Value)).ToList();
            }

            return null;
        }
    }
}
