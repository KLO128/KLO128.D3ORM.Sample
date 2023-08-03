using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Repositories;
using KLO128.D3ORM.Sample.Domain.Shared;
using System.Text;

namespace KLO128.D3ORM.Sample.Domain.Services.Impl
{
    public class UserDomainService : IUserDomainService
    {
        public IQueryContainer QC { get; set; }

        private IUserRepository UserRepository { get; set; }

        private IUserRoleRepository UserRoleRepository { get; set; }

        public UserDomainService(IQueryContainer QC, IUserRepository UserRepository, IUserRoleRepository UserRoleRepository)
        {
            this.QC = QC;
            this.UserRepository = UserRepository;
            this.UserRoleRepository = UserRoleRepository;
        }

        public void ChangePassword(User user, string oldPassword, string newPassword)
        {
            if (user.PasswordHash != HashPassword(oldPassword))
            {
                throw Errors.InvalidUserNameOrPassword();
            }

            UserRepository.UpdateProperties(user, x => x.PasswordHash, HashPassword(newPassword));
        }

        public User CreatePlayer(string email, string password, string firstName, string lastName, string gender, DateTime dateOfBirth, string? phoneNumber, int roleId, int guidExpireAfter = 5)
        {
            if (FindUser(email, false) is User)
            {
                throw Errors.SomethingWentWrong();
            }

            var now = DateTime.UtcNow;

            var toAdd = new User
            {
                DateOfBirth = dateOfBirth,
                Email = email,
                ExternalLogin = false,
                FirstName = firstName,
                Gender = gender,
                GuidexpirationDate = now.AddDays(guidExpireAfter),
                LastName = lastName,
                PasswordHash = HashPassword(password),
                PhoneNumber = phoneNumber,
                RegistrationDate = now,
                RegistrationGuid = Guid.NewGuid().ToString(),
                UserName = email,
            };

            UserRepository.AddRoot(toAdd);
            UserRoleRepository.AddAsChild(toAdd, x => x.UserRoles, new UserRole
            {
                IsActive = true,
                RoleId = roleId,
                UserId = toAdd.UserId
            });

            return toAdd;
        }

        public bool IsInRole(int userId, int? teamId, int roleId)
        {
            var userData = FindUser(userId, null);

            if (userData == null)
            {
                return false;
            }

            return IsInRole(userData, teamId, roleId);
        }

        public bool IsInRole(User user, int? teamId, int roleId)
        {
            return user.UserRoles.Any(x => x.IsActive && x.RoleId >= roleId && ((teamId ?? 0) == 0 || x.RoleId == (int)Roles.Admin || x.TeamIdOrDefault == teamId));
        }

        public User? FindUserPublic(int id)
        {
            return UserRepository.FindBy(QC.GetUserIdPublicFilterQuery(id));
        }

        public User GetUser(int id, int? teamId)
        {
            if (UserRepository.FindBy(QC.GetUserIdFilterQuery(id, teamId)) is not User user)
            {
                throw Errors.GetPlayerNotExists(id.ToString());
            }

            return user;
        }

        public User? FindUser(int id, bool includeRoles)
        {
            if (!includeRoles)
            {
                return UserRepository.FindBy(QC.GetUserIdFilterQuery(id, null));
            }
            else
            {
                return UserRepository.FindBy(QC.GetUserAndRolesByIdFilterQuery(id));
            }
        }

        public User? FindUser(int id, int? teamId)
        {
            return UserRepository.FindBy(QC.GetUserIdFilterQuery(id, teamId));
        }

        public User? FindUser(string email, bool includeRoles)
        {
            if (!includeRoles)
            {
                return UserRepository.FindBy(QC.GetUserEmailFilterQuery(email));
            }
            else
            {
                return UserRepository.FindBy(QC.GetUserAndRolesByEmailFilterQuery(email));
            }
        }

        public void UpsertRole(int userId, int? teamId, Roles role)
        {
            var user = UserRepository.FindBy(QC.GetUserAndRolesByIdFilterQuery(userId));

            if (user == null)
            {
                throw Errors.GetPlayerNotExists(userId.ToString());
            }

            var roleTmp = user.UserRoles.FirstOrDefault(x => x.IsActive && x.TeamIdOrDefault == (teamId ?? 0));

            if (roleTmp == null)
            {
                roleTmp = new UserRole
                {
                    IsActive = true,
                    RoleId = (int)role,
                    TeamIdOrDefault = (teamId ?? 0),
                    UserId = userId
                };

                UserRoleRepository.AddAsChild(user, x => x.UserRoles, roleTmp);
            }
            else
            {
                UserRoleRepository.UpdateProperties(roleTmp, x => x.RoleId, (int)role);
            }
        }

        public bool CheckPassword(User user, string password)
        {
            return user.PasswordHash == HashPassword(password);
        }

        private string HashPassword(string plainPassword)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainPassword));
        }
    }
}
