using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Application.Contracts.Services;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Repositories;
using KLO128.D3ORM.Sample.Domain.Services;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Application.Web
{
    public class MatchWebService : IMatchService
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public IQueryContainer QC { get; set; }

        public IUserDomainService UserDomainService { get; set; }

        public ITeamDomainService TeamDomainService { get; set; }

        public IMatchDomainService MatchDomainService { get; set; }

        public IMatchRepository MatchRepository { get; set; }

        public ITournamentTeamStatRepository TournamentTeamStatRepository { get; set; }

        public MatchWebService(IUnitOfWork UnitOfWork, IQueryContainer QC, IUserDomainService UserDomainService, ITeamDomainService TeamDomainService, IMatchDomainService MatchDomainService, IMatchRepository MatchRepository, ITournamentTeamStatRepository TournamentTeamStatRepository)
        {
            this.UnitOfWork = UnitOfWork;
            this.QC = QC;
            this.UserDomainService = UserDomainService;
            this.TeamDomainService = TeamDomainService;
            this.MatchDomainService = MatchDomainService;
            this.MatchRepository = MatchRepository;
            this.TournamentTeamStatRepository = TournamentTeamStatRepository;
        }

        public ServiceResult<MatchDTO> AddMatch(AddMatchArgs args, int signedInUserId, bool authorize)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                Helpers.Authorize<MatchDTO>(UserDomainService, signedInUserId, Roles.Admin, authorize);

                var match = MatchDomainService.AddMatch(args.HomeTeamId, args.AwayTeamId, args.TournamentId, args.TournamentPhase, signedInUserId);

                return match.ToDTO<MatchDTO>();
            });

        }

        public ServiceResult<MatchDTO> AddMatchSetScore(AddMatchSetScoreArgs args, int signedInUserId, bool authorize)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                Helpers.Authorize<MatchDTO>(UserDomainService, signedInUserId, Roles.Admin, authorize);

                var match = MatchDomainService.AddMatchSetScore(args.MatchId, args.SetOrder, args.HomeTeamScore, args.AwayTeamScore, signedInUserId);

                return match.ToDTO<MatchDTO>();
            });
        }

        public ServiceResult<List<MatchDTO>> GetMatches(int? tournamentId, int? teamId, int? tournamentPhase)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                var matches = MatchDomainService.GetMatches(tournamentId, teamId, tournamentPhase);

                var ret = new List<MatchDTO>();

                foreach (var item in matches)
                {
                    ret.Add(item.ToDTO<MatchDTO>());
                }

                return ret;
            });
        }

        public ServiceResult<MatchDTO> UpdateMatchSetScoreTransact(UpdateMatchSetScoreArgs args, int signedInUserId, bool authorize)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => UpdateMatchSetScoreUnsafe(args, signedInUserId, authorize)));
        }

        public MatchDTO UpdateMatchSetScoreUnsafe(UpdateMatchSetScoreArgs args, int signedInUserId, bool authorize)
        {
            Helpers.Authorize<MatchDTO>(UserDomainService, signedInUserId, Roles.Admin, authorize);

            var result = MatchDomainService.UpdateMatchSetScore(args.MatchId, args.SetOrder, args.HomeTeamScore, args.AwayTeamScore, signedInUserId);

            return result.ToDTO<MatchDTO>();
        }

        public ServiceResult<MatchDTO> EndMatchTransact(EndMatchArgs args, int signedInUserId, bool authorize)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => EndMatchUnsafe(args, signedInUserId, authorize)));
        }

        public MatchDTO EndMatchUnsafe(EndMatchArgs args, int signedInUserId, bool authorize)
        {
            Helpers.Authorize<MatchDTO>(UserDomainService, signedInUserId, Roles.Admin, authorize);

            var match = MatchRepository.FindBy(QC.GetMatchIdBaseFilterQuery(args.MatchId));

            if (match == null)
            {
                throw Errors.GetMatchNotFound(args.MatchId.ToString());
            }

            int winnerId;
            var homeSetWins = match.MatchSetScores.Count(x => x.HomeTeamScore > x.AwayTeamScore);
            var awaySetWins = match.MatchSetScores.Count(x => x.HomeTeamScore < x.AwayTeamScore);

            if (homeSetWins == awaySetWins)
            {
                winnerId = 0;
            }
            else if (homeSetWins > awaySetWins)
            {
                winnerId = match.HomeTeamId;
            }
            else
            {
                winnerId = match.AwayTeamId;
            }

            MatchRepository.UpdateProperties(match, x => x.WinnerId, winnerId);

            if (!UpdateTeamStats(match, match.HomeTeamId, true, winnerId, signedInUserId))
            {
                throw Errors.GetTeamNotFound(match.HomeTeamId.ToString());
            }
            else if (!UpdateTeamStats(match, match.AwayTeamId, false, winnerId, signedInUserId))
            {
                throw Errors.GetTeamNotFound(match.AwayTeamId.ToString());
            }

            return match.ToDTO<MatchDTO>();
        }

        private bool UpdateTeamStats(Match match, int teamId, bool isHomeTeam, int winnerId, int changedBy)
        {
            var result = TeamDomainService.GetTeamAndStats(teamId, match.TournamentId, match.TournamentPhase);
            var teamStats = result?.TournamentTeams.FirstOrDefault()?.TournamentTeamStats.FirstOrDefault();

            if (teamStats == null)
            {
                return false;
            }

            var homeSetWins = match.MatchSetScores.Count(x => x.HomeTeamScore > x.AwayTeamScore);
            var awaySetWins = match.MatchSetScores.Count(x => x.HomeTeamScore < x.AwayTeamScore);

            var homeScore = match.MatchSetScores.Sum(x => x.HomeTeamScore);
            var awayScore = match.MatchSetScores.Sum(x => x.AwayTeamScore);

            if (teamId == winnerId)
            {
                teamStats.Wins++;
                teamStats.PhasePoints += isHomeTeam && awaySetWins > 0 ? 2 : !isHomeTeam && homeSetWins > 0 ? 2 : 3;
            }
            else if (winnerId == 0)
            {
                teamStats.Ties++;
                teamStats.PhasePoints++;
            }
            else
            {
                teamStats.Losts++;
                teamStats.PhasePoints += isHomeTeam && homeSetWins > 0 ? 1 : !isHomeTeam && awaySetWins > 0 ? 1 : 0;
            }

            teamStats.SetsWon += isHomeTeam ? homeSetWins : awaySetWins;
            teamStats.SetsLost += !isHomeTeam ? homeSetWins : awaySetWins;
            teamStats.ScorePlus += isHomeTeam ? homeScore : awayScore;
            teamStats.ScoreMinus += !isHomeTeam ? homeScore : awayScore;
            teamStats.LastChange = DateTime.UtcNow;
            teamStats.ChangedBy = changedBy;

            TournamentTeamStatRepository.UpdateEntity(teamStats);

            return true;
        }
    }
}
