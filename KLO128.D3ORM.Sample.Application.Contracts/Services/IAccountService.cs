using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Application.Contracts.Services
{
    public interface IAccountService
    {
        ServiceResult<ZUserDTO> SignIn(SignInArgs args);

        ServiceResult<ZUserDTO> SignUpTransact(SignUpArgs args);

        ServiceResult<ZUserDTO> GetDetail(int signedInUserId);

        bool IsInRole(int userId, Roles role, int? teamId = null);
    }
}
