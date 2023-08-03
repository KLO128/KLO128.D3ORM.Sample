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
    public class D3TeamBaseQuery : D3Specification<Team>
    {
        public D3TeamBaseQuery(ID3Context D3Context) : base(D3Context)
        {
        }

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?> { typeof(Team).GetProperty(nameof(Team.TeamPlayers)), typeof(Team).GetProperty(nameof(Team.TournamentTeams)), typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.TournamentTeamStats)) };

		public override string? SortAppendix { get; protected set; } = "team.[Name]";

		public override Func<ID3Context, object?[], D3Specification<Team>> CloneNewFunc { get; } = (x, y) => new D3TeamBaseQuery(x);

		protected override string? BaseSQL { get; set; } = @"SELECT
	[team].[TeamId] AS '.TeamId'
	, [team].[Name] AS '.Name'
	, [team].[Logo] AS '.Logo'
	, [team].[RegistrationDate] AS '.RegistrationDate'
	, [team].[Active] AS '.Active'
	, [team].[LastChange] AS '.LastChange'
	, [team].[ChangedBy] AS '.ChangedBy'
	, [join1_teamPlayer].[TeamPlayerId] AS 'TeamPlayers[TeamPlayer].TeamPlayerId'
	, [join1_teamPlayer].[TeamId] AS 'TeamPlayers[TeamPlayer].TeamId'
	, [join1_teamPlayer].[PlayerId] AS 'TeamPlayers[TeamPlayer].PlayerId'
	, [join1_teamPlayer].[LastChange] AS 'TeamPlayers[TeamPlayer].LastChange'
	, [join1_teamPlayer].[ChangedBy] AS 'TeamPlayers[TeamPlayer].ChangedBy'
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
 FROM [Team] [team]
LEFT JOIN [TeamPlayer] [join1_teamPlayer] ON [team].[TeamId] = [join1_teamPlayer].[TeamId]
LEFT JOIN [TournamentTeam] [join1_tournamentTeam] ON [team].[TeamId] = [join1_tournamentTeam].[TeamId]
LEFT JOIN [TournamentTeamStat] [join1_tournamentTeamStat] ON [join1_tournamentTeam].[TournamentTeamId] = [join1_tournamentTeamStat].[TournamentTeamId]

";

        protected override string LocalFilterExpression { get; } = string.Empty;
    }
}
