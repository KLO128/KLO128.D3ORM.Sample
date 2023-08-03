DELIMITER $$

CREATE PROCEDURE `sp__all_possible_roots__complex_condition` ()
BEGIN
SELECT
`playoff_round_couple`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `playoff_round_couple`.`tournament_team1_id` '.TournamentTeam1Id'
	, `playoff_round_couple`.`tournament_team2_id` '.TournamentTeam2Id'
	, `playoff_round_couple`.`playoff_round` '.PlayoffRound'
	, `playoff_round_couple`.`team1_wins` '.Team1Wins'
	, `playoff_round_couple`.`team2_wins` '.Team2Wins'
	, `playoff_round_couple`.`last_change` '.LastChange'
	, `playoff_round_couple`.`changed_by` '.ChangedBy'
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
	, `team`.`team_id` 'Matches[Match].HomeTeam(Team).TeamId'
	, `team`.`name` 'Matches[Match].HomeTeam(Team).Name'
	, `team`.`logo` 'Matches[Match].HomeTeam(Team).Logo'
	, `team`.`registration_date` 'Matches[Match].HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'Matches[Match].HomeTeam(Team).IsActive'
	, `team`.`last_change` 'Matches[Match].HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'Matches[Match].HomeTeam(Team).ChangedBy'
	, `team_player`.`team_player_id` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`first_name` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
	, `tournament_team`.`tournament_team_id` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamId'
	, `tournament_team`.`tournament_id` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentId'
	, `tournament_team`.`team_id` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TeamId'
	, `tournament_team`.`basic_group_name` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].BasicGroupName'
	, `tournament_team`.`registration_date` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].RegistrationDate'
	, `tournament_team`.`entry_fee_paid` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].EntryFeePaid'
	, `tournament_team`.`last_change` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].LastChange'
	, `tournament_team`.`changed_by` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, `x_team`.`team_id` 'Matches[Match].AwayTeam(Team).TeamId'
	, `x_team`.`name` 'Matches[Match].AwayTeam(Team).Name'
	, `x_team`.`logo` 'Matches[Match].AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'Matches[Match].AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'Matches[Match].AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'Matches[Match].AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'Matches[Match].AwayTeam(Team).ChangedBy'
	, `x_team_player`.`team_player_id` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].TeamPlayerId'
	, `x_team_player`.`team_id` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].TeamId'
	, `x_team_player`.`player_id` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].PlayerId'
	, `x_team_player`.`last_change` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].LastChange'
	, `x_team_player`.`changed_by` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].ChangedBy'
	, `x_user`.`user_id` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).UserId'
	, `x_user`.`first_name` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `x_user`.`last_name` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).LastName'
	, `x_user`.`gender` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).Gender'
	, `x_user`.`date_of_birth` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
	, `x_tournament_team`.`tournament_team_id` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamId'
	, `x_tournament_team`.`tournament_id` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentId'
	, `x_tournament_team`.`team_id` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TeamId'
	, `x_tournament_team`.`basic_group_name` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].BasicGroupName'
	, `x_tournament_team`.`registration_date` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].EntryFeePaid'
	, `x_tournament_team`.`last_change` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].LastChange'
	, `x_tournament_team`.`changed_by` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].ChangedBy'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, `tournament`.`tournament_id` 'Matches[Match].Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'Matches[Match].Tournament.TourSerieId'
	, `tournament`.`address_id` 'Matches[Match].Tournament.AddressId'
	, `tournament`.`name` 'Matches[Match].Tournament.Name'
	, `tournament`.`start_date` 'Matches[Match].Tournament.StartDate'
	, `tournament`.`end_date` 'Matches[Match].Tournament.EndDate'
	, `tournament`.`entry_fee` 'Matches[Match].Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'Matches[Match].Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'Matches[Match].Tournament.Note'
	, `tournament`.`last_change` 'Matches[Match].Tournament.LastChange'
	, `tournament`.`changed_by` 'Matches[Match].Tournament.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'Matches[Match].Tournament.TourSerie.TourSerieId'
	, `tour_serie`.`name` 'Matches[Match].Tournament.TourSerie.Name'
	, `tour_serie`.`start_date` 'Matches[Match].Tournament.TourSerie.StartDate'
	, `tour_serie`.`end_date` 'Matches[Match].Tournament.TourSerie.EndDate'
	, `tour_serie`.`category` 'Matches[Match].Tournament.TourSerie.Category'
	, `tour_serie`.`note` 'Matches[Match].Tournament.TourSerie.Note'
	, `tour_serie`.`last_change` 'Matches[Match].Tournament.TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'Matches[Match].Tournament.TourSerie.ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN ( SELECT `match`.* FROM `match` INNER JOIN `playoff_round_couple` ON `match`.`playoff_round_couple_id` = `playoff_round_couple`.`playoff_round_couple_id` ) AS `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN ( SELECT `match_set_score`.* FROM `match_set_score` INNER JOIN `match` ON `match_set_score`.`match_id` = `match`.`match_id` ) AS `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN ( SELECT `team_player`.* FROM `team_player` INNER JOIN `team` ON `team_player`.`team_id` = `team`.`team_id` ) AS `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN ( SELECT `tournament_team`.* FROM `tournament_team` INNER JOIN `team` ON `tournament_team`.`team_id` = `team`.`team_id` ) AS `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN ( SELECT `tournament_team_stat`.* FROM `tournament_team_stat` INNER JOIN `tournament_team` ON `tournament_team_stat`.`tournament_team_id` = `tournament_team`.`tournament_team_id` ) AS `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN ( SELECT `team_player`.* FROM `team_player` INNER JOIN `team` ON `team_player`.`team_id` = `team`.`team_id` ) AS `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`
LEFT JOIN ( SELECT `tournament_team`.* FROM `tournament_team` INNER JOIN `team` ON `tournament_team`.`team_id` = `team`.`team_id` ) AS `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN ( SELECT `tournament_team_stat`.* FROM `tournament_team_stat` INNER JOIN `tournament_team` ON `tournament_team_stat`.`tournament_team_id` = `tournament_team`.`tournament_team_id` ) AS `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`

WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN ( SELECT `tournament_team`.* FROM `tournament_team` INNER JOIN `tournament` ON `tournament_team`.`tournament_id` = `tournament`.`tournament_id` ) AS `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000'
		
 ) AND ( ( `team`.`name` = 'Team1' OR `x_team`.`name` = 'Team1' ) OR ( `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team2' ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
ORDER BY `tournament`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `tournament`.`name`, `match`.`match_id`, `match_set_score`.`set_order`;
END;
$$
