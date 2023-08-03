using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Domain.Services
{
    public interface IUserDomainService : IDomainService
    {
        User CreatePlayer(string email, string password, string firstName, string lastName, string gender, DateTime dateOfBirth, string? phoneNumber, int roleId, int guidExpireAfter = 5);

        User GetUser(int id, int? teamId);

        User? FindUser(int id, int? teamId);

        User? FindUser(int id, bool includeRoles);

        User? FindUser(string email, bool includeRoles);

        User? FindUserPublic(int id);

        void UpsertRole(int userId, int? teamId, Roles role);

        void ChangePassword(User user, string oldPassword, string newPassword);

        bool CheckPassword(User user, string password);

        bool IsInRole(int userId, int? teamId, int roleId);

        bool IsInRole(User user, int? teamId, int roleId);

    }
}
