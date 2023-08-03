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
    public class D3TournamentBaseQuery : D3Specification<Tournament>
    {
        public D3TournamentBaseQuery(ID3Context D3Context) : base(D3Context, new object[0])
        {
        }

        public override Func<ID3Context, object?[], D3Specification<Tournament>> CloneNewFunc => (x, y) => new D3TournamentBaseQuery(x);

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?> { typeof(Tournament).GetProperty(nameof(Tournament.TourSerie)), typeof(Tournament).GetProperty(nameof(Tournament.TournamentTeams)), typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.TournamentTeamStats)) };

		public override string? SortAppendix { get; protected set; } = "tournament.`name` DESC";

        protected override string? BaseSQL { get; set; } = @"SELECT
	`tournament`.`tournament_id` AS '.TournamentId'
	, `tournament`.`tour_serie_id` AS '.TourSerieId'
	, `tournament`.`address_id` AS '.AddressId'
	, `tournament`.`name` AS '.Name'
	, `tournament`.`start_date` AS '.StartDate'
	, `tournament`.`end_date` AS '.EndDate'
	, `tournament`.`entry_fee` AS '.EntryFee'
	, `tournament`.`max_num_of_teams` AS '.MaxNumOfTeams'
	, `tournament`.`note` AS '.Note'
	, `tournament`.`last_change` AS '.LastChange'
	, `tournament`.`changed_by` AS '.ChangedBy'
	, `join1_tour_serie`.`tour_serie_id` AS 'TourSerie.TourSerieId'
	, `join1_tour_serie`.`name` AS 'TourSerie.Name'
	, `join1_tour_serie`.`start_date` AS 'TourSerie.StartDate'
	, `join1_tour_serie`.`end_date` AS 'TourSerie.EndDate'
	, `join1_tour_serie`.`category` AS 'TourSerie.Category'
	, `join1_tour_serie`.`note` AS 'TourSerie.Note'
	, `join1_tour_serie`.`last_change` AS 'TourSerie.LastChange'
	, `join1_tour_serie`.`changed_by` AS 'TourSerie.ChangedBy'
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
 FROM `tournament` `tournament`
LEFT JOIN `tour_serie` `join1_tour_serie` ON `tournament`.`tour_serie_id` = `join1_tour_serie`.`tour_serie_id`
LEFT JOIN `tournament_team` `join1_tournament_team` ON `tournament`.`tournament_id` = `join1_tournament_team`.`tournament_id`
LEFT JOIN `tournament_team_stat` `join1_tournament_team_stat` ON `join1_tournament_team`.`tournament_team_id` = `join1_tournament_team_stat`.`tournament_team_id`

";

        protected override string LocalFilterExpression { get; } = string.Empty;
    }
}
