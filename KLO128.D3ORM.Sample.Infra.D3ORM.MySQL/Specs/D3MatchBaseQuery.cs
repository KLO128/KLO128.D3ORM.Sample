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
    public class D3MatchBaseQuery : D3Specification<Match>
    {
        public D3MatchBaseQuery(ID3Context D3Context) : base(D3Context)
        {
        }

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?> { typeof(Match).GetProperty(nameof(Match.HomeTeam)), typeof(Match).GetProperty(nameof(Match.AwayTeam)), typeof(Match).GetProperty(nameof(Match.MatchSetScores)), typeof(Match).GetProperty(nameof(Match.Tournament)), typeof(Tournament).GetProperty(nameof(Tournament.TourSerie)) };

		public override string? SortAppendix { get; protected set; } = "`match`.tournament_id, `match`.match_id, join1_match_set_score.set_order";

        public override Func<ID3Context, object?[], D3Specification<Match>> CloneNewFunc { get; } = (x, y) => new D3MatchBaseQuery(x);

		protected override string? BaseSQL { get; set; } = @"SELECT
	`match`.`match_id` AS '.MatchId'
	, `match`.`home_team_id` AS '.HomeTeamId'
	, `match`.`away_team_id` AS '.AwayTeamId'
	, `match`.`tournament_id` AS '.TournamentId'
	, `match`.`tournament_phase` AS '.TournamentPhase'
	, `match`.`winner_id` AS '.WinnerId'
	, `match`.`referee_id` AS '.RefereeId'
	, `match`.`match_date` AS '.MatchDate'
	, `match`.`last_change` AS '.LastChange'
	, `match`.`changed_by` AS '.ChangedBy'
	, `join1_team`.`team_id` AS 'HomeTeam(Team).TeamId'
	, `join1_team`.`name` AS 'HomeTeam(Team).Name'
	, `join1_team`.`logo` AS 'HomeTeam(Team).Logo'
	, `join1_team`.`registration_date` AS 'HomeTeam(Team).RegistrationDate'
	, `join1_team`.`active` AS 'HomeTeam(Team).Active'
	, `join1_team`.`last_change` AS 'HomeTeam(Team).LastChange'
	, `join1_team`.`changed_by` AS 'HomeTeam(Team).ChangedBy'
	, `join2_team`.`team_id` AS 'AwayTeam(Team).TeamId'
	, `join2_team`.`name` AS 'AwayTeam(Team).Name'
	, `join2_team`.`logo` AS 'AwayTeam(Team).Logo'
	, `join2_team`.`registration_date` AS 'AwayTeam(Team).RegistrationDate'
	, `join2_team`.`active` AS 'AwayTeam(Team).Active'
	, `join2_team`.`last_change` AS 'AwayTeam(Team).LastChange'
	, `join2_team`.`changed_by` AS 'AwayTeam(Team).ChangedBy'
	, `join1_match_set_score`.`match_set_score_id` AS 'MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `join1_match_set_score`.`match_id` AS 'MatchSetScores[MatchSetScore].MatchId'
	, `join1_match_set_score`.`home_team_score` AS 'MatchSetScores[MatchSetScore].HomeTeamScore'
	, `join1_match_set_score`.`away_team_score` AS 'MatchSetScores[MatchSetScore].AwayTeamScore'
	, `join1_match_set_score`.`set_order` AS 'MatchSetScores[MatchSetScore].SetOrder'
	, `join1_match_set_score`.`last_change` AS 'MatchSetScores[MatchSetScore].LastChange'
	, `join1_match_set_score`.`changed_by` AS 'MatchSetScores[MatchSetScore].ChangedBy'
	, `join1_tournament`.`tournament_id` AS 'Tournament.TournamentId'
	, `join1_tournament`.`tour_serie_id` AS 'Tournament.TourSerieId'
	, `join1_tournament`.`address_id` AS 'Tournament.AddressId'
	, `join1_tournament`.`name` AS 'Tournament.Name'
	, `join1_tournament`.`start_date` AS 'Tournament.StartDate'
	, `join1_tournament`.`end_date` AS 'Tournament.EndDate'
	, `join1_tournament`.`entry_fee` AS 'Tournament.EntryFee'
	, `join1_tournament`.`max_num_of_teams` AS 'Tournament.MaxNumOfTeams'
	, `join1_tournament`.`note` AS 'Tournament.Note'
	, `join1_tournament`.`last_change` AS 'Tournament.LastChange'
	, `join1_tournament`.`changed_by` AS 'Tournament.ChangedBy'
	, `join1_tour_serie`.`tour_serie_id` AS 'Tournament.TourSerie.TourSerieId'
	, `join1_tour_serie`.`name` AS 'Tournament.TourSerie.Name'
	, `join1_tour_serie`.`start_date` AS 'Tournament.TourSerie.StartDate'
	, `join1_tour_serie`.`end_date` AS 'Tournament.TourSerie.EndDate'
	, `join1_tour_serie`.`category` AS 'Tournament.TourSerie.Category'
	, `join1_tour_serie`.`note` AS 'Tournament.TourSerie.Note'
	, `join1_tour_serie`.`last_change` AS 'Tournament.TourSerie.LastChange'
	, `join1_tour_serie`.`changed_by` AS 'Tournament.TourSerie.ChangedBy'
 FROM `match` `match`
LEFT JOIN `team` `join1_team` ON `match`.`home_team_id` = `join1_team`.`team_id`
LEFT JOIN `team` `join2_team` ON `match`.`away_team_id` = `join2_team`.`team_id`
LEFT JOIN `match_set_score` `join1_match_set_score` ON `match`.`match_id` = `join1_match_set_score`.`match_id`
LEFT JOIN `tournament` `join1_tournament` ON `match`.`tournament_id` = `join1_tournament`.`tournament_id`
LEFT JOIN `tour_serie` `join1_tour_serie` ON `join1_tournament`.`tour_serie_id` = `join1_tour_serie`.`tour_serie_id`

";

        protected override string LocalFilterExpression { get; } = string.Empty;
    }
}
