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
    public class D3TournamentBaseQuery : D3Specification<Tournament>
    {
        public D3TournamentBaseQuery(ID3Context D3Context) : base(D3Context, new object[0])
        {
        }

        public override Func<ID3Context, object?[], D3Specification<Tournament>> CloneNewFunc => (x, y) => new D3TournamentBaseQuery(x);

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?> { typeof(Tournament).GetProperty(nameof(Tournament.TourSerie)), typeof(Tournament).GetProperty(nameof(Tournament.TournamentTeams)), typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.TournamentTeamStats)) };

		public override string? SortAppendix { get; protected set; } = "tournament.[Name]";

        protected override string? BaseSQL { get; set; } = @"SELECT
	[tournament].[TournamentId] AS '.TournamentId'
	, [tournament].[TourSerieId] AS '.TourSerieId'
	, [tournament].[AddressId] AS '.AddressId'
	, [tournament].[Name] AS '.Name'
	, [tournament].[StartDate] AS '.StartDate'
	, [tournament].[EndDate] AS '.EndDate'
	, [tournament].[EntryFee] AS '.EntryFee'
	, [tournament].[MaxNumOfTeams] AS '.MaxNumOfTeams'
	, [tournament].[Note] AS '.Note'
	, [tournament].[LastChange] AS '.LastChange'
	, [tournament].[ChangedBy] AS '.ChangedBy'
	, [join1_tourSerie].[TourSerieId] AS 'TourSerie.TourSerieId'
	, [join1_tourSerie].[Name] AS 'TourSerie.Name'
	, [join1_tourSerie].[StartDate] AS 'TourSerie.StartDate'
	, [join1_tourSerie].[EndDate] AS 'TourSerie.EndDate'
	, [join1_tourSerie].[Category] AS 'TourSerie.Category'
	, [join1_tourSerie].[Note] AS 'TourSerie.Note'
	, [join1_tourSerie].[LastChange] AS 'TourSerie.LastChange'
	, [join1_tourSerie].[ChangedBy] AS 'TourSerie.ChangedBy'
	, [join1_tournamentTeam].[TournamentTeamId] AS 'TournamentTeams[TournamentTeam].TournamentTeamId'
	, [join1_tournamentTeam].[TournamentId] AS 'TournamentTeams[TournamentTeam].TournamentId'
	, [join1_tournamentTeam].[TeamId] AS 'TournamentTeams[TournamentTeam].TeamId'
	, [join1_tournamentTeam].[BasicGroupName] AS 'TournamentTeams[TournamentTeam].BasicGroupName'
	, [join1_tournamentTeam].[RegistrationDate] AS 'TournamentTeams[TournamentTeam].RegistrationDate'
	, [join1_tournamentTeam].[EntryFeePaid] AS 'TournamentTeams[TournamentTeam].EntryFeePaid'
	, [join1_tournamentTeam].[LastChange] AS 'TournamentTeams[TournamentTeam].LastChange'
	, [join1_tournamentTeam].[ChangedBy] AS 'TournamentTeams[TournamentTeam].ChangedBy'
	, [join1_tournamentTeamStat].[TournamentTeamStatId] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, [join1_tournamentTeamStat].[TournamentTeamId] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, [join1_tournamentTeamStat].[TournamentPhase] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, [join1_tournamentTeamStat].[PhasePoints] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, [join1_tournamentTeamStat].[Wins] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Wins'
	, [join1_tournamentTeamStat].[Losts] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Losts'
	, [join1_tournamentTeamStat].[Ties] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Ties'
	, [join1_tournamentTeamStat].[SetsWon] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsWon'
	, [join1_tournamentTeamStat].[SetsLost] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsLost'
	, [join1_tournamentTeamStat].[ScorePlus] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, [join1_tournamentTeamStat].[ScoreMinus] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, [join1_tournamentTeamStat].[LastChange] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].LastChange'
	, [join1_tournamentTeamStat].[ChangedBy] AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ChangedBy'
 FROM [Tournament] [tournament]
LEFT JOIN [TourSerie] [join1_tourSerie] ON [tournament].[TourSerieId] = [join1_tourSerie].[TourSerieId]
LEFT JOIN [TournamentTeam] [join1_tournamentTeam] ON [tournament].[TournamentId] = [join1_tournamentTeam].[TournamentId]
LEFT JOIN [TournamentTeamStat] [join1_tournamentTeamStat] ON [join1_tournamentTeam].[TournamentTeamId] = [join1_tournamentTeamStat].[TournamentTeamId]

";

        protected override string LocalFilterExpression { get; } = string.Empty;
    }
}
