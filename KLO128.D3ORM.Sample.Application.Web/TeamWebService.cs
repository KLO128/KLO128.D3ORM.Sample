using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results;
using KLO128.D3ORM.Sample.Application.Contracts.Services;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.Sample.Domain.Services;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Application.Web
{
    public class TeamWebService : ITeamService
    {
        public IQueryContainer QC { get; set; }

        public IUnitOfWork UnitOfWork { get; set; }

        private IUserDomainService UserDomainService { get; set; }
        public ITeamDomainService TeamDomainService { get; set; }

        public TeamWebService(IQueryContainer QC, IUnitOfWork UnitOfWork, IUserDomainService UserDomainService, ITeamDomainService TeamDomainService)
        {
            this.QC = QC;
            this.UnitOfWork = UnitOfWork;
            this.UserDomainService = UserDomainService;
            this.TeamDomainService = TeamDomainService;
        }

        public ServiceResult<TeamDTO> AddPlayerTransact(AddPlayerArgs args, int signedInUserId)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => AddPlayerUnsafe(args, signedInUserId, true)));
        }

        public TeamDTO AddPlayerUnsafe(AddPlayerArgs args, int signedInUserId, bool authorize)
        {
            Helpers.Authorize<TeamDTO>(UserDomainService, signedInUserId, Roles.TeamAdmin, authorize, args.TeamId);

            var result = TeamDomainService.AddPlayer(args.TeamId, args.PlayerId, signedInUserId);

            return result.ToDTO<TeamDTO>();
        }

        public ServiceResult<TeamDTO> CreateTeamTransact(CreateTeamArgs args, int signedInUserId)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => CreateTeamUnsafe(args, signedInUserId)));
        }

        public TeamDTO CreateTeamUnsafe(CreateTeamArgs args, int signedInUserId)
        {
            Helpers.Authorize<TeamDTO>(UserDomainService, signedInUserId, Roles.TeamAdmin, false);

            var result = TeamDomainService.CreateTeam(args.Name, signedInUserId);
            var toUpdate = UserDomainService.FindUser(signedInUserId, null);
            UserDomainService.UpsertRole(signedInUserId, result.TeamId, Roles.TeamAdmin);

            return result.ToDTO<TeamDTO>();
        }

        public ServiceResult<TeamDTO> GetTeamData(int teamId)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                var result = TeamDomainService.GetTeamData(teamId);

                return result.ToDTO<TeamDTO>();
            });
        }

        public ServiceResult<TeamDTO> GetTeamDataAndStats(int teamId)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                var result = TeamDomainService.GetTeamAndStats(teamId);

                return result.ToDTO<TeamDTO>();
            });
        }

        public ServiceResult<TeamStatsResult> GetTeamStats(int? teamId, int? tournamentId)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                var result = TeamDomainService.GetTeamStats(teamId, tournamentId);

                return new TeamStatsResult
                {
                    Stats = result.Select(x => x.ToDTO<TournamentTeamDTO>()).ToList()
                };
            });

        }

        public ServiceResult<bool> RemovePlayerTransact(RemovePlayerFromTeamArgs args, int signedInUserId)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => RemovePlayerUnsafe(args, signedInUserId, true)));
        }

        public bool RemovePlayerUnsafe(RemovePlayerFromTeamArgs args, int signedInUserId, bool authorize)
        {
            Helpers.Authorize<bool>(UserDomainService, signedInUserId, Roles.TeamAdmin, authorize, args.TeamId);

            return TeamDomainService.RemovePlayer(args.TeamId, args.PlayerId, signedInUserId);
        }
    }
}
