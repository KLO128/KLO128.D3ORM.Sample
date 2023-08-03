using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Domain.Services
{
    public interface ITeamDomainService : IDomainService
    {
        Team CreateTeam(string name, int changedById);

        Team AddPlayer(int teamId, int playerId, int changedById);

        Team AddPlayer(Team team, int playerId, int changedById);

        bool RemovePlayer(int teamId, int playerId, int changedById);

        Team GetTeamData(int teamId);

        Team GetTeamAndStats(int teamId, int? tournamentIdFilter = null, int? tournamentPhase = null);

        List<TournamentTeam> GetTeamStats(int? teamIdFilter = null, int? tournamentIdFilter = null, int? tournamentPhase = null);
    }
}
