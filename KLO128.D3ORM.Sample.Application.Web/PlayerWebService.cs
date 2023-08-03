using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results;
using KLO128.D3ORM.Sample.Application.Contracts.Services;
using KLO128.D3ORM.Sample.Domain.Services;

namespace KLO128.D3ORM.Sample.Application.Web
{
    public class PlayerWebService : IPlayerService
    {
        public ITournamentPlayerStatDomainService TournamentPlayerStatDomainService { get; set; }

        public PlayerWebService(ITournamentPlayerStatDomainService TournamentPlayerStatDomainService)
        {
            this.TournamentPlayerStatDomainService = TournamentPlayerStatDomainService;
        }

        public ServiceResult<PlayerStatsResult> GetPlayerStats(int? tournamentId, int? playerId)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                var result = TournamentPlayerStatDomainService.GetPlayerStats(playerId, tournamentId);

                return new PlayerStatsResult
                {
                    Stats = result.Select(x => x.ToDTO<TournamentPlayerStatDTO>()).ToList()
                };
            });
        }
    }
}
