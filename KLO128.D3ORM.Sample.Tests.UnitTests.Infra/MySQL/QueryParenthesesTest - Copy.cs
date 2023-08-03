using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.MySQL;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Infra.D3ORM.MySQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KLO128.Tests.UnitTests.D3ORM.Sample.Infra.MySQL
{
	[TestClass]
	public class QueryParenthesesTest
	{
		public ID3Context D3Context { get; set; } = new MySQLD3Context(EntityPropMappings.Dict);

		[TestMethod]
		public void QueryParentheses_Example1()
		{
			var query1 = D3Specification.Create<PlayoffRoundCouple>(D3Context)
	.And(D3Specification.Create(D3Context, (PlayoffRoundCouple x) => x.TournamentTeam1)
		.And(D3Specification.Create<Tournament>(D3Context).OrderBy(x => x.TournamentId, true, 1)
			.And(D3Specification.Create<TourSerie>(D3Context)))
		.And(D3Specification.Create<Team>(D3Context)
					.And(D3Specification.Create<TeamPlayer>(D3Context))
					.And(D3Specification.Create<User>(D3Context))
					.And(D3Specification.Create<TournamentTeam>(D3Context))
					.And(D3Specification.Create<TournamentTeamStat>(D3Context))
					.OrderBy(x => x.Name).OrderBy(x => x.Name, true, 3))).And(D3Specification.Create<Team>(D3Context).Compare(x => x.Name, ComparisonOp.EQUALS, "Team1").Compare(x => x.Name, ComparisonOp.EQUALS, "Team2", LogicalOp.OR))
	/*missing 2 closing parentheses -> we join the filter to top context, which leads to unnecessary filter part that could be omitted. */
	.And(D3Specification.Create(D3Context, (PlayoffRoundCouple x) => x.TournamentTeam2)
			.And(D3Specification.Create<Team>(D3Context)
					.And(D3Specification.Create<TeamPlayer>(D3Context))
					.And(D3Specification.Create<User>(D3Context))
					.And(D3Specification.Create<TournamentTeam>(D3Context))
					.And(D3Specification.Create<TournamentTeamStat>(D3Context))
					.OrderBy(x => x.Name).OrderBy(x => x.Name, true, 3))).And(D3Specification.Create<Team>(D3Context).Compare(x => x.Name, ComparisonOp.EQUALS, "Team3").Compare(x => x.Name, ComparisonOp.EQUALS, "Team4", LogicalOp.OR))
	.And(D3Specification.Create<Match>(D3Context).OrderBy(x => x.MatchId, false, 7)
		.And(D3Specification.Create<MatchSetScore>(D3Context).OrderBy(x => x.SetOrder)));

			var str1 = query1.GetSQL(false);

			Assertion.AssertStrings(ExpectedQuery1, str1);

			var query2 = D3Specification.Create<PlayoffRoundCouple>(D3Context)
.And(D3Specification.Create(D3Context, (PlayoffRoundCouple x) => x.TournamentTeam1)
	.And(D3Specification.Create<Tournament>(D3Context).OrderBy(x => x.TournamentId, true, 1)
		.And(D3Specification.Create<TourSerie>(D3Context)))
	.And(D3Specification.Create<Team>(D3Context)
		.And(D3Specification.Create<TeamPlayer>(D3Context))
		.And(D3Specification.Create<User>(D3Context))
		.And(D3Specification.Create<TournamentTeam>(D3Context))
		.And(D3Specification.Create<TournamentTeamStat>(D3Context))
		.OrderBy(x => x.Name).OrderBy(x => x.Name, true, 3).And(D3Specification.Create<Team>(D3Context).Compare(x => x.Name, ComparisonOp.EQUALS, "Team1").Compare(x => x.Name, ComparisonOp.EQUALS, "Team2", LogicalOp.OR)))
	/*missing 1 closing parenthesis -> we join the TournamentTeam2 to TournamentTeam1, which leads to omit of TournamentTeam2, because TournamentTeam has no reference to TournamentTeam - only PlayoffRoundCouple has. */
	.And(D3Specification.Create(D3Context, (PlayoffRoundCouple x) => x.TournamentTeam2)
		.And(D3Specification.Create<Team>(D3Context)
			.And(D3Specification.Create<TeamPlayer>(D3Context))
			.And(D3Specification.Create<User>(D3Context))
			.And(D3Specification.Create<TournamentTeam>(D3Context))
			.And(D3Specification.Create<TournamentTeamStat>(D3Context))
			.OrderBy(x => x.Name).OrderBy(x => x.Name, true, 3))).And(D3Specification.Create<Team>(D3Context).Compare(x => x.Name, ComparisonOp.EQUALS, "Team3").Compare(x => x.Name, ComparisonOp.EQUALS, "Team4", LogicalOp.OR)))
	.And(D3Specification.Create<Match>(D3Context).OrderBy(x => x.MatchId, false, 7)
		.And(D3Specification.Create<MatchSetScore>(D3Context).OrderBy(x => x.SetOrder)));

			var str2 = query2.GetSQL(false);

			Assertion.AssertStrings(ExpectedQuery2, str2);

			var query3 = D3Specification.Create<PlayoffRoundCouple>(D3Context)
.And(D3Specification.Create(D3Context, (PlayoffRoundCouple x) => x.TournamentTeam1)
	.And(D3Specification.Create<Tournament>(D3Context).OrderBy(x => x.TournamentId, true, 1)
		.And(D3Specification.Create<TourSerie>(D3Context)))
	.And(D3Specification.Create<Team>(D3Context)
		.And(D3Specification.Create<TeamPlayer>(D3Context))
		.And(D3Specification.Create<User>(D3Context))
		.And(D3Specification.Create<TournamentTeam>(D3Context))
		.And(D3Specification.Create<TournamentTeamStat>(D3Context))
		.OrderBy(x => x.Name).OrderBy(x => x.Name, true, 3).And(D3Specification.Create<Team>(D3Context).Compare(x => x.Name, ComparisonOp.EQUALS, "Team1").Compare(x => x.Name, ComparisonOp.EQUALS, "Team2", LogicalOp.OR))))
	.And(D3Specification.Create(D3Context, (PlayoffRoundCouple x) => x.TournamentTeam2)
		.And(D3Specification.Create<Team>(D3Context)
			.And(D3Specification.Create<TeamPlayer>(D3Context))
			.And(D3Specification.Create<User>(D3Context))
			.And(D3Specification.Create<TournamentTeam>(D3Context))
			.And(D3Specification.Create<TournamentTeamStat>(D3Context))
			.OrderBy(x => x.Name).OrderBy(x => x.Name, true, 3)).And(D3Specification.Create<Team>(D3Context).Compare(x => x.Name, ComparisonOp.EQUALS, "Team3").Compare(x => x.Name, ComparisonOp.EQUALS, "Team4", LogicalOp.OR)))
	.And(D3Specification.Create<Match>(D3Context).OrderBy(x => x.MatchId, false, 7)
		.And(D3Specification.Create<MatchSetScore>(D3Context).OrderBy(x => x.SetOrder)));

			var str3 = query3.GetSQL(false);

			Assertion.AssertStrings(ExpectedQuery3, str3);
		}

		/// <summary>
		/// Wrong placement of parentheses leads to wrong filter - the part "( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' ) OR" should be omitted.
		/// </summary>
		private string ExpectedQuery1 { get; } = @"SELECT
`playoff_round_couple`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `playoff_round_couple`.`tournament_team1_id` '.TournamentTeam1Id'
	, `playoff_round_couple`.`tournament_team2_id` '.TournamentTeam2Id'
	, `playoff_round_couple`.`playoff_round` '.PlayoffRound'
	, `playoff_round_couple`.`team1_wins` '.Team1Wins'
	, `playoff_round_couple`.`team2_wins` '.Team2Wins'
	, `playoff_round_couple`.`last_change` '.LastChange'
	, `playoff_round_couple`.`changed_by` '.ChangedBy'
	, `tournament_team`.`tournament_team_id` 'TournamentTeam1(TournamentTeam).TournamentTeamId'
	, `tournament_team`.`tournament_id` 'TournamentTeam1(TournamentTeam).TournamentId'
	, `tournament_team`.`team_id` 'TournamentTeam1(TournamentTeam).TeamId'
	, `tournament_team`.`basic_group_name` 'TournamentTeam1(TournamentTeam).BasicGroupName'
	, `tournament_team`.`registration_date` 'TournamentTeam1(TournamentTeam).RegistrationDate'
	, `tournament_team`.`entry_fee_paid` 'TournamentTeam1(TournamentTeam).EntryFeePaid'
	, `tournament_team`.`last_change` 'TournamentTeam1(TournamentTeam).LastChange'
	, `tournament_team`.`changed_by` 'TournamentTeam1(TournamentTeam).ChangedBy'
	, `tournament`.`tournament_id` 'TournamentTeam1(TournamentTeam).Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'TournamentTeam1(TournamentTeam).Tournament.TourSerieId'
	, `tournament`.`address_id` 'TournamentTeam1(TournamentTeam).Tournament.AddressId'
	, `tournament`.`name` 'TournamentTeam1(TournamentTeam).Tournament.Name'
	, `tournament`.`start_date` 'TournamentTeam1(TournamentTeam).Tournament.StartDate'
	, `tournament`.`end_date` 'TournamentTeam1(TournamentTeam).Tournament.EndDate'
	, `tournament`.`entry_fee` 'TournamentTeam1(TournamentTeam).Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'TournamentTeam1(TournamentTeam).Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'TournamentTeam1(TournamentTeam).Tournament.Note'
	, `tournament`.`last_change` 'TournamentTeam1(TournamentTeam).Tournament.LastChange'
	, `tournament`.`changed_by` 'TournamentTeam1(TournamentTeam).Tournament.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.TourSerieId'
	, `tour_serie`.`name` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.Name'
	, `tour_serie`.`start_date` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.StartDate'
	, `tour_serie`.`end_date` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.EndDate'
	, `tour_serie`.`category` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.Category'
	, `tour_serie`.`note` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.Note'
	, `tour_serie`.`last_change` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.ChangedBy'
	, `team`.`team_id` 'TournamentTeam1(TournamentTeam).Team.TeamId'
	, `team`.`name` 'TournamentTeam1(TournamentTeam).Team.Name'
	, `team`.`logo` 'TournamentTeam1(TournamentTeam).Team.Logo'
	, `team`.`registration_date` 'TournamentTeam1(TournamentTeam).Team.RegistrationDate'
	, `team`.`is_active` 'TournamentTeam1(TournamentTeam).Team.IsActive'
	, `team`.`last_change` 'TournamentTeam1(TournamentTeam).Team.LastChange'
	, `team`.`changed_by` 'TournamentTeam1(TournamentTeam).Team.ChangedBy'
	, `team_player`.`team_player_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`email` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Email'
	, `user`.`email_confirmed` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).EmailConfirmed'
	, `user`.`password_hash` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PasswordHash'
	, `user`.`security_stamp` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).SecurityStamp'
	, `user`.`phone_number` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumber'
	, `user`.`phone_number_confirmed` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumberConfirmed'
	, `user`.`two_factor_enabled` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).TwoFactorEnabled'
	, `user`.`lockout_end_date_utc` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEndDateUtc'
	, `user`.`lockout_enabled` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEnabled'
	, `user`.`access_failed_count` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).AccessFailedCount'
	, `user`.`user_name` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserName'
	, `user`.`first_name` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
	, `user`.`external_login` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).ExternalLogin'
	, `user`.`registration_guid` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationGuid'
	, `user`.`guidexpiration_date` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).GuidexpirationDate'
	, `x_tournament_team`.`tournament_team_id` 'TournamentTeam2(TournamentTeam).TournamentTeamId'
	, `x_tournament_team`.`tournament_id` 'TournamentTeam2(TournamentTeam).TournamentId'
	, `x_tournament_team`.`team_id` 'TournamentTeam2(TournamentTeam).TeamId'
	, `x_tournament_team`.`basic_group_name` 'TournamentTeam2(TournamentTeam).BasicGroupName'
	, `x_tournament_team`.`registration_date` 'TournamentTeam2(TournamentTeam).RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` 'TournamentTeam2(TournamentTeam).EntryFeePaid'
	, `x_tournament_team`.`last_change` 'TournamentTeam2(TournamentTeam).LastChange'
	, `x_tournament_team`.`changed_by` 'TournamentTeam2(TournamentTeam).ChangedBy'
	, `x_team`.`team_id` 'TournamentTeam2(TournamentTeam).Team.TeamId'
	, `x_team`.`name` 'TournamentTeam2(TournamentTeam).Team.Name'
	, `x_team`.`logo` 'TournamentTeam2(TournamentTeam).Team.Logo'
	, `x_team`.`registration_date` 'TournamentTeam2(TournamentTeam).Team.RegistrationDate'
	, `x_team`.`is_active` 'TournamentTeam2(TournamentTeam).Team.IsActive'
	, `x_team`.`last_change` 'TournamentTeam2(TournamentTeam).Team.LastChange'
	, `x_team`.`changed_by` 'TournamentTeam2(TournamentTeam).Team.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, `x_team_player`.`team_player_id` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamPlayerId'
	, `x_team_player`.`team_id` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamId'
	, `x_team_player`.`player_id` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].PlayerId'
	, `x_team_player`.`last_change` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].LastChange'
	, `x_team_player`.`changed_by` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].ChangedBy'
	, `x_user`.`user_id` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserId'
	, `x_user`.`email` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Email'
	, `x_user`.`email_confirmed` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).EmailConfirmed'
	, `x_user`.`password_hash` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PasswordHash'
	, `x_user`.`security_stamp` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).SecurityStamp'
	, `x_user`.`phone_number` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumber'
	, `x_user`.`phone_number_confirmed` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumberConfirmed'
	, `x_user`.`two_factor_enabled` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).TwoFactorEnabled'
	, `x_user`.`lockout_end_date_utc` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEndDateUtc'
	, `x_user`.`lockout_enabled` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEnabled'
	, `x_user`.`access_failed_count` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).AccessFailedCount'
	, `x_user`.`user_name` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserName'
	, `x_user`.`first_name` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `x_user`.`last_name` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LastName'
	, `x_user`.`gender` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Gender'
	, `x_user`.`date_of_birth` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
	, `x_user`.`external_login` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).ExternalLogin'
	, `x_user`.`registration_guid` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationGuid'
	, `x_user`.`guidexpiration_date` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).GuidexpirationDate'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, `match`.`match_id` 'Matches[Match].MatchId'
	, `match`.`home_team_id` 'Matches[Match].HomeTeamId'
	, `match`.`away_team_id` 'Matches[Match].AwayTeamId'
	, `match`.`tournament_id` 'Matches[Match].TournamentId'
	, `match`.`tournament_phase` 'Matches[Match].TournamentPhase'
	, `match`.`winner_id` 'Matches[Match].WinnerId'
	, `match`.`referee_id` 'Matches[Match].RefereeId'
	, `match`.`match_date` 'Matches[Match].MatchDate'
	, `match`.`playoff_round_couple_id` 'Matches[Match].PlayoffRoundCoupleId'
	, `match`.`last_change` 'Matches[Match].LastChange'
	, `match`.`changed_by` 'Matches[Match].ChangedBy'
	, `match_set_score`.`match_set_score_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'Matches[Match].MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'Matches[Match].MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'Matches[Match].MatchSetScores[MatchSetScore].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
INNER JOIN `tournament_team` `tournament_team` ON `playoff_round_couple`.`tournament_team1_id` = `tournament_team`.`tournament_team_id`
INNER JOIN `tournament` `tournament` ON `tournament_team`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`
INNER JOIN `team` `team` ON `tournament_team`.`team_id` = `team`.`team_id`
LEFT JOIN ( SELECT `team_player`.* FROM `team_player` INNER JOIN `team` ON `team_player`.`team_id` = `team`.`team_id` ) AS `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN ( SELECT `tournament_team_stat`.* FROM `tournament_team_stat` INNER JOIN `tournament_team` ON `tournament_team_stat`.`tournament_team_id` = `tournament_team`.`tournament_team_id` ) AS `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
INNER JOIN `tournament_team` `x_tournament_team` ON `playoff_round_couple`.`tournament_team2_id` = `x_tournament_team`.`tournament_team_id`
INNER JOIN `team` `x_team` ON `x_tournament_team`.`team_id` = `x_team`.`team_id`
LEFT JOIN ( SELECT `team_player`.* FROM `team_player` INNER JOIN `team` ON `team_player`.`team_id` = `team`.`team_id` ) AS `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`
LEFT JOIN ( SELECT `tournament_team_stat`.* FROM `tournament_team_stat` INNER JOIN `tournament_team` ON `tournament_team_stat`.`tournament_team_id` = `tournament_team`.`tournament_team_id` ) AS `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`
LEFT JOIN ( SELECT `match`.* FROM `match` INNER JOIN `playoff_round_couple` ON `match`.`playoff_round_couple_id` = `playoff_round_couple`.`playoff_round_couple_id` ) AS `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN ( SELECT `match_set_score`.* FROM `match_set_score` INNER JOIN `match` ON `match_set_score`.`match_id` = `match`.`match_id` ) AS `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`

WHERE
	( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' ) AND ( ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' ) OR ( `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) ) )
ORDER BY `tournament`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `match`.`match_id`, `match_set_score`.`set_order`
";

		/// <summary>
		/// Wrong placement of parentheses leads to omit of TournamentTeam2, because we join TournamentTeam2 property with TournamentTeam1 (which does not contain any reference to TournamentTeam) instead of PlayoffRoundCouple (which contains a reference to TournamentTeam2).
		/// </summary>
		private string ExpectedQuery2 { get; } = @"SELECT
`playoff_round_couple`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `playoff_round_couple`.`tournament_team1_id` '.TournamentTeam1Id'
	, `playoff_round_couple`.`tournament_team2_id` '.TournamentTeam2Id'
	, `playoff_round_couple`.`playoff_round` '.PlayoffRound'
	, `playoff_round_couple`.`team1_wins` '.Team1Wins'
	, `playoff_round_couple`.`team2_wins` '.Team2Wins'
	, `playoff_round_couple`.`last_change` '.LastChange'
	, `playoff_round_couple`.`changed_by` '.ChangedBy'
	, `tournament_team`.`tournament_team_id` 'TournamentTeam1(TournamentTeam).TournamentTeamId'
	, `tournament_team`.`tournament_id` 'TournamentTeam1(TournamentTeam).TournamentId'
	, `tournament_team`.`team_id` 'TournamentTeam1(TournamentTeam).TeamId'
	, `tournament_team`.`basic_group_name` 'TournamentTeam1(TournamentTeam).BasicGroupName'
	, `tournament_team`.`registration_date` 'TournamentTeam1(TournamentTeam).RegistrationDate'
	, `tournament_team`.`entry_fee_paid` 'TournamentTeam1(TournamentTeam).EntryFeePaid'
	, `tournament_team`.`last_change` 'TournamentTeam1(TournamentTeam).LastChange'
	, `tournament_team`.`changed_by` 'TournamentTeam1(TournamentTeam).ChangedBy'
	, `tournament`.`tournament_id` 'TournamentTeam1(TournamentTeam).Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'TournamentTeam1(TournamentTeam).Tournament.TourSerieId'
	, `tournament`.`address_id` 'TournamentTeam1(TournamentTeam).Tournament.AddressId'
	, `tournament`.`name` 'TournamentTeam1(TournamentTeam).Tournament.Name'
	, `tournament`.`start_date` 'TournamentTeam1(TournamentTeam).Tournament.StartDate'
	, `tournament`.`end_date` 'TournamentTeam1(TournamentTeam).Tournament.EndDate'
	, `tournament`.`entry_fee` 'TournamentTeam1(TournamentTeam).Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'TournamentTeam1(TournamentTeam).Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'TournamentTeam1(TournamentTeam).Tournament.Note'
	, `tournament`.`last_change` 'TournamentTeam1(TournamentTeam).Tournament.LastChange'
	, `tournament`.`changed_by` 'TournamentTeam1(TournamentTeam).Tournament.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.TourSerieId'
	, `tour_serie`.`name` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.Name'
	, `tour_serie`.`start_date` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.StartDate'
	, `tour_serie`.`end_date` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.EndDate'
	, `tour_serie`.`category` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.Category'
	, `tour_serie`.`note` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.Note'
	, `tour_serie`.`last_change` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.ChangedBy'
	, `team`.`team_id` 'TournamentTeam1(TournamentTeam).Team.TeamId'
	, `team`.`name` 'TournamentTeam1(TournamentTeam).Team.Name'
	, `team`.`logo` 'TournamentTeam1(TournamentTeam).Team.Logo'
	, `team`.`registration_date` 'TournamentTeam1(TournamentTeam).Team.RegistrationDate'
	, `team`.`is_active` 'TournamentTeam1(TournamentTeam).Team.IsActive'
	, `team`.`last_change` 'TournamentTeam1(TournamentTeam).Team.LastChange'
	, `team`.`changed_by` 'TournamentTeam1(TournamentTeam).Team.ChangedBy'
	, `team_player`.`team_player_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`email` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Email'
	, `user`.`email_confirmed` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).EmailConfirmed'
	, `user`.`password_hash` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PasswordHash'
	, `user`.`security_stamp` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).SecurityStamp'
	, `user`.`phone_number` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumber'
	, `user`.`phone_number_confirmed` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumberConfirmed'
	, `user`.`two_factor_enabled` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).TwoFactorEnabled'
	, `user`.`lockout_end_date_utc` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEndDateUtc'
	, `user`.`lockout_enabled` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEnabled'
	, `user`.`access_failed_count` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).AccessFailedCount'
	, `user`.`user_name` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserName'
	, `user`.`first_name` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
	, `user`.`external_login` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).ExternalLogin'
	, `user`.`registration_guid` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationGuid'
	, `user`.`guidexpiration_date` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).GuidexpirationDate'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, `match`.`match_id` 'Matches[Match].MatchId'
	, `match`.`home_team_id` 'Matches[Match].HomeTeamId'
	, `match`.`away_team_id` 'Matches[Match].AwayTeamId'
	, `match`.`tournament_id` 'Matches[Match].TournamentId'
	, `match`.`tournament_phase` 'Matches[Match].TournamentPhase'
	, `match`.`winner_id` 'Matches[Match].WinnerId'
	, `match`.`referee_id` 'Matches[Match].RefereeId'
	, `match`.`match_date` 'Matches[Match].MatchDate'
	, `match`.`playoff_round_couple_id` 'Matches[Match].PlayoffRoundCoupleId'
	, `match`.`last_change` 'Matches[Match].LastChange'
	, `match`.`changed_by` 'Matches[Match].ChangedBy'
	, `match_set_score`.`match_set_score_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'Matches[Match].MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'Matches[Match].MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'Matches[Match].MatchSetScores[MatchSetScore].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
INNER JOIN `tournament_team` `tournament_team` ON `playoff_round_couple`.`tournament_team1_id` = `tournament_team`.`tournament_team_id`
INNER JOIN `tournament` `tournament` ON `tournament_team`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`
INNER JOIN `team` `team` ON `tournament_team`.`team_id` = `team`.`team_id`
LEFT JOIN ( SELECT `team_player`.* FROM `team_player` INNER JOIN `team` ON `team_player`.`team_id` = `team`.`team_id` ) AS `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN ( SELECT `tournament_team_stat`.* FROM `tournament_team_stat` INNER JOIN `tournament_team` ON `tournament_team_stat`.`tournament_team_id` = `tournament_team`.`tournament_team_id` ) AS `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN ( SELECT `match`.* FROM `match` INNER JOIN `playoff_round_couple` ON `match`.`playoff_round_couple_id` = `playoff_round_couple`.`playoff_round_couple_id` ) AS `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN ( SELECT `match_set_score`.* FROM `match_set_score` INNER JOIN `match` ON `match_set_score`.`match_id` = `match`.`match_id` ) AS `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`

WHERE
	( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' ) AND ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' )
ORDER BY `tournament`.`tournament_id` DESC, `team`.`name` DESC, `match`.`match_id`, `match_set_score`.`set_order`
";

		/// <summary>
		/// The right placement of parentheses!
		/// </summary>
		private string ExpectedQuery3 { get; } = @"SELECT
`playoff_round_couple`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `playoff_round_couple`.`tournament_team1_id` '.TournamentTeam1Id'
	, `playoff_round_couple`.`tournament_team2_id` '.TournamentTeam2Id'
	, `playoff_round_couple`.`playoff_round` '.PlayoffRound'
	, `playoff_round_couple`.`team1_wins` '.Team1Wins'
	, `playoff_round_couple`.`team2_wins` '.Team2Wins'
	, `playoff_round_couple`.`last_change` '.LastChange'
	, `playoff_round_couple`.`changed_by` '.ChangedBy'
	, `tournament_team`.`tournament_team_id` 'TournamentTeam1(TournamentTeam).TournamentTeamId'
	, `tournament_team`.`tournament_id` 'TournamentTeam1(TournamentTeam).TournamentId'
	, `tournament_team`.`team_id` 'TournamentTeam1(TournamentTeam).TeamId'
	, `tournament_team`.`basic_group_name` 'TournamentTeam1(TournamentTeam).BasicGroupName'
	, `tournament_team`.`registration_date` 'TournamentTeam1(TournamentTeam).RegistrationDate'
	, `tournament_team`.`entry_fee_paid` 'TournamentTeam1(TournamentTeam).EntryFeePaid'
	, `tournament_team`.`last_change` 'TournamentTeam1(TournamentTeam).LastChange'
	, `tournament_team`.`changed_by` 'TournamentTeam1(TournamentTeam).ChangedBy'
	, `tournament`.`tournament_id` 'TournamentTeam1(TournamentTeam).Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'TournamentTeam1(TournamentTeam).Tournament.TourSerieId'
	, `tournament`.`address_id` 'TournamentTeam1(TournamentTeam).Tournament.AddressId'
	, `tournament`.`name` 'TournamentTeam1(TournamentTeam).Tournament.Name'
	, `tournament`.`start_date` 'TournamentTeam1(TournamentTeam).Tournament.StartDate'
	, `tournament`.`end_date` 'TournamentTeam1(TournamentTeam).Tournament.EndDate'
	, `tournament`.`entry_fee` 'TournamentTeam1(TournamentTeam).Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'TournamentTeam1(TournamentTeam).Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'TournamentTeam1(TournamentTeam).Tournament.Note'
	, `tournament`.`last_change` 'TournamentTeam1(TournamentTeam).Tournament.LastChange'
	, `tournament`.`changed_by` 'TournamentTeam1(TournamentTeam).Tournament.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.TourSerieId'
	, `tour_serie`.`name` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.Name'
	, `tour_serie`.`start_date` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.StartDate'
	, `tour_serie`.`end_date` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.EndDate'
	, `tour_serie`.`category` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.Category'
	, `tour_serie`.`note` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.Note'
	, `tour_serie`.`last_change` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'TournamentTeam1(TournamentTeam).Tournament.TourSerie.ChangedBy'
	, `team`.`team_id` 'TournamentTeam1(TournamentTeam).Team.TeamId'
	, `team`.`name` 'TournamentTeam1(TournamentTeam).Team.Name'
	, `team`.`logo` 'TournamentTeam1(TournamentTeam).Team.Logo'
	, `team`.`registration_date` 'TournamentTeam1(TournamentTeam).Team.RegistrationDate'
	, `team`.`is_active` 'TournamentTeam1(TournamentTeam).Team.IsActive'
	, `team`.`last_change` 'TournamentTeam1(TournamentTeam).Team.LastChange'
	, `team`.`changed_by` 'TournamentTeam1(TournamentTeam).Team.ChangedBy'
	, `team_player`.`team_player_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`email` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Email'
	, `user`.`email_confirmed` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).EmailConfirmed'
	, `user`.`password_hash` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PasswordHash'
	, `user`.`security_stamp` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).SecurityStamp'
	, `user`.`phone_number` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumber'
	, `user`.`phone_number_confirmed` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumberConfirmed'
	, `user`.`two_factor_enabled` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).TwoFactorEnabled'
	, `user`.`lockout_end_date_utc` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEndDateUtc'
	, `user`.`lockout_enabled` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEnabled'
	, `user`.`access_failed_count` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).AccessFailedCount'
	, `user`.`user_name` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserName'
	, `user`.`first_name` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
	, `user`.`external_login` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).ExternalLogin'
	, `user`.`registration_guid` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationGuid'
	, `user`.`guidexpiration_date` 'TournamentTeam1(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).GuidexpirationDate'
	, `x_tournament_team`.`tournament_team_id` 'TournamentTeam2(TournamentTeam).TournamentTeamId'
	, `x_tournament_team`.`tournament_id` 'TournamentTeam2(TournamentTeam).TournamentId'
	, `x_tournament_team`.`team_id` 'TournamentTeam2(TournamentTeam).TeamId'
	, `x_tournament_team`.`basic_group_name` 'TournamentTeam2(TournamentTeam).BasicGroupName'
	, `x_tournament_team`.`registration_date` 'TournamentTeam2(TournamentTeam).RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` 'TournamentTeam2(TournamentTeam).EntryFeePaid'
	, `x_tournament_team`.`last_change` 'TournamentTeam2(TournamentTeam).LastChange'
	, `x_tournament_team`.`changed_by` 'TournamentTeam2(TournamentTeam).ChangedBy'
	, `x_team`.`team_id` 'TournamentTeam2(TournamentTeam).Team.TeamId'
	, `x_team`.`name` 'TournamentTeam2(TournamentTeam).Team.Name'
	, `x_team`.`logo` 'TournamentTeam2(TournamentTeam).Team.Logo'
	, `x_team`.`registration_date` 'TournamentTeam2(TournamentTeam).Team.RegistrationDate'
	, `x_team`.`is_active` 'TournamentTeam2(TournamentTeam).Team.IsActive'
	, `x_team`.`last_change` 'TournamentTeam2(TournamentTeam).Team.LastChange'
	, `x_team`.`changed_by` 'TournamentTeam2(TournamentTeam).Team.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeam1(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, `x_team_player`.`team_player_id` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamPlayerId'
	, `x_team_player`.`team_id` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].TeamId'
	, `x_team_player`.`player_id` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].PlayerId'
	, `x_team_player`.`last_change` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].LastChange'
	, `x_team_player`.`changed_by` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].ChangedBy'
	, `x_user`.`user_id` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserId'
	, `x_user`.`email` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Email'
	, `x_user`.`email_confirmed` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).EmailConfirmed'
	, `x_user`.`password_hash` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PasswordHash'
	, `x_user`.`security_stamp` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).SecurityStamp'
	, `x_user`.`phone_number` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumber'
	, `x_user`.`phone_number_confirmed` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).PhoneNumberConfirmed'
	, `x_user`.`two_factor_enabled` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).TwoFactorEnabled'
	, `x_user`.`lockout_end_date_utc` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEndDateUtc'
	, `x_user`.`lockout_enabled` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LockoutEnabled'
	, `x_user`.`access_failed_count` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).AccessFailedCount'
	, `x_user`.`user_name` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).UserName'
	, `x_user`.`first_name` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `x_user`.`last_name` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).LastName'
	, `x_user`.`gender` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).Gender'
	, `x_user`.`date_of_birth` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
	, `x_user`.`external_login` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).ExternalLogin'
	, `x_user`.`registration_guid` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).RegistrationGuid'
	, `x_user`.`guidexpiration_date` 'TournamentTeam2(TournamentTeam).Team.TeamPlayers[TeamPlayer].Player(User).GuidexpirationDate'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'TournamentTeam2(TournamentTeam).TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, `match`.`match_id` 'Matches[Match].MatchId'
	, `match`.`home_team_id` 'Matches[Match].HomeTeamId'
	, `match`.`away_team_id` 'Matches[Match].AwayTeamId'
	, `match`.`tournament_id` 'Matches[Match].TournamentId'
	, `match`.`tournament_phase` 'Matches[Match].TournamentPhase'
	, `match`.`winner_id` 'Matches[Match].WinnerId'
	, `match`.`referee_id` 'Matches[Match].RefereeId'
	, `match`.`match_date` 'Matches[Match].MatchDate'
	, `match`.`playoff_round_couple_id` 'Matches[Match].PlayoffRoundCoupleId'
	, `match`.`last_change` 'Matches[Match].LastChange'
	, `match`.`changed_by` 'Matches[Match].ChangedBy'
	, `match_set_score`.`match_set_score_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'Matches[Match].MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'Matches[Match].MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'Matches[Match].MatchSetScores[MatchSetScore].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
INNER JOIN `tournament_team` `tournament_team` ON `playoff_round_couple`.`tournament_team1_id` = `tournament_team`.`tournament_team_id`
INNER JOIN `tournament` `tournament` ON `tournament_team`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`
INNER JOIN `team` `team` ON `tournament_team`.`team_id` = `team`.`team_id`
LEFT JOIN ( SELECT `team_player`.* FROM `team_player` INNER JOIN `team` ON `team_player`.`team_id` = `team`.`team_id` ) AS `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN ( SELECT `tournament_team_stat`.* FROM `tournament_team_stat` INNER JOIN `tournament_team` ON `tournament_team_stat`.`tournament_team_id` = `tournament_team`.`tournament_team_id` ) AS `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
INNER JOIN `tournament_team` `x_tournament_team` ON `playoff_round_couple`.`tournament_team2_id` = `x_tournament_team`.`tournament_team_id`
INNER JOIN `team` `x_team` ON `x_tournament_team`.`team_id` = `x_team`.`team_id`
LEFT JOIN ( SELECT `team_player`.* FROM `team_player` INNER JOIN `team` ON `team_player`.`team_id` = `team`.`team_id` ) AS `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`
LEFT JOIN ( SELECT `tournament_team_stat`.* FROM `tournament_team_stat` INNER JOIN `tournament_team` ON `tournament_team_stat`.`tournament_team_id` = `tournament_team`.`tournament_team_id` ) AS `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`
LEFT JOIN ( SELECT `match`.* FROM `match` INNER JOIN `playoff_round_couple` ON `match`.`playoff_round_couple_id` = `playoff_round_couple`.`playoff_round_couple_id` ) AS `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN ( SELECT `match_set_score`.* FROM `match_set_score` INNER JOIN `match` ON `match_set_score`.`match_id` = `match`.`match_id` ) AS `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`

WHERE
	( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' ) AND ( `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' )
ORDER BY `tournament`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `match`.`match_id`, `match_set_score`.`set_order`
";
	}
}
