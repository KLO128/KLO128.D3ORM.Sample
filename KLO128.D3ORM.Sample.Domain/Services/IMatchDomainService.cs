using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Domain.Services
{
    public interface IMatchDomainService : IDomainService
    {
        Match AddMatch(int homeTeamId, int awayTeamId, int? tournamentId, int tournamentPhase, int changedById);

        Match AddMatch(Team homeTeam, Team awayTeam, int? tournamentId, int tournamentPhase, int changedById);

        Match AddMatchSetScore(int matchId, int setOrder, int homeTeamScore, int awayTeamScore, int changedById);

        Match UpdateMatchSetScore(int matchId, int setOrder, int homeTeamScore, int awayTeamScore, int changedBy);

        Match UpdateMatchSetScore(Match match, int setOrder, int homeTeamScore, int awayTeamScore, int changedBy);

        Match AddMatchSetScore(Match match, int setOrder, int homeTeamScore, int awayTeamScore, int changedById);

        List<Match> GetMatches(int? tournamentId, int? teamId, int? tournamentPhase);
    }
}
