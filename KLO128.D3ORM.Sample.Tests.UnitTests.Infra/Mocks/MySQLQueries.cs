
///
/// generated class
///

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks
{
    public static class MySQLQueries
    {
        public const string UserIdNoPassQuery = @"SELECT  
	`u0`.`user_id` AS '.UserId'
	, `u0`.`email` AS '.Email'
	, `u0`.`email_confirmed` AS '.EmailConfirmed'
	, `u0`.`security_stamp` AS '.SecurityStamp'
	, `u0`.`phone_number` AS '.PhoneNumber'
	, `u0`.`phone_number_confirmed` AS '.PhoneNumberConfirmed'
	, `u0`.`two_factor_enabled` AS '.TwoFactorEnabled'
	, `u0`.`lockout_end_date_utc` AS '.LockoutEndDateUtc'
	, `u0`.`lockout_enabled` AS '.LockoutEnabled'
	, `u0`.`access_failed_count` AS '.AccessFailedCount'
	, `u0`.`user_name` AS '.UserName'
	, `u0`.`first_name` AS '.FirstName'
	, `u0`.`last_name` AS '.LastName'
	, `u0`.`gender` AS '.Gender'
	, `u0`.`date_of_birth` AS '.DateOfBirth'
	, `u0`.`registration_date` AS '.RegistrationDate'
	, `u0`.`external_login` AS '.ExternalLogin'
	, `u0`.`registration_guid` AS '.RegistrationGuid'
	, `u0`.`guidexpiration_date` AS '.GuidexpirationDate'
	, `u1`.`user_role_id` AS 'UserRoles[UserRole].UserRoleId'
	, `u1`.`user_id` AS 'UserRoles[UserRole].UserId'
	, `u1`.`role_id` AS 'UserRoles[UserRole].RoleId'
	, `u1`.`is_active` AS 'UserRoles[UserRole].IsActive'
	, `u1`.`team_id_or_default` AS 'UserRoles[UserRole].TeamIdOrDefault'
FROM `user` AS `u0`
LEFT JOIN `user_role` AS `u1` ON `u0`.`user_id` = `u1`.`user_id`

WHERE
	`u0`.`user_id` = 1
ORDER BY `u0`.`user_id`, `u1`.`team_id_or_default`

";

        public const string InsertMatchQuery = @"INSERT INTO `match` (

	`home_team_id`
	, `away_team_id`
	, `tournament_id`
	, `tournament_phase`
	, `winner_id`
	, `referee_id`
	, `match_date`
	, `playoff_round_couple_id`
	, `last_change`
	, `changed_by`




) VALUES (
	4
	, 1
	, 2
	, 1
	, 4
	, 3
	, '2022-10-31 20:00:00.000'
	, NULL
	, '2022-11-01 00:05:25.000'
	, NULL
);
";

        public const string TournamentPlayerStatCoreGetStatsQuery = @"SELECT  
	`t0`.`tournament_player_stat_id` AS '.TournamentPlayerStatId'
	, `t0`.`tournament_id` AS '.TournamentId'
	, `t0`.`player_id` AS '.PlayerId'
	, `t0`.`tour_points` AS '.TourPoints'
	, `t0`.`attack_points` AS '.AttackPoints'
	, `t0`.`attack_percentage` AS '.AttackPercentage'
	, `t0`.`service_points` AS '.ServicePoints'
	, `t0`.`service_percentage` AS '.ServicePercentage'
	, `t0`.`unforced_errors` AS '.UnforcedErrors'
	, `t0`.`last_change` AS '.LastChange'
	, `t0`.`changed_by` AS '.ChangedBy'
	, `u0`.`user_id` AS 'Player(User).UserId'
	, `u0`.`first_name` AS 'Player(User).FirstName'
	, `u0`.`last_name` AS 'Player(User).LastName'
	, `u0`.`gender` AS 'Player(User).Gender'
	, `u0`.`date_of_birth` AS 'Player(User).DateOfBirth'
	, `u0`.`registration_date` AS 'Player(User).RegistrationDate'
	, `t1`.`tournament_id` AS 'Tournament.TournamentId'
	, `t1`.`tour_serie_id` AS 'Tournament.TourSerieId'
	, `t1`.`address_id` AS 'Tournament.AddressId'
	, `t1`.`name` AS 'Tournament.Name'
	, `t1`.`start_date` AS 'Tournament.StartDate'
	, `t1`.`end_date` AS 'Tournament.EndDate'
	, `t1`.`entry_fee` AS 'Tournament.EntryFee'
	, `t1`.`max_num_of_teams` AS 'Tournament.MaxNumOfTeams'
	, `t1`.`note` AS 'Tournament.Note'
	, `t1`.`last_change` AS 'Tournament.LastChange'
	, `t1`.`changed_by` AS 'Tournament.ChangedBy'
FROM `tournament_player_stat` AS `t0`
INNER JOIN `user` AS `u0` ON `t0`.`player_id` = `u0`.`user_id`
INNER JOIN `tournament` AS `t1` ON `t0`.`tournament_id` = `t1`.`tournament_id`

WHERE
	`t0`.`tournament_id` = 1 AND `t0`.`player_id` = 1

";

        public const string TournamentTeamGetBasicGroupStatsQuery = @"SELECT  
	`t1`.`tournament_team_stat_id` AS '.TournamentTeamStatRankId'
	, `t1`.`sets_won` - `t1`.`sets_lost` AS '.SetsWonLostDiff'
	, `t1`.`score_plus` - `t1`.`score_minus` AS '.ScorePlusMinus'
	, `t1`.`tournament_phase` AS '.TournamentPhase'
	, `t1`.`phase_points` AS '.PhasePoints'
	, `t1`.`last_change` AS '.LastChange'
	, `t2`.`tournament_team_id` AS 'TournamentTeamStats[TournamentTeamStatRank].TournamentTeamRankId'
	, `t2`.`basic_group_name` AS 'TournamentTeamStats[TournamentTeamStatRank].BasicGroupName'
	, `t2`.`last_change` AS 'TournamentTeamStats[TournamentTeamStatRank].LastChange'
	, `t3`.`team_id` AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).TeamRankId'
	, `t3`.`name` AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).Name'
	, `t3`.`logo` AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).Logo'
	, `t3`.`registration_date` AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).RegistrationDate'
	, `t3`.`is_active` AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).IsActive'
	, `t3`.`last_change` AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).LastChange'
	, `t3`.`changed_by` AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).ChangedBy'
FROM `tournament_team_stat` AS `t1`
INNER JOIN `tournament_team` AS `t2` ON `t1`.`tournament_team_id` = `t2`.`tournament_team_id`
INNER JOIN `team` AS `t3` ON `t2`.`team_id` = `t3`.`team_id`

WHERE
	`t1`.`tournament_phase` = 0 AND `t2`.`tournament_id` = 1
ORDER BY `t1`.`tournament_phase`, `t1`.`phase_points` DESC, 2 DESC, 3 DESC

";

        public const string PlayoffCountForEachMatchAvgMaxMinSumScoreHomePlayedSkipAndTakeQuery = @"SELECT DISTINCT 
	`p0`.`playoff_round_couple_id` AS '.PlayoffRoundCoupleId'
FROM `playoff_round_couple` AS `p0`
INNER JOIN `tournament_team` AS `t0` ON `p0`.`tournament_team1_id` = `t0`.`tournament_team_id`
INNER JOIN `tournament_team` AS `t2` ON `p0`.`tournament_team2_id` = `t2`.`tournament_team_id`
INNER JOIN `tournament` AS `t1` ON `t0`.`tournament_id` = `t1`.`tournament_id`
LEFT JOIN (
	SELECT `x100`.`match_id`, `x100`.`home_team_id`, `x100`.`away_team_id`, `x100`.`tournament_id`, `x100`.`tournament_phase`, `x100`.`winner_id`, `x100`.`referee_id`, `x100`.`match_date`, `x100`.`playoff_round_couple_id`, `x100`.`last_change`, `x100`.`changed_by`, `x100100`.`away_team_score`, `x100100`.`home_team_score`, `x100100`.`match_set_score_id`
	FROM `match` AS `x100`
	LEFT JOIN `match_set_score` AS `x100100` ON `x100`.`match_id` = `x100100`.`match_id`
 ) AS `m0` ON `p0`.`playoff_round_couple_id` = `m0`.`playoff_round_couple_id`

WHERE
	`p0`.`playoff_round` = 1 AND `m0`.`home_team_id` = 1 AND ( `t0`.`team_id` = 1 OR `t2`.`team_id` = 1 )
GROUP BY `p0`.`playoff_round_couple_id`
ORDER BY `p0`.`playoff_round_couple_id`

LIMIT {1} OFFSET {0}
;
--
SELECT  
	`p0`.`playoff_round_couple_id` AS '.PlayoffRoundCoupleId'
	, `m0`.`match_id` AS 'Matches[Match].MatchId'
	, `m0`.`home_team_id` AS 'Matches[Match].HomeTeamId'
	, `m0`.`away_team_id` AS 'Matches[Match].AwayTeamId'
	, `m0`.`tournament_id` AS 'Matches[Match].TournamentId'
	, `m0`.`tournament_phase` AS 'Matches[Match].TournamentPhase'
	, `m0`.`winner_id` AS 'Matches[Match].WinnerId'
	, `m0`.`referee_id` AS 'Matches[Match].RefereeId'
	, `m0`.`match_date` AS 'Matches[Match].MatchDate'
	, `m0`.`playoff_round_couple_id` AS 'Matches[Match].PlayoffRoundCoupleId'
	, `m0`.`last_change` AS 'Matches[Match].LastChange'
	, `m0`.`changed_by` AS 'Matches[Match].ChangedBy'
	, SUM(`m0`.`away_team_score`) AS 'SUM Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, AVG(`m0`.`away_team_score`) AS 'AVG Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, MIN(`m0`.`away_team_score`) AS 'MIN Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, MAX(`m0`.`away_team_score`) AS 'MAX Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, SUM(`m0`.`home_team_score`) AS 'SUM Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, AVG(`m0`.`home_team_score`) AS 'AVG Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, MIN(`m0`.`home_team_score`) AS 'MIN Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, MAX(`m0`.`home_team_score`) AS 'MAX Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, COUNT(`m0`.`match_set_score_id`) AS 'CNT Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
FROM `playoff_round_couple` AS `p0`
INNER JOIN `tournament_team` AS `t0` ON `p0`.`tournament_team1_id` = `t0`.`tournament_team_id`
INNER JOIN `tournament_team` AS `t2` ON `p0`.`tournament_team2_id` = `t2`.`tournament_team_id`
INNER JOIN `tournament` AS `t1` ON `t0`.`tournament_id` = `t1`.`tournament_id`
LEFT JOIN (
	SELECT `x100`.`match_id`, `x100`.`home_team_id`, `x100`.`away_team_id`, `x100`.`tournament_id`, `x100`.`tournament_phase`, `x100`.`winner_id`, `x100`.`referee_id`, `x100`.`match_date`, `x100`.`playoff_round_couple_id`, `x100`.`last_change`, `x100`.`changed_by`, `x100100`.`away_team_score`, `x100100`.`home_team_score`, `x100100`.`match_set_score_id`
	FROM `match` AS `x100`
	LEFT JOIN `match_set_score` AS `x100100` ON `x100`.`match_id` = `x100100`.`match_id`
 ) AS `m0` ON `p0`.`playoff_round_couple_id` = `m0`.`playoff_round_couple_id`

WHERE
	`p0`.`playoff_round_couple_id` IN ( |RANGE| ) AND  (`p0`.`playoff_round` = 1 AND `m0`.`home_team_id` = 1 AND ( `t0`.`team_id` = 1 OR `t2`.`team_id` = 1 ) )
GROUP BY `p0`.`playoff_round_couple_id`, `m0`.`match_id`, `m0`.`home_team_id`, `m0`.`away_team_id`, `m0`.`tournament_id`, `m0`.`tournament_phase`, `m0`.`winner_id`, `m0`.`referee_id`, `m0`.`match_date`, `m0`.`playoff_round_couple_id`, `m0`.`last_change`, `m0`.`changed_by`
ORDER BY `p0`.`playoff_round_couple_id`, `t0`.`tournament_team_id`, `t2`.`tournament_team_id`, `t1`.`tournament_id`, 21 DESC, `m0`.`match_id`, 20, 16, `m0`.`match_set_score_id`

";

        public const string MatchSetScoreDifferenceQuerySkipAndTakeAsDTO = @"SELECT DISTINCT 
	`m1`.`match_set_score_id` AS '.MatchSetScoreId'
FROM `match_set_score` AS `m1`

WHERE
	`m1`.`last_change` >= '2022-03-22 00:00:00.000'
GROUP BY `m1`.`match_set_score_id`, `m1`.`match_id`, `m1`.`set_order`, `m1`.`last_change`, `m1`.`changed_by`
ORDER BY 1

LIMIT {1} OFFSET {0}
;
--
SELECT  
	`m1`.`match_set_score_id` AS '.MatchSetScoreId'
	, SUM(( CASE WHEN `m1`.`home_team_score` >= `m1`.`away_team_score` THEN `m1`.`home_team_score` ELSE `m1`.`away_team_score` END ) - ( CASE WHEN `m1`.`home_team_score` < `m1`.`away_team_score` THEN `m1`.`home_team_score` ELSE `m1`.`away_team_score` END )) AS 'ScoreDifference .HomeTeamScore'
	, `m1`.`match_id` AS '.MatchId'
	, `m1`.`set_order` AS '.SetOrder'
	, `m1`.`last_change` AS '.LastChange'
	, `m1`.`changed_by` AS '.ChangedBy'
	, `m2`.`match_id` AS 'MatchSetScores[MatchSetScoreDTO].MatchId'
	, `m2`.`home_team_id` AS 'MatchSetScores[MatchSetScoreDTO].HomeTeamId'
	, `m2`.`away_team_id` AS 'MatchSetScores[MatchSetScoreDTO].AwayTeamId'
	, `m2`.`tournament_id` AS 'MatchSetScores[MatchSetScoreDTO].TournamentId'
	, `m2`.`tournament_phase` AS 'MatchSetScores[MatchSetScoreDTO].TournamentPhase'
	, `m2`.`winner_id` AS 'MatchSetScores[MatchSetScoreDTO].WinnerIdTest'
	, `m2`.`match_date` AS 'MatchSetScores[MatchSetScoreDTO].MatchDate'
	, `m2`.`playoff_round_couple_id` AS 'MatchSetScores[MatchSetScoreDTO].PlayoffRoundCoupleId'
	, `m2`.`last_change` AS 'MatchSetScores[MatchSetScoreDTO].LastChange'
	, `m2`.`changed_by` AS 'MatchSetScores[MatchSetScoreDTO].ChangedBy'
FROM `match_set_score` AS `m1`
INNER JOIN `match` AS `m2` ON `m1`.`match_id` = `m2`.`match_id`

WHERE
	`m1`.`match_set_score_id` IN ( |RANGE| ) AND  (`m1`.`last_change` >= '2022-03-22 00:00:00.000' )
GROUP BY `m1`.`match_set_score_id`, `m1`.`match_id`, `m1`.`set_order`, `m1`.`last_change`, `m1`.`changed_by`, `m2`.`match_id`, `m2`.`home_team_id`, `m2`.`away_team_id`, `m2`.`tournament_id`, `m2`.`tournament_phase`, `m2`.`winner_id`, `m2`.`match_date`, `m2`.`playoff_round_couple_id`, `m2`.`last_change`, `m2`.`changed_by`
ORDER BY 2 DESC

";

        public const string UnionsMAtchesWonAsHomeUnionAsAwayDataSkipAndTakeQuery = @"SELECT  
	0 as ROWID,
	`p0`.`playoff_round_couple_id` AS '.PlayoffRoundCoupleId'
FROM `playoff_round_couple` AS `p0`
LEFT JOIN `match` AS `m0` ON `p0`.`playoff_round_couple_id` = `m0`.`playoff_round_couple_id`

WHERE
	`m0`.`home_team_id` = 1 AND `m0`.`winner_id` = 1
UNION

SELECT  
	1 as ROWID,
	`p0`.`playoff_round_couple_id` AS '.PlayoffRoundCoupleId'
FROM `playoff_round_couple` AS `p0`
LEFT JOIN `match` AS `m0` ON `p0`.`playoff_round_couple_id` = `m0`.`playoff_round_couple_id`

WHERE
	`m0`.`away_team_id` = 1 AND `m0`.`winner_id` = 1
UNION

SELECT  
	2 as ROWID,
	`p0`.`playoff_round_couple_id` AS '.PlayoffRoundCoupleId'
FROM `playoff_round_couple` AS `p0`
LEFT JOIN `match` AS `m0` ON `p0`.`playoff_round_couple_id` = `m0`.`playoff_round_couple_id`

WHERE
	`m0`.`home_team_id` = 1 OR `m0`.`away_team_id` = 1
ORDER BY 1

LIMIT {1} OFFSET {0}
;
--
SELECT  
	0 as ROWID,
	`p0`.`playoff_round_couple_id` AS '.PlayoffRoundCoupleId'
	, `p0`.`tournament_team1_id` AS '.TournamentTeam1Id'
	, `p0`.`tournament_team2_id` AS '.TournamentTeam2Id'
	, `p0`.`playoff_round` AS '.PlayoffRound'
	, `p0`.`team1_wins` AS '.Team1Wins'
	, `p0`.`team2_wins` AS '.Team2Wins'
	, `p0`.`last_change` AS '.LastChange'
	, `p0`.`changed_by` AS '.ChangedBy'
	, `m0`.`match_id` AS 'Matches[Match].MatchId'
	, `m0`.`home_team_id` AS 'Matches[Match].HomeTeamId'
	, `m0`.`away_team_id` AS 'Matches[Match].AwayTeamId'
	, `m0`.`tournament_id` AS 'Matches[Match].TournamentId'
	, `m0`.`tournament_phase` AS 'Matches[Match].TournamentPhase'
	, `m0`.`winner_id` AS 'Matches[Match].WinnerId'
	, `m0`.`referee_id` AS 'Matches[Match].RefereeId'
	, `m0`.`match_date` AS 'Matches[Match].MatchDate'
	, `m0`.`playoff_round_couple_id` AS 'Matches[Match].PlayoffRoundCoupleId'
	, `m0`.`last_change` AS 'Matches[Match].LastChange'
	, `m0`.`changed_by` AS 'Matches[Match].ChangedBy'
FROM `playoff_round_couple` AS `p0`
LEFT JOIN `match` AS `m0` ON `p0`.`playoff_round_couple_id` = `m0`.`playoff_round_couple_id`

WHERE
	`p0`.`playoff_round_couple_id` IN ( |RANGE| ) AND  (`m0`.`home_team_id` = 1 AND `m0`.`winner_id` = 1 )
UNION

SELECT  
	1 as ROWID,
	`p0`.`playoff_round_couple_id` AS '.PlayoffRoundCoupleId'
	, `p0`.`tournament_team1_id` AS '.TournamentTeam1Id'
	, `p0`.`tournament_team2_id` AS '.TournamentTeam2Id'
	, `p0`.`playoff_round` AS '.PlayoffRound'
	, `p0`.`team1_wins` AS '.Team1Wins'
	, `p0`.`team2_wins` AS '.Team2Wins'
	, `p0`.`last_change` AS '.LastChange'
	, `p0`.`changed_by` AS '.ChangedBy'
	, `m0`.`match_id` AS 'Matches[Match].MatchId'
	, `m0`.`home_team_id` AS 'Matches[Match].HomeTeamId'
	, `m0`.`away_team_id` AS 'Matches[Match].AwayTeamId'
	, `m0`.`tournament_id` AS 'Matches[Match].TournamentId'
	, `m0`.`tournament_phase` AS 'Matches[Match].TournamentPhase'
	, `m0`.`winner_id` AS 'Matches[Match].WinnerId'
	, `m0`.`referee_id` AS 'Matches[Match].RefereeId'
	, `m0`.`match_date` AS 'Matches[Match].MatchDate'
	, `m0`.`playoff_round_couple_id` AS 'Matches[Match].PlayoffRoundCoupleId'
	, `m0`.`last_change` AS 'Matches[Match].LastChange'
	, `m0`.`changed_by` AS 'Matches[Match].ChangedBy'
FROM `playoff_round_couple` AS `p0`
LEFT JOIN `match` AS `m0` ON `p0`.`playoff_round_couple_id` = `m0`.`playoff_round_couple_id`

WHERE
	`p0`.`playoff_round_couple_id` IN ( |RANGE| ) AND  (`m0`.`away_team_id` = 1 AND `m0`.`winner_id` = 1 )
UNION

SELECT  
	2 as ROWID,
	`p0`.`playoff_round_couple_id` AS '.PlayoffRoundCoupleId'
	, `p0`.`tournament_team1_id` AS '.TournamentTeam1Id'
	, `p0`.`tournament_team2_id` AS '.TournamentTeam2Id'
	, `p0`.`playoff_round` AS '.PlayoffRound'
	, `p0`.`team1_wins` AS '.Team1Wins'
	, `p0`.`team2_wins` AS '.Team2Wins'
	, `p0`.`last_change` AS '.LastChange'
	, `p0`.`changed_by` AS '.ChangedBy'
	, `m0`.`match_id` AS 'Matches[Match].MatchId'
	, `m0`.`home_team_id` AS 'Matches[Match].HomeTeamId'
	, `m0`.`away_team_id` AS 'Matches[Match].AwayTeamId'
	, `m0`.`tournament_id` AS 'Matches[Match].TournamentId'
	, `m0`.`tournament_phase` AS 'Matches[Match].TournamentPhase'
	, `m0`.`winner_id` AS 'Matches[Match].WinnerId'
	, `m0`.`referee_id` AS 'Matches[Match].RefereeId'
	, `m0`.`match_date` AS 'Matches[Match].MatchDate'
	, `m0`.`playoff_round_couple_id` AS 'Matches[Match].PlayoffRoundCoupleId'
	, `m0`.`last_change` AS 'Matches[Match].LastChange'
	, `m0`.`changed_by` AS 'Matches[Match].ChangedBy'
FROM `playoff_round_couple` AS `p0`
LEFT JOIN `match` AS `m0` ON `p0`.`playoff_round_couple_id` = `m0`.`playoff_round_couple_id`

WHERE
	`p0`.`playoff_round_couple_id` IN ( |RANGE| ) AND  (`m0`.`home_team_id` = 1 OR `m0`.`away_team_id` = 1 )

";

        public const string BulkUpdateQuery = @"UPDATE `team` SET 	`is_active` = 0 WHERE `registration_date` <= '2012-08-03 00:00:00.000'";


    }
}
