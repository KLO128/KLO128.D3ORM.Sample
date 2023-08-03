using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Domain.Services
{
    public interface ITournamentPlayerStatDomainService : IDomainService
    {
        List<TournamentPlayerStat> GetPlayerStats(int? playerIdFilter = null, int? tournamentIdFilter = null);
    }
}
