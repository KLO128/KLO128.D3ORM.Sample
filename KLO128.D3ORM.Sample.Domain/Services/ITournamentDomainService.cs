using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Domain.Services
{
    public interface ITournamentDomainService : IDomainService
    {
        Tournament CreateTournament(string name, int entryFee, int maxNumOfTeams, int tourSerieId, int addressId, int changedById, DateTime startDate, DateTime endDate);

        Tournament CreateTournament(string name, int entryFee, int maxNumOfTeams, TourSerie? tourSerie, Address address, int changedById, DateTime startDate, DateTime endDate);

        TournamentTeam CreateTournamentTeam(int teamId, int tournamentId, int changedById);

        TournamentTeam CreateTournamentTeam(Team team, Tournament tournament, int changedById);

        void CreateEmptyStats(TournamentTeam tournamentTeam, int tournamentPhase, int changedById);

        List<Match> GetMatches(int? tournamentId = null, int? tournamentPhase = null, int? teamId = null);
    }
}
