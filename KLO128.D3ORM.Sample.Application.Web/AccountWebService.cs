using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Application.Contracts.Services;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.Sample.Domain.Services;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Application.Web
{
    public class AccountWebService : IAccountService
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public IUserDomainService UserDomainService { get; set; }

        public AccountWebService(IUnitOfWork UnitOfWork, IUserDomainService UserDomainService)
        {
            this.UnitOfWork = UnitOfWork;
            this.UserDomainService = UserDomainService;
        }

        public bool IsInRole(int userId, Roles role, int? teamId = null)
        {
            return UserDomainService.IsInRole(userId, teamId, (int)role);
        }

        public ServiceResult<ZUserDTO> SignIn(SignInArgs args)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                var ret = UserDomainService.FindUser(args.UserName, true);

                if (ret == null || !UserDomainService.CheckPassword(ret, args.Password))
                {
                    throw Errors.InvalidUserNameOrPassword();
                }

                return ret.ToDTO<ZUserDTO>();
            });

        }

        public ServiceResult<ZUserDTO> SignUpTransact(SignUpArgs args)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => SignUpUnsafe(args)));
        }

        public ZUserDTO SignUpUnsafe(SignUpArgs args)
        {
            var result = UserDomainService.CreatePlayer(args.Email, args.Password, args.FirstName, args.LastName, args.Gender, args.DateOfBirth, args.PhoneNumber, (int)Roles.Host);

            return result.ToDTO<ZUserDTO>();
        }

        public ServiceResult<ZUserDTO> GetDetail(int signedInUserId)
        {
            var result = UserDomainService.GetUser(signedInUserId, null).ToDTO<ZUserDTO>();

            return new ServiceResult<ZUserDTO>
            {
                Result = result
            };
        }
    }
}
