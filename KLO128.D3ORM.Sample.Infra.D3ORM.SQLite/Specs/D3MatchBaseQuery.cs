using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.SQLite.Specs
{
    public class D3MatchBaseQuery : D3Specification<Match>
    {
        public D3MatchBaseQuery(ID3Context D3Context) : base(D3Context)
        {
        }

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?> { typeof(Match).GetProperty(nameof(Match.HomeTeam)), typeof(Match).GetProperty(nameof(Match.AwayTeam)), typeof(Match).GetProperty(nameof(Match.MatchSetScores)), typeof(Match).GetProperty(nameof(Match.Tournament)), typeof(Tournament).GetProperty(nameof(Tournament.TourSerie)) };

		public override string? SortAppendix { get; protected set; } = "[match].TournamentId, [match].MatchId, join1_matchSetScore.SetOrder";

        public override Func<ID3Context, object?[], D3Specification<Match>> CloneNewFunc { get; } = (x, y) => new D3MatchBaseQuery(x);

		protected override string? BaseSQL { get; set; } = @"SELECT
	[match].[MatchId] AS '.MatchId'
	, [match].[HomeTeamId] AS '.HomeTeamId'
	, [match].[AwayTeamId] AS '.AwayTeamId'
	, [match].[TournamentId] AS '.TournamentId'
	, [match].[TournamentPhase] AS '.TournamentPhase'
	, [match].[WinnerId] AS '.WinnerId'
	, [match].[RefereeId] AS '.RefereeId'
	, [match].[MatchDate] AS '.MatchDate'
	, [match].[LastChange] AS '.LastChange'
	, [match].[ChangedBy] AS '.ChangedBy'
	, [join1_team].[TeamId] AS 'HomeTeam(Team).TeamId'
	, [join1_team].[Name] AS 'HomeTeam(Team).Name'
	, [join1_team].[Logo] AS 'HomeTeam(Team).Logo'
	, [join1_team].[RegistrationDate] AS 'HomeTeam(Team).RegistrationDate'
	, [join1_team].[Active] AS 'HomeTeam(Team).Active'
	, [join1_team].[LastChange] AS 'HomeTeam(Team).LastChange'
	, [join1_team].[ChangedBy] AS 'HomeTeam(Team).ChangedBy'
	, [join2_team].[TeamId] AS 'AwayTeam(Team).TeamId'
	, [join2_team].[Name] AS 'AwayTeam(Team).Name'
	, [join2_team].[Logo] AS 'AwayTeam(Team).Logo'
	, [join2_team].[RegistrationDate] AS 'AwayTeam(Team).RegistrationDate'
	, [join2_team].[Active] AS 'AwayTeam(Team).Active'
	, [join2_team].[LastChange] AS 'AwayTeam(Team).LastChange'
	, [join2_team].[ChangedBy] AS 'AwayTeam(Team).ChangedBy'
	, [join1_matchSetScore].[MatchSetScoreId] AS 'MatchSetScores[MatchSetScore].MatchSetScoreId'
	, [join1_matchSetScore].[MatchId] AS 'MatchSetScores[MatchSetScore].MatchId'
	, [join1_matchSetScore].[HomeTeamScore] AS 'MatchSetScores[MatchSetScore].HomeTeamScore'
	, [join1_matchSetScore].[AwayTeamScore] AS 'MatchSetScores[MatchSetScore].AwayTeamScore'
	, [join1_matchSetScore].[SetOrder] AS 'MatchSetScores[MatchSetScore].SetOrder'
	, [join1_matchSetScore].[LastChange] AS 'MatchSetScores[MatchSetScore].LastChange'
	, [join1_matchSetScore].[ChangedBy] AS 'MatchSetScores[MatchSetScore].ChangedBy'
	, [join1_tournament].[TournamentId] AS 'Tournament.TournamentId'
	, [join1_tournament].[TourSerieId] AS 'Tournament.TourSerieId'
	, [join1_tournament].[AddressId] AS 'Tournament.AddressId'
	, [join1_tournament].[Name] AS 'Tournament.Name'
	, [join1_tournament].[StartDate] AS 'Tournament.StartDate'
	, [join1_tournament].[EndDate] AS 'Tournament.EndDate'
	, [join1_tournament].[EntryFee] AS 'Tournament.EntryFee'
	, [join1_tournament].[MaxNumOfTeams] AS 'Tournament.MaxNumOfTeams'
	, [join1_tournament].[Note] AS 'Tournament.Note'
	, [join1_tournament].[LastChange] AS 'Tournament.LastChange'
	, [join1_tournament].[ChangedBy] AS 'Tournament.ChangedBy'
	, [join1_tourSerie].[TourSerieId] AS 'Tournament.TourSerie.TourSerieId'
	, [join1_tourSerie].[Name] AS 'Tournament.TourSerie.Name'
	, [join1_tourSerie].[StartDate] AS 'Tournament.TourSerie.StartDate'
	, [join1_tourSerie].[EndDate] AS 'Tournament.TourSerie.EndDate'
	, [join1_tourSerie].[Category] AS 'Tournament.TourSerie.Category'
	, [join1_tourSerie].[Note] AS 'Tournament.TourSerie.Note'
	, [join1_tourSerie].[LastChange] AS 'Tournament.TourSerie.LastChange'
	, [join1_tourSerie].[ChangedBy] AS 'Tournament.TourSerie.ChangedBy'
 FROM [Match] [match]
LEFT JOIN [Team] [join1_team] ON [match].[HomeTeamId] = [join1_team].[TeamId]
LEFT JOIN [Team] [join2_team] ON [match].[AwayTeamId] = [join2_team].[TeamId]
LEFT JOIN [MatchSetScore] [join1_matchSetScore] ON [match].[MatchId] = [join1_matchSetScore].[MatchId]
LEFT JOIN [Tournament] [join1_tournament] ON [match].[TournamentId] = [join1_tournament].[TournamentId]
LEFT JOIN [TourSerie] [join1_tourSerie] ON [join1_tournament].[TourSerieId] = [join1_tourSerie].[TourSerieId]

";

        protected override string LocalFilterExpression { get; } = string.Empty;
    }
}
