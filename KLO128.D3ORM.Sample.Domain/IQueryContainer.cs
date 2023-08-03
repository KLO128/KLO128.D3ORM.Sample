using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain.Models;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Domain
{
    public interface IQueryContainer
    {
        ISpecification<Team> TeamBaseQuery { get; }

        ISpecification<Team> TeamEmptyQuery { get; }

        ISpecification<Match> MatchBaseQuery { get; }

        ISpecification<Tournament> TournamentBaseQuery { get; }

        ISpecification<User> UserPublicBaseQuery { get; }

        ISpecification<TournamentTeam> TournamentTeamSortedByGroupQuery { get; }

        ISpecificationWithParams<Team> GetTeamIdBaseFilterQuery(int? teamId);

        ISpecificationWithParams<Team> GetTeamIdFilterQuery(int? teamId);

        ISpecificationWithParams<TournamentTeam> GetTournamentTeamFilterQuery(int? tournamentId, int? teamId);

        ISpecificationWithParams<Team> GetTeamBaseTournamentTeamStatsFilterQuery(int? tournamentId, int? teamId, int? tournamentPhase);

        ISpecificationWithParams<TournamentTeam> GetTournamentTeamAndStatsFilterQuery(int? tournamentId, int? teamId, int? tournamentPhase);

        ISpecificationWithParams<TournamentTeamRank> GetTournamentTeamsSortedByStatsQuery(int tournamentId, int? tournamentPhase);

        ISpecificationWithParams<TournamentPlayerStat> GetTourPlayerStatBaseFilterQuery(int? playerId, int? tournamentId);

        ISpecificationWithParams<TEntity> CreateQueryParamized<TEntity>(ISpecification<TEntity> baseQuery, ISpecificationWithParams filterQuery) where TEntity : class;

        ISpecificationWithParams<Team> GetTeamNameFilterQuery(string teamName);

        ISpecificationWithParams<User> GetUserEmailFilterQuery(string email);

        ISpecificationWithParams<User> GetUserAndRolesByEmailFilterQuery(string email);

        ISpecificationWithParams<User> GetUserAndRolesByIdFilterQuery(int userId);

        ISpecificationWithParams<User> GetUserIdFilterQuery(int? userId, int? teamId);

        ISpecificationWithParams<User> GetUserIdFilterQuery(int? userId);

        ISpecificationWithParams<User> GetUserIdPublicFilterQuery(int userId);

        ISpecificationWithParams<Tournament> GetTournamentNameFilterQuery(string tournamentName);

        ISpecificationWithParams<Tournament> GetTournamentIdFilterQuery(int tournamentId);

        ISpecificationWithParams<Tournament> GetTournamenIdBaseFilterQuery(int tournamentId);

        ISpecificationWithParams<Match> GetMatchBaseTournamentPhaseAndTeamIdFilterQuery(int? tournamentId, int? tournamentPhase, int? teamId);

        ISpecificationWithParams<Match> GetMatchIdBaseFilterQuery(int? matchId);

        ISpecificationWithParams<PlayoffRoundCouple> GetPlayoffRoundCoupleFilterQuery(int? tournamentId, int? playoffRound);

        ISpecificationWithParams<PlayoffRoundCouple> GetPlayoffRoundCoupleBaseFilterQuery(int? tournamentId, int? playoffRound);
    }
}
