using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Repositories;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Domain.Services.Impl
{
    public class MatchDomainService : IMatchDomainService
    {
        public IQueryContainer QC { get; set; }
        private ITournamentRepository TournamentRepository { get; set; }

        private ITeamRepository TeamRepository { get; set; }

        private IMatchRepository MatchRepository { get; set; }

        private IMatchSetScoreRepository MatchSetScoreRepository { get; set; }

        public MatchDomainService(IQueryContainer QC, ITournamentRepository TournamentRepository, ITeamRepository TeamRepository, IMatchRepository MatchRepository, IMatchSetScoreRepository MatchSetScoreRepository)
        {
            this.QC = QC;
            this.TournamentRepository = TournamentRepository;
            this.TeamRepository = TeamRepository;
            this.MatchRepository = MatchRepository;
            this.MatchSetScoreRepository = MatchSetScoreRepository;
        }

        public Match AddMatch(Team homeTeam, Team awayTeam, int? tournamentId, int tournamentPhase, int changedById)
        {
            var tournament = tournamentId == null ? null : TournamentRepository.FindBy(QC.GetTournamenIdBaseFilterQuery(tournamentId ?? 0));

            if (tournament != null)
            {
                if (tournament.TournamentTeams.FirstOrDefault(x => x.TeamId == homeTeam.TeamId) is not TournamentTeam)
                {
                    throw Errors.GetTeamNotRegisteredToTournament(homeTeam.Name, tournament.Name);
                }
                else if (tournament.TournamentTeams.FirstOrDefault(x => x.TeamId == awayTeam.TeamId) is not TournamentTeam)
                {
                    throw Errors.GetTeamNotRegisteredToTournament(awayTeam.Name, tournament.Name);
                }
            }
            else if ((tournamentId ?? 0) != 0)
            {
                throw Errors.GetTournamentNotFound(tournamentId?.ToString() ?? "0");
            }

            var match = new Match
            {
                AwayTeamId = awayTeam.TeamId,
                HomeTeamId = homeTeam.TeamId,
                AwayTeam = awayTeam,
                HomeTeam = homeTeam,
                TournamentId = tournamentId,
                Tournament = tournament,
                ChangedBy = changedById,
                LastChange = DateTime.UtcNow,
                TournamentPhase = tournamentPhase
            };

            MatchRepository.AddRoot(match);

            return match;
        }

        public Match AddMatch(int homeTeamId, int awayTeamId, int? tournamentId, int tournamentPhase, int changedById)
        {
            var homeTeam = TeamRepository.FindByIdSingle(homeTeamId);

            if (homeTeam == null)
            {
                throw Errors.GetTeamNotFound(homeTeamId.ToString());
            }

            var awayTeam = TeamRepository.FindByIdSingle(awayTeamId);

            if (awayTeam == null)
            {
                throw Errors.GetTeamNotFound(awayTeamId.ToString());
            }

            return AddMatch(homeTeam, awayTeam, tournamentId, tournamentPhase, changedById);
        }

        public Match AddMatchSetScore(int matchId, int setOrder, int homeTeamScore, int awayTeamScore, int changedById)
        {
            var match = MatchRepository.FindByIdSingle(matchId);

            if (match == null)
            {
                throw Errors.GetMatchNotFound(matchId.ToString());
            }

            return AddMatchSetScore(match, setOrder, homeTeamScore, awayTeamScore, changedById);
        }

        public Match AddMatchSetScore(Match match, int setOrder, int homeTeamScore, int awayTeamScore, int changedById)
        {
            var now = DateTime.UtcNow;

            var score = new MatchSetScore
            {
                AwayTeamScore = awayTeamScore,
                ChangedBy = changedById,
                MatchId = match.MatchId,
                HomeTeamScore = homeTeamScore,
                LastChange = now,
                SetOrder = setOrder
            };

            MatchSetScoreRepository.AddAsChild(match, x => x.MatchSetScores, score);

            return match;
        }

        public Match UpdateMatchSetScore(int matchId, int setOrder, int homeTeamScore, int awayTeamScore, int changedBy)
        {
            var match = MatchRepository.FindBy(QC.GetMatchIdBaseFilterQuery(matchId));

            if (match == null)
            {
                throw Errors.GetMatchNotFound(matchId.ToString());
            }

            return UpdateMatchSetScore(match, setOrder, homeTeamScore, awayTeamScore, changedBy);
        }

        public Match UpdateMatchSetScore(Match match, int setOrder, int homeTeamScore, int awayTeamScore, int changedBy)
        {
            var score = match.MatchSetScores.FirstOrDefault(x => x.SetOrder == setOrder);

            if (score == null)
            {
                throw Errors.GetMatchSetNotFound(setOrder);
            }

            MatchSetScoreRepository.UpdateProperties(score, x => x.HomeTeamScore, homeTeamScore, x => x.AwayTeamScore, awayTeamScore, x => x.LastChange, DateTime.UtcNow, x => x.ChangedBy, changedBy);

            return match;
        }

        public List<Match> GetMatches(int? tournamentId, int? teamId, int? tournamentPhase)
        {
            if (tournamentId == null && teamId == null)
            {
                throw Errors.EmptyFilter();
            }

            return MatchRepository.FindManyBy(QC.GetMatchBaseTournamentPhaseAndTeamIdFilterQuery(tournamentId, teamId, tournamentPhase));
        }
    }
}
