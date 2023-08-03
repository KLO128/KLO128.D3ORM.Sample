using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.MySQL.Specs
{
    public class D3TeamBaseQuery : D3Specification<Team>
    {
        public D3TeamBaseQuery(ID3Context D3Context) : base(D3Context)
        {
        }

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?> { typeof(Team).GetProperty(nameof(Team.TeamPlayers)), typeof(Team).GetProperty(nameof(Team.TournamentTeams)), typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.TournamentTeamStats)) };

		public override string? SortAppendix { get; protected set; } = "team.`name`";

		public override Func<ID3Context, object?[], D3Specification<Team>> CloneNewFunc { get; } = (x, y) => new D3TeamBaseQuery(x);

		protected override string? BaseSQL { get; set; } = @"SELECT
	`team`.`team_id` AS '.TeamId'
	, `team`.`name` AS '.Name'
	, `team`.`logo` AS '.Logo'
	, `team`.`registration_date` AS '.RegistrationDate'
	, `team`.`active` AS '.Active'
	, `team`.`last_change` AS '.LastChange'
	, `team`.`changed_by` AS '.ChangedBy'
	, `join1_team_player`.`team_player_id` AS 'TeamPlayers[TeamPlayer].TeamPlayerId'
	, `join1_team_player`.`team_id` AS 'TeamPlayers[TeamPlayer].TeamId'
	, `join1_team_player`.`player_id` AS 'TeamPlayers[TeamPlayer].PlayerId'
	, `join1_team_player`.`last_change` AS 'TeamPlayers[TeamPlayer].LastChange'
	, `join1_team_player`.`changed_by` AS 'TeamPlayers[TeamPlayer].ChangedBy'
	, `join1_tournament_team`.`tournament_team_id` AS 'TournamentTeams[TournamentTeam].TournamentTeamId'
	, `join1_tournament_team`.`tournament_id` AS 'TournamentTeams[TournamentTeam].TournamentId'
	, `join1_tournament_team`.`team_id` AS 'TournamentTeams[TournamentTeam].TeamId'
	, `join1_tournament_team`.`basic_group_name` AS 'TournamentTeams[TournamentTeam].BasicGroupName'
	, `join1_tournament_team`.`registration_date` AS 'TournamentTeams[TournamentTeam].RegistrationDate'
	, `join1_tournament_team`.`entry_fee_paid` AS 'TournamentTeams[TournamentTeam].EntryFeePaid'
	, `join1_tournament_team`.`last_change` AS 'TournamentTeams[TournamentTeam].LastChange'
	, `join1_tournament_team`.`changed_by` AS 'TournamentTeams[TournamentTeam].ChangedBy'
	, `join1_tournament_team_stat`.`tournament_team_stat_id` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `join1_tournament_team_stat`.`tournament_team_id` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `join1_tournament_team_stat`.`tournament_phase` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `join1_tournament_team_stat`.`phase_points` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `join1_tournament_team_stat`.`wins` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Wins'
	, `join1_tournament_team_stat`.`losts` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Losts'
	, `join1_tournament_team_stat`.`ties` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Ties'
	, `join1_tournament_team_stat`.`sets_won` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `join1_tournament_team_stat`.`sets_lost` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `join1_tournament_team_stat`.`score_plus` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `join1_tournament_team_stat`.`score_minus` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `join1_tournament_team_stat`.`last_change` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].LastChange'
	, `join1_tournament_team_stat`.`changed_by` AS 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ChangedBy'
 FROM `team` `team`
LEFT JOIN `team_player` `join1_team_player` ON `team`.`team_id` = `join1_team_player`.`team_id`
LEFT JOIN `tournament_team` `join1_tournament_team` ON `team`.`team_id` = `join1_tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `join1_tournament_team_stat` ON `join1_tournament_team`.`tournament_team_id` = `join1_tournament_team_stat`.`tournament_team_id`

";

        protected override string LocalFilterExpression { get; } = string.Empty;
    }
}
