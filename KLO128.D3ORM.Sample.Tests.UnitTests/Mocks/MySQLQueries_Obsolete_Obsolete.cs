using System.Collections.Generic;

namespace KLO128.Tests.UnitTests.Mocks
{
    public static class MySQLQueries
    {
        public static Dictionary<string, string> ExpectedResults { get; set; } = new Dictionary<string, string>
        {
            {
                Constants.TeamBaseAndTeamIdQuery,
                @"SELECT DISTINCT
`team`.`team_id` '.TeamId'
	, `team`.`name` '.Name'
	, `team`.`logo` '.Logo'
	, `team`.`registration_date` '.RegistrationDate'
	, `team`.`is_active` '.IsActive'
	, `team`.`last_change` '.LastChange'
	, `team`.`changed_by` '.ChangedBy'
	, `team_player`.`team_player_id` 'TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`first_name` 'TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
FROM `team` `team`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`


WHERE
	`team`.`team_id` = 1
ORDER BY `team`.`name`
;

-- .TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `team` `team`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`


WHERE
	`team`.`team_id` = 1
;
"
            },
            {
                Constants.TeamRepositoryFindByNameQuery,
                @"SELECT
	`team`.`team_id` '.TeamId'
	, `team`.`name` '.Name'
	, `team`.`logo` '.Logo'
	, `team`.`registration_date` '.RegistrationDate'
	, `team`.`is_active` '.IsActive'
	, `team`.`last_change` '.LastChange'
	, `team`.`changed_by` '.ChangedBy'
FROM `team` `team`

WHERE
	`team`.`name` = 'Team1';"
            },
            {
                Constants.InsertTeamQuery,
                @"INSERT INTO `team` (
	`name`
	, `logo`
	, `registration_date`
	, `is_active`
	, `last_change`	
	, `changed_by`) VALUES (
	'Mock-Team1'
	, NULL
	, '2022-04-09 11:59:55.000'
	, 1
	, '2022-04-09 12:00:00.000'
	, NULL
);
"
            },
            {
                Constants.UserIdNoPassImplicitQuery,
                @"SELECT DISTINCT
	`user`.`user_id` '.UserId'
	, `user`.`first_name` '.FirstName'
	, `user`.`last_name` '.LastName'
	, `user`.`gender` '.Gender'
	, `user`.`date_of_birth` '.DateOfBirth'
	, `user`.`registration_date` '.RegistrationDate'
	, `user_role`.`user_role_id` 'UserRoles[UserRole].UserRoleId'
	, `user_role`.`user_id` 'UserRoles[UserRole].UserId'
	, `user_role`.`role_id` 'UserRoles[UserRole].RoleId'
	, `user_role`.`is_active` 'UserRoles[UserRole].IsActive'
	, `user_role`.`team_id_or_default` 'UserRoles[UserRole].TeamIdOrDefault'
FROM `user` `user`
LEFT JOIN `user_role` `user_role` ON `user`.`user_id` = `user_role`.`user_id`

WHERE
	`user`.`user_id` = 1
ORDER BY `user_role`.`team_id_or_default`
;
"

            },
            {
                Constants.UserIdNoPassQuery,
                @"SELECT DISTINCT
	`user`.`user_id` '.UserId'
	, `user`.`email` '.Email'
	, `user`.`email_confirmed` '.EmailConfirmed'
	, `user`.`security_stamp` '.SecurityStamp'
	, `user`.`phone_number` '.PhoneNumber'
	, `user`.`phone_number_confirmed` '.PhoneNumberConfirmed'
	, `user`.`two_factor_enabled` '.TwoFactorEnabled'
	, `user`.`lockout_end_date_utc` '.LockoutEndDateUtc'
	, `user`.`lockout_enabled` '.LockoutEnabled'
	, `user`.`access_failed_count` '.AccessFailedCount'
	, `user`.`user_name` '.UserName'
	, `user`.`first_name` '.FirstName'
	, `user`.`last_name` '.LastName'
	, `user`.`gender` '.Gender'
	, `user`.`date_of_birth` '.DateOfBirth'
	, `user`.`registration_date` '.RegistrationDate'
	, `user`.`external_login` '.ExternalLogin'
	, `user`.`registration_guid` '.RegistrationGuid'
	, `user`.`guidexpiration_date` '.GuidexpirationDate'
	, `user_role`.`user_role_id` 'UserRoles[UserRole].UserRoleId'
	, `user_role`.`user_id` 'UserRoles[UserRole].UserId'
	, `user_role`.`role_id` 'UserRoles[UserRole].RoleId'
	, `user_role`.`is_active` 'UserRoles[UserRole].IsActive'
	, `user_role`.`team_id_or_default` 'UserRoles[UserRole].TeamIdOrDefault'
FROM `user` `user`
LEFT JOIN `user_role` `user_role` ON `user`.`user_id` = `user_role`.`user_id`

WHERE
	`user`.`user_id` = 1
ORDER BY `user_role`.`team_id_or_default`
;
"
            },
            {
                Constants.UserIdTeamRoleQuery,
                @"SELECT DISTINCT
`user`.`user_id` '.UserId'
	, `user`.`email` '.Email'
	, `user`.`email_confirmed` '.EmailConfirmed'
	, `user`.`password_hash` '.PasswordHash'
	, `user`.`security_stamp` '.SecurityStamp'
	, `user`.`phone_number` '.PhoneNumber'
	, `user`.`phone_number_confirmed` '.PhoneNumberConfirmed'
	, `user`.`two_factor_enabled` '.TwoFactorEnabled'
	, `user`.`lockout_end_date_utc` '.LockoutEndDateUtc'
	, `user`.`lockout_enabled` '.LockoutEnabled'
	, `user`.`access_failed_count` '.AccessFailedCount'
	, `user`.`user_name` '.UserName'
	, `user`.`first_name` '.FirstName'
	, `user`.`last_name` '.LastName'
	, `user`.`gender` '.Gender'
	, `user`.`date_of_birth` '.DateOfBirth'
	, `user`.`registration_date` '.RegistrationDate'
	, `user`.`external_login` '.ExternalLogin'
	, `user`.`registration_guid` '.RegistrationGuid'
	, `user`.`guidexpiration_date` '.GuidexpirationDate'
	, `user_role`.`user_role_id` 'UserRoles[UserRole].UserRoleId'
	, `user_role`.`user_id` 'UserRoles[UserRole].UserId'
	, `user_role`.`role_id` 'UserRoles[UserRole].RoleId'
	, `user_role`.`is_active` 'UserRoles[UserRole].IsActive'
	, `user_role`.`team_id_or_default` 'UserRoles[UserRole].TeamIdOrDefault'
FROM `user` `user`
LEFT JOIN `user_role` `user_role` ON `user`.`user_id` = `user_role`.`user_id`


WHERE
	`user`.`user_id` = 1 AND ( `user_role`.`team_id_or_default` = 2 OR `user_role`.`role_id` = 4 )
ORDER BY `user_role`.`team_id_or_default`
;

"
            },
            {
                Constants.InsertTeamPlayerQuery,
                @"INSERT INTO `team_player` (

	`team_id`
	, `player_id`
	, `last_change`
	, `changed_by`
) VALUES (
	4
	, 1
	, '2022-04-18 23:05:00.000'
	, NULL
);"
            },
            {
                Constants.DeleteTeamPlayerQuery,
                "DELETE FROM `team_player`  WHERE `team_player_id` = 0;"
            },
            {
                Constants.TeamCoreGetTeamStatsNullTeamQuery,
                @"SELECT DISTINCT
`team`.`team_id` '.TeamId'
	, `team`.`name` '.Name'
	, `team`.`logo` '.Logo'
	, `team`.`registration_date` '.RegistrationDate'
	, `team`.`is_active` '.IsActive'
	, `team`.`last_change` '.LastChange'
	, `team`.`changed_by` '.ChangedBy'
	, `team_player`.`team_player_id` 'TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`first_name` 'TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
FROM `team` `team`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `tournament_team`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` = 2 )
ORDER BY `team`.`name`
;

-- .TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, `tournament`.`tournament_id` 'Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'Tournament.TourSerieId'
	, `tournament`.`address_id` 'Tournament.AddressId'
	, `tournament`.`name` 'Tournament.Name'
	, `tournament`.`start_date` 'Tournament.StartDate'
	, `tournament`.`end_date` 'Tournament.EndDate'
	, `tournament`.`entry_fee` 'Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'Tournament.Note'
	, `tournament`.`last_change` 'Tournament.LastChange'
	, `tournament`.`changed_by` 'Tournament.ChangedBy'
FROM `team` `team`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN `tournament` `tournament` ON `tournament_team`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` = 2 )
;
"
            },
            {
                Constants.TeamCoreGetTeamStatsNullTeamNotQuery,
                @"SELECT DISTINCT
`team`.`team_id` '.TeamId'
	, `team`.`name` '.Name'
	, `team`.`logo` '.Logo'
	, `team`.`registration_date` '.RegistrationDate'
	, `team`.`is_active` '.IsActive'
	, `team`.`last_change` '.LastChange'
	, `team`.`changed_by` '.ChangedBy'
	, `team_player`.`team_player_id` 'TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`first_name` 'TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
FROM `team` `team`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `tournament_team`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( ( `tournament`.`tournament_id` = 2 ) ) = 0
ORDER BY `team`.`name`
;

-- .TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, `tournament`.`tournament_id` 'Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'Tournament.TourSerieId'
	, `tournament`.`address_id` 'Tournament.AddressId'
	, `tournament`.`name` 'Tournament.Name'
	, `tournament`.`start_date` 'Tournament.StartDate'
	, `tournament`.`end_date` 'Tournament.EndDate'
	, `tournament`.`entry_fee` 'Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'Tournament.Note'
	, `tournament`.`last_change` 'Tournament.LastChange'
	, `tournament`.`changed_by` 'Tournament.ChangedBy'
FROM `team` `team`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN `tournament` `tournament` ON `tournament_team`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( ( `tournament`.`tournament_id` = 2 ) ) = 0
;
"
            },
            //
            {
                Constants.TournamentBaseAndTournamentIdQuery,
                @"SELECT DISTINCT
	`tournament`.`tournament_id` '.TournamentId'
	, `tournament`.`tour_serie_id` '.TourSerieId'
	, `tournament`.`address_id` '.AddressId'
	, `tournament`.`name` '.Name'
	, `tournament`.`start_date` '.StartDate'
	, `tournament`.`end_date` '.EndDate'
	, `tournament`.`entry_fee` '.EntryFee'
	, `tournament`.`max_num_of_teams` '.MaxNumOfTeams'
	, `tournament`.`note` '.Note'
	, `tournament`.`last_change` '.LastChange'
	, `tournament`.`changed_by` '.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'TourSerie.TourSerieId'
	, `tour_serie`.`name` 'TourSerie.Name'
	, `tour_serie`.`start_date` 'TourSerie.StartDate'
	, `tour_serie`.`end_date` 'TourSerie.EndDate'
	, `tour_serie`.`category` 'TourSerie.Category'
	, `tour_serie`.`note` 'TourSerie.Note'
	, `tour_serie`.`last_change` 'TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'TourSerie.ChangedBy'
	, `tournament_team`.`tournament_team_id` 'TournamentTeams[TournamentTeam].TournamentTeamId'
	, `tournament_team`.`tournament_id` 'TournamentTeams[TournamentTeam].TournamentId'
	, `tournament_team`.`team_id` 'TournamentTeams[TournamentTeam].TeamId'
	, `tournament_team`.`basic_group_name` 'TournamentTeams[TournamentTeam].BasicGroupName'
	, `tournament_team`.`registration_date` 'TournamentTeams[TournamentTeam].RegistrationDate'
	, `tournament_team`.`entry_fee_paid` 'TournamentTeams[TournamentTeam].EntryFeePaid'
	, `tournament_team`.`last_change` 'TournamentTeams[TournamentTeam].LastChange'
	, `tournament_team`.`changed_by` 'TournamentTeams[TournamentTeam].ChangedBy'
	, `team`.`team_id` 'TournamentTeams[TournamentTeam].Team.TeamId'
	, `team`.`name` 'TournamentTeams[TournamentTeam].Team.Name'
	, `team`.`logo` 'TournamentTeams[TournamentTeam].Team.Logo'
	, `team`.`registration_date` 'TournamentTeams[TournamentTeam].Team.RegistrationDate'
	, `team`.`is_active` 'TournamentTeams[TournamentTeam].Team.IsActive'
	, `team`.`last_change` 'TournamentTeams[TournamentTeam].Team.LastChange'
	, `team`.`changed_by` 'TournamentTeams[TournamentTeam].Team.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `tournament` `tournament`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`
LEFT JOIN `tournament_team` `tournament_team` ON `tournament`.`tournament_id` = `tournament_team`.`tournament_id`
LEFT JOIN `team` `team` ON `tournament_team`.`team_id` = `team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`

WHERE
	`tournament`.`tournament_id` = 1
ORDER BY `tournament`.`name` DESC;
"
            },
            {
                Constants.InsertMatchQuery,
                @"INSERT INTO `match` (

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
"
            },
            {
                Constants.MatchBaseAndTeamIdOnlyQuery,
                @"SELECT DISTINCT
`match`.`match_id` '.MatchId'
	, `match`.`home_team_id` '.HomeTeamId'
	, `match`.`away_team_id` '.AwayTeamId'
	, `match`.`tournament_id` '.TournamentId'
	, `match`.`tournament_phase` '.TournamentPhase'
	, `match`.`winner_id` '.WinnerId'
	, `match`.`referee_id` '.RefereeId'
	, `match`.`match_date` '.MatchDate'
	, `match`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `match`.`last_change` '.LastChange'
	, `match`.`changed_by` '.ChangedBy'
	, `team`.`team_id` 'HomeTeam(Team).TeamId'
	, `team`.`name` 'HomeTeam(Team).Name'
	, `team`.`logo` 'HomeTeam(Team).Logo'
	, `team`.`registration_date` 'HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'HomeTeam(Team).IsActive'
	, `team`.`last_change` 'HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'HomeTeam(Team).ChangedBy'
	, `x_team`.`team_id` 'AwayTeam(Team).TeamId'
	, `x_team`.`name` 'AwayTeam(Team).Name'
	, `x_team`.`logo` 'AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'AwayTeam(Team).ChangedBy'
	, `match_set_score`.`match_set_score_id` 'MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'MatchSetScores[MatchSetScore].ChangedBy'
	, `tournament`.`tournament_id` 'Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'Tournament.TourSerieId'
	, `tournament`.`address_id` 'Tournament.AddressId'
	, `tournament`.`name` 'Tournament.Name'
	, `tournament`.`start_date` 'Tournament.StartDate'
	, `tournament`.`end_date` 'Tournament.EndDate'
	, `tournament`.`entry_fee` 'Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'Tournament.Note'
	, `tournament`.`last_change` 'Tournament.LastChange'
	, `tournament`.`changed_by` 'Tournament.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'Tournament.TourSerie.TourSerieId'
	, `tour_serie`.`name` 'Tournament.TourSerie.Name'
	, `tour_serie`.`start_date` 'Tournament.TourSerie.StartDate'
	, `tour_serie`.`end_date` 'Tournament.TourSerie.EndDate'
	, `tour_serie`.`category` 'Tournament.TourSerie.Category'
	, `tour_serie`.`note` 'Tournament.TourSerie.Note'
	, `tour_serie`.`last_change` 'Tournament.TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'Tournament.TourSerie.ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`


WHERE
	`team`.`team_id` = 2 OR `x_team`.`team_id` = 2
ORDER BY `match`.`tournament_id` DESC, `match`.`match_id`, `match_set_score`.`set_order`
;
"
            },
            {
                Constants.MatchBaseAndTournamentIdAndTeamIdAndTourPhaseQuery,
                @"SELECT DISTINCT
`match`.`match_id` '.MatchId'
	, `match`.`home_team_id` '.HomeTeamId'
	, `match`.`away_team_id` '.AwayTeamId'
	, `match`.`tournament_id` '.TournamentId'
	, `match`.`tournament_phase` '.TournamentPhase'
	, `match`.`winner_id` '.WinnerId'
	, `match`.`referee_id` '.RefereeId'
	, `match`.`match_date` '.MatchDate'
	, `match`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `match`.`last_change` '.LastChange'
	, `match`.`changed_by` '.ChangedBy'
	, `team`.`team_id` 'HomeTeam(Team).TeamId'
	, `team`.`name` 'HomeTeam(Team).Name'
	, `team`.`logo` 'HomeTeam(Team).Logo'
	, `team`.`registration_date` 'HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'HomeTeam(Team).IsActive'
	, `team`.`last_change` 'HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'HomeTeam(Team).ChangedBy'
	, `x_team`.`team_id` 'AwayTeam(Team).TeamId'
	, `x_team`.`name` 'AwayTeam(Team).Name'
	, `x_team`.`logo` 'AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'AwayTeam(Team).ChangedBy'
	, `match_set_score`.`match_set_score_id` 'MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'MatchSetScores[MatchSetScore].ChangedBy'
	, `tournament`.`tournament_id` 'Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'Tournament.TourSerieId'
	, `tournament`.`address_id` 'Tournament.AddressId'
	, `tournament`.`name` 'Tournament.Name'
	, `tournament`.`start_date` 'Tournament.StartDate'
	, `tournament`.`end_date` 'Tournament.EndDate'
	, `tournament`.`entry_fee` 'Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'Tournament.Note'
	, `tournament`.`last_change` 'Tournament.LastChange'
	, `tournament`.`changed_by` 'Tournament.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'Tournament.TourSerie.TourSerieId'
	, `tour_serie`.`name` 'Tournament.TourSerie.Name'
	, `tour_serie`.`start_date` 'Tournament.TourSerie.StartDate'
	, `tour_serie`.`end_date` 'Tournament.TourSerie.EndDate'
	, `tour_serie`.`category` 'Tournament.TourSerie.Category'
	, `tour_serie`.`note` 'Tournament.TourSerie.Note'
	, `tour_serie`.`last_change` 'Tournament.TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'Tournament.TourSerie.ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`


WHERE
	`tournament`.`tournament_id` = 1 AND ( `team`.`team_id` = 2 OR `x_team`.`team_id` = 2 ) AND `match`.`tournament_phase` = 0
ORDER BY `match`.`tournament_id` DESC, `match`.`match_id`, `match_set_score`.`set_order`
;
"
            },
            {
                Constants.UpdateMatchSetScore,
                @"UPDATE `match_set_score` SET
	`match_id` = 1
	, `home_team_score` = 25
	, `away_team_score` = 19
	, `set_order` = 1
	, `last_change` = '2022-05-31 12:00:00.000'
	, `changed_by` = NULL
 WHERE `match_set_score_id` = 2;"
            },
            {
                Constants.UpdateSetOrder,
                @"UPDATE `match_set_score` SET 	`set_order` = 3 WHERE `match_set_score_id` = 2;"
            },
            {
                Constants.UpdateSetOrderAndLastChange,
                @"UPDATE `match_set_score` SET 
		`set_order` = 3
		, `last_change` = '2022-05-31 00:00:00.000'
	 WHERE `match_set_score_id` = 2;"
            },
            {
                Constants.TournamentPlayerStatCoreGetStatsQuery,
                @"SELECT DISTINCT
	`tournament_player_stat`.`tournament_player_stat_id` '.TournamentPlayerStatId'
	, `tournament_player_stat`.`tournament_id` '.TournamentId'
	, `tournament_player_stat`.`player_id` '.PlayerId'
	, `tournament_player_stat`.`tour_points` '.TourPoints'
	, `tournament_player_stat`.`attack_points` '.AttackPoints'
	, `tournament_player_stat`.`attack_percentage` '.AttackPercentage'
	, `tournament_player_stat`.`service_points` '.ServicePoints'
	, `tournament_player_stat`.`service_percentage` '.ServicePercentage'
	, `tournament_player_stat`.`unforced_errors` '.UnforcedErrors'
	, `tournament_player_stat`.`last_change` '.LastChange'
	, `tournament_player_stat`.`changed_by` '.ChangedBy'
	, `user`.`user_id` 'Player(User).UserId'
	, `user`.`first_name` 'Player(User).FirstName'
	, `user`.`last_name` 'Player(User).LastName'
	, `user`.`gender` 'Player(User).Gender'
	, `user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `user`.`registration_date` 'Player(User).RegistrationDate'
	, `tournament`.`tournament_id` 'Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'Tournament.TourSerieId'
	, `tournament`.`address_id` 'Tournament.AddressId'
	, `tournament`.`name` 'Tournament.Name'
	, `tournament`.`start_date` 'Tournament.StartDate'
	, `tournament`.`end_date` 'Tournament.EndDate'
	, `tournament`.`entry_fee` 'Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'Tournament.Note'
	, `tournament`.`last_change` 'Tournament.LastChange'
	, `tournament`.`changed_by` 'Tournament.ChangedBy'
FROM `tournament_player_stat` `tournament_player_stat`
LEFT JOIN `user` `user` ON `tournament_player_stat`.`player_id` = `user`.`user_id`
LEFT JOIN `tournament` `tournament` ON `tournament_player_stat`.`tournament_id` = `tournament`.`tournament_id`

WHERE
	`user`.`user_id` = 1 AND `tournament`.`tournament_id` = 1;
"
            },
            {
                Constants.PlayoffGetBasicGroupStatsQuery,
                @"SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `team`.`team_id` 'Team.TeamId'
	, `team`.`name` 'Team.Name'
	, `team`.`logo` 'Team.Logo'
	, `team`.`registration_date` 'Team.RegistrationDate'
	, `team`.`is_active` 'Team.IsActive'
	, `team`.`last_change` 'Team.LastChange'
	, `team`.`changed_by` 'Team.ChangedBy'
	, `team_player`.`team_player_id` 'Team.TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'Team.TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'Team.TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'Team.TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'Team.TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'Team.TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`first_name` 'Team.TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'Team.TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'Team.TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'Team.TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'Team.TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
FROM `tournament_team` `tournament_team`
LEFT JOIN `team` `team` ON `tournament_team`.`team_id` = `team`.`team_id`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`


WHERE
	`tournament_team`.`tournament_id` = 2 AND ( `tournament_team_stat`.`tournament_phase` = 0 )
ORDER BY `team`.`name`
;

-- .TournamentTeamId,TournamentTeamStats[TournamentTeamStat] ...TournamentTeamStats[TournamentTeamStat].TournamentTeamId
SELECT DISTINCT
`tournament_team_stat`.`tournament_team_stat_id` '.TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` '.TournamentPhase'
	, `tournament_team_stat`.`phase_points` '.PhasePoints'
	, `tournament_team_stat`.`wins` '.Wins'
	, `tournament_team_stat`.`losts` '.Losts'
	, `tournament_team_stat`.`ties` '.Ties'
	, `tournament_team_stat`.`sets_won` '.SetsWon'
	, `tournament_team_stat`.`sets_lost` '.SetsLost'
	, `tournament_team_stat`.`score_plus` '.ScorePlus'
	, `tournament_team_stat`.`score_minus` '.ScoreMinus'
	, `tournament_team_stat`.`last_change` '.LastChange'
	, `tournament_team_stat`.`changed_by` '.ChangedBy'
FROM `tournament_team` `tournament_team`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`


WHERE
	`tournament_team`.`tournament_id` = 2 AND ( `tournament_team_stat`.`tournament_phase` = 0 )
ORDER BY `tournament_team_stat`.`phase_points` DESC, `tournament_team_stat`.`score_minus`
;
"
            },
            {
                Constants.PlayoffRoundCoupleBaseFilterQuery,
                @"SELECT DISTINCT
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
	, `team`.`team_id` 'TournamentTeam1(TournamentTeam).Team.TeamId'
	, `team`.`name` 'TournamentTeam1(TournamentTeam).Team.Name'
	, `team`.`logo` 'TournamentTeam1(TournamentTeam).Team.Logo'
	, `team`.`registration_date` 'TournamentTeam1(TournamentTeam).Team.RegistrationDate'
	, `team`.`is_active` 'TournamentTeam1(TournamentTeam).Team.IsActive'
	, `team`.`last_change` 'TournamentTeam1(TournamentTeam).Team.LastChange'
	, `team`.`changed_by` 'TournamentTeam1(TournamentTeam).Team.ChangedBy'
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
LEFT JOIN `tournament_team` `tournament_team` ON `playoff_round_couple`.`tournament_team1_id` = `tournament_team`.`tournament_team_id`
LEFT JOIN `tournament` `tournament` ON `tournament_team`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `team` `team` ON `tournament_team`.`team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `playoff_round_couple`.`tournament_team2_id` = `x_tournament_team`.`tournament_team_id`
LEFT JOIN `team` `x_team` ON `x_tournament_team`.`team_id` = `x_team`.`team_id`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`


WHERE
	`playoff_round_couple`.`playoff_round` = 2 AND `tournament_team`.`tournament_id` = 1
ORDER BY `tournament`.`tournament_id` DESC, `playoff_round_couple`.`playoff_round`, `match`.`match_id`, `match_set_score`.`set_order`
;
"
            },
            {
                Constants.ExtendedAllPossibleRootsSimpleConditionQuery,
                @"SELECT DISTINCT
`match`.`match_id` '.MatchId'
	, `match`.`home_team_id` '.HomeTeamId'
	, `match`.`away_team_id` '.AwayTeamId'
	, `match`.`tournament_id` '.TournamentId'
	, `match`.`tournament_phase` '.TournamentPhase'
	, `match`.`winner_id` '.WinnerId'
	, `match`.`referee_id` '.RefereeId'
	, `match`.`match_date` '.MatchDate'
	, `match`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `match`.`last_change` '.LastChange'
	, `match`.`changed_by` '.ChangedBy'
	, `team`.`team_id` 'HomeTeam(Team).TeamId'
	, `team`.`name` 'HomeTeam(Team).Name'
	, `team`.`logo` 'HomeTeam(Team).Logo'
	, `team`.`registration_date` 'HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'HomeTeam(Team).IsActive'
	, `team`.`last_change` 'HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'HomeTeam(Team).ChangedBy'
	, `x_team`.`team_id` 'AwayTeam(Team).TeamId'
	, `x_team`.`name` 'AwayTeam(Team).Name'
	, `x_team`.`logo` 'AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'AwayTeam(Team).ChangedBy'
	, `match_set_score`.`match_set_score_id` 'MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'MatchSetScores[MatchSetScore].ChangedBy'
	, `tournament`.`tournament_id` 'Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'Tournament.TourSerieId'
	, `tournament`.`address_id` 'Tournament.AddressId'
	, `tournament`.`name` 'Tournament.Name'
	, `tournament`.`start_date` 'Tournament.StartDate'
	, `tournament`.`end_date` 'Tournament.EndDate'
	, `tournament`.`entry_fee` 'Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'Tournament.Note'
	, `tournament`.`last_change` 'Tournament.LastChange'
	, `tournament`.`changed_by` 'Tournament.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'Tournament.TourSerie.TourSerieId'
	, `tour_serie`.`name` 'Tournament.TourSerie.Name'
	, `tour_serie`.`start_date` 'Tournament.TourSerie.StartDate'
	, `tour_serie`.`end_date` 'Tournament.TourSerie.EndDate'
	, `tour_serie`.`category` 'Tournament.TourSerie.Category'
	, `tour_serie`.`note` 'Tournament.TourSerie.Note'
	, `tour_serie`.`last_change` 'Tournament.TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'Tournament.TourSerie.ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
ORDER BY `match`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `tournament`.`name`, `match`.`match_id`, `match_set_score`.`set_order`
;

-- HomeTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`team_player`.`team_player_id` '.TeamPlayerId'
	, `team_player`.`team_id` '.TeamId'
	, `team_player`.`player_id` '.PlayerId'
	, `team_player`.`last_change` '.LastChange'
	, `team_player`.`changed_by` '.ChangedBy'
	, `user`.`user_id` 'Player(User).UserId'
	, `user`.`first_name` 'Player(User).FirstName'
	, `user`.`last_name` 'Player(User).LastName'
	, `user`.`gender` 'Player(User).Gender'
	, `user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `user`.`registration_date` 'Player(User).RegistrationDate'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
;

-- HomeTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
;

-- AwayTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`x_team_player`.`team_player_id` '.TeamPlayerId'
	, `x_team_player`.`team_id` '.TeamId'
	, `x_team_player`.`player_id` '.PlayerId'
	, `x_team_player`.`last_change` '.LastChange'
	, `x_team_player`.`changed_by` '.ChangedBy'
	, `x_user`.`user_id` 'Player(User).UserId'
	, `x_user`.`first_name` 'Player(User).FirstName'
	, `x_user`.`last_name` 'Player(User).LastName'
	, `x_user`.`gender` 'Player(User).Gender'
	, `x_user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'Player(User).RegistrationDate'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `team_player` `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
;

-- AwayTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`x_tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `x_tournament_team`.`tournament_id` '.TournamentId'
	, `x_tournament_team`.`team_id` '.TeamId'
	, `x_tournament_team`.`basic_group_name` '.BasicGroupName'
	, `x_tournament_team`.`registration_date` '.RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `x_tournament_team`.`last_change` '.LastChange'
	, `x_tournament_team`.`changed_by` '.ChangedBy'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
;
"
            },
            {
                Constants.ExtendedAllPossibleRootsSimpleStrictConditionExpensiveQuery,
                @"SELECT DISTINCT
`match`.`match_id` '.MatchId'
	, `match`.`home_team_id` '.HomeTeamId'
	, `match`.`away_team_id` '.AwayTeamId'
	, `match`.`tournament_id` '.TournamentId'
	, `match`.`tournament_phase` '.TournamentPhase'
	, `match`.`winner_id` '.WinnerId'
	, `match`.`referee_id` '.RefereeId'
	, `match`.`match_date` '.MatchDate'
	, `match`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `match`.`last_change` '.LastChange'
	, `match`.`changed_by` '.ChangedBy'
	, `team`.`team_id` 'HomeTeam(Team).TeamId'
	, `team`.`name` 'HomeTeam(Team).Name'
	, `team`.`logo` 'HomeTeam(Team).Logo'
	, `team`.`registration_date` 'HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'HomeTeam(Team).IsActive'
	, `team`.`last_change` 'HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'HomeTeam(Team).ChangedBy'
	, `x_team`.`team_id` 'AwayTeam(Team).TeamId'
	, `x_team`.`name` 'AwayTeam(Team).Name'
	, `x_team`.`logo` 'AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'AwayTeam(Team).ChangedBy'
	, `match_set_score`.`match_set_score_id` 'MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'MatchSetScores[MatchSetScore].ChangedBy'
	, `tournament`.`tournament_id` 'Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'Tournament.TourSerieId'
	, `tournament`.`address_id` 'Tournament.AddressId'
	, `tournament`.`name` 'Tournament.Name'
	, `tournament`.`start_date` 'Tournament.StartDate'
	, `tournament`.`end_date` 'Tournament.EndDate'
	, `tournament`.`entry_fee` 'Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'Tournament.Note'
	, `tournament`.`last_change` 'Tournament.LastChange'
	, `tournament`.`changed_by` 'Tournament.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'Tournament.TourSerie.TourSerieId'
	, `tour_serie`.`name` 'Tournament.TourSerie.Name'
	, `tour_serie`.`start_date` 'Tournament.TourSerie.StartDate'
	, `tour_serie`.`end_date` 'Tournament.TourSerie.EndDate'
	, `tour_serie`.`category` 'Tournament.TourSerie.Category'
	, `tour_serie`.`note` 'Tournament.TourSerie.Note'
	, `tour_serie`.`last_change` 'Tournament.TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'Tournament.TourSerie.ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
ORDER BY `match`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `tournament`.`name`, `match`.`match_id`, `match_set_score`.`set_order`
;

-- HomeTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`team_player`.`team_player_id` '.TeamPlayerId'
	, `team_player`.`team_id` '.TeamId'
	, `team_player`.`player_id` '.PlayerId'
	, `team_player`.`last_change` '.LastChange'
	, `team_player`.`changed_by` '.ChangedBy'
	, `user`.`user_id` 'Player(User).UserId'
	, `user`.`first_name` 'Player(User).FirstName'
	, `user`.`last_name` 'Player(User).LastName'
	, `user`.`gender` 'Player(User).Gender'
	, `user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `user`.`registration_date` 'Player(User).RegistrationDate'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
;

-- HomeTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
;

-- AwayTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`x_team_player`.`team_player_id` '.TeamPlayerId'
	, `x_team_player`.`team_id` '.TeamId'
	, `x_team_player`.`player_id` '.PlayerId'
	, `x_team_player`.`last_change` '.LastChange'
	, `x_team_player`.`changed_by` '.ChangedBy'
	, `x_user`.`user_id` 'Player(User).UserId'
	, `x_user`.`first_name` 'Player(User).FirstName'
	, `x_user`.`last_name` 'Player(User).LastName'
	, `x_user`.`gender` 'Player(User).Gender'
	, `x_user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'Player(User).RegistrationDate'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `team_player` `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
;

-- AwayTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`x_tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `x_tournament_team`.`tournament_id` '.TournamentId'
	, `x_tournament_team`.`team_id` '.TeamId'
	, `x_tournament_team`.`basic_group_name` '.BasicGroupName'
	, `x_tournament_team`.`registration_date` '.RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `x_tournament_team`.`last_change` '.LastChange'
	, `x_tournament_team`.`changed_by` '.ChangedBy'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`


WHERE
	( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `team`.`name` = 'Team5' ) AND ( `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' OR `x_team`.`name` = 'Team5' ) ) OR ( ( `team`.`name` = 'Team3' OR `team`.`name` = 'Team4' OR `x_team`.`name` = 'Team3' OR `x_team`.`name` = 'Team4' ) )
;
"
            },
            {
                Constants.ExtendedAllPossibleRootsComplexConditionTeam1AndExprQuery,
                @"SELECT DISTINCT
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
	, `team`.`team_id` 'Matches[Match].HomeTeam(Team).TeamId'
	, `team`.`name` 'Matches[Match].HomeTeam(Team).Name'
	, `team`.`logo` 'Matches[Match].HomeTeam(Team).Logo'
	, `team`.`registration_date` 'Matches[Match].HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'Matches[Match].HomeTeam(Team).IsActive'
	, `team`.`last_change` 'Matches[Match].HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'Matches[Match].HomeTeam(Team).ChangedBy'
	, `x_team`.`team_id` 'Matches[Match].AwayTeam(Team).TeamId'
	, `x_team`.`name` 'Matches[Match].AwayTeam(Team).Name'
	, `x_team`.`logo` 'Matches[Match].AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'Matches[Match].AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'Matches[Match].AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'Matches[Match].AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'Matches[Match].AwayTeam(Team).ChangedBy'
	, `match_set_score`.`match_set_score_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'Matches[Match].MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'Matches[Match].MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'Matches[Match].MatchSetScores[MatchSetScore].ChangedBy'
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
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
ORDER BY `match`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `tournament`.`name`, `match`.`match_id`, `match_set_score`.`set_order`
;

-- Matches[Match].HomeTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`team_player`.`team_player_id` '.TeamPlayerId'
	, `team_player`.`team_id` '.TeamId'
	, `team_player`.`player_id` '.PlayerId'
	, `team_player`.`last_change` '.LastChange'
	, `team_player`.`changed_by` '.ChangedBy'
	, `user`.`user_id` 'Player(User).UserId'
	, `user`.`first_name` 'Player(User).FirstName'
	, `user`.`last_name` 'Player(User).LastName'
	, `user`.`gender` 'Player(User).Gender'
	, `user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `user`.`registration_date` 'Player(User).RegistrationDate'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].HomeTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].AwayTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`x_team_player`.`team_player_id` '.TeamPlayerId'
	, `x_team_player`.`team_id` '.TeamId'
	, `x_team_player`.`player_id` '.PlayerId'
	, `x_team_player`.`last_change` '.LastChange'
	, `x_team_player`.`changed_by` '.ChangedBy'
	, `x_user`.`user_id` 'Player(User).UserId'
	, `x_user`.`first_name` 'Player(User).FirstName'
	, `x_user`.`last_name` 'Player(User).LastName'
	, `x_user`.`gender` 'Player(User).Gender'
	, `x_user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'Player(User).RegistrationDate'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `team_player` `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].AwayTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`x_tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `x_tournament_team`.`tournament_id` '.TournamentId'
	, `x_tournament_team`.`team_id` '.TeamId'
	, `x_tournament_team`.`basic_group_name` '.BasicGroupName'
	, `x_tournament_team`.`registration_date` '.RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `x_tournament_team`.`last_change` '.LastChange'
	, `x_tournament_team`.`changed_by` '.ChangedBy'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;
"
            },
            {
                Constants.ExtendedAllPossibleRootsComplexConditionCountQuery,
                @"SELECT COUNT(id)
FROM (
SELECT DISTINCT
`playoff_round_couple`.`playoff_round_couple_id` AS 'id'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
ORDER BY `match`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `tournament`.`name`, `match`.`match_id`, `match_set_score`.`set_order`

) as result;"
            },
            {
                Constants.ExtendedAllPossibleRootsComplexConditionSkipAndTakeQuery,
                @"SELECT DISTINCT
`playoff_round_couple`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `playoff_round_couple`.`tournament_team1_id` '.TournamentTeam1Id'
	, `playoff_round_couple`.`tournament_team2_id` '.TournamentTeam2Id'
	, `playoff_round_couple`.`playoff_round` '.PlayoffRound'
	, `playoff_round_couple`.`team1_wins` '.Team1Wins'
	, `playoff_round_couple`.`team2_wins` '.Team2Wins'
	, `playoff_round_couple`.`last_change` '.LastChange'
	, `playoff_round_couple`.`changed_by` '.ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 OR `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
ORDER BY `match`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `tournament`.`name`, `match`.`match_id`, `match_set_score`.`set_order`
LIMIT {1} OFFSET {0}
;
--
SELECT DISTINCT
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
	, `team`.`team_id` 'Matches[Match].HomeTeam(Team).TeamId'
	, `team`.`name` 'Matches[Match].HomeTeam(Team).Name'
	, `team`.`logo` 'Matches[Match].HomeTeam(Team).Logo'
	, `team`.`registration_date` 'Matches[Match].HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'Matches[Match].HomeTeam(Team).IsActive'
	, `team`.`last_change` 'Matches[Match].HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'Matches[Match].HomeTeam(Team).ChangedBy'
	, `x_team`.`team_id` 'Matches[Match].AwayTeam(Team).TeamId'
	, `x_team`.`name` 'Matches[Match].AwayTeam(Team).Name'
	, `x_team`.`logo` 'Matches[Match].AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'Matches[Match].AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'Matches[Match].AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'Matches[Match].AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'Matches[Match].AwayTeam(Team).ChangedBy'
	, `match_set_score`.`match_set_score_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'Matches[Match].MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'Matches[Match].MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'Matches[Match].MatchSetScores[MatchSetScore].ChangedBy'
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
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 OR `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].HomeTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`team_player`.`team_player_id` '.TeamPlayerId'
	, `team_player`.`team_id` '.TeamId'
	, `team_player`.`player_id` '.PlayerId'
	, `team_player`.`last_change` '.LastChange'
	, `team_player`.`changed_by` '.ChangedBy'
	, `user`.`user_id` 'Player(User).UserId'
	, `user`.`first_name` 'Player(User).FirstName'
	, `user`.`last_name` 'Player(User).LastName'
	, `user`.`gender` 'Player(User).Gender'
	, `user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `user`.`registration_date` 'Player(User).RegistrationDate'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 OR `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].HomeTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 OR `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].AwayTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`x_team_player`.`team_player_id` '.TeamPlayerId'
	, `x_team_player`.`team_id` '.TeamId'
	, `x_team_player`.`player_id` '.PlayerId'
	, `x_team_player`.`last_change` '.LastChange'
	, `x_team_player`.`changed_by` '.ChangedBy'
	, `x_user`.`user_id` 'Player(User).UserId'
	, `x_user`.`first_name` 'Player(User).FirstName'
	, `x_user`.`last_name` 'Player(User).LastName'
	, `x_user`.`gender` 'Player(User).Gender'
	, `x_user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'Player(User).RegistrationDate'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `team_player` `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 OR `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].AwayTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`x_tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `x_tournament_team`.`tournament_id` '.TournamentId'
	, `x_tournament_team`.`team_id` '.TeamId'
	, `x_tournament_team`.`basic_group_name` '.BasicGroupName'
	, `x_tournament_team`.`registration_date` '.RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `x_tournament_team`.`last_change` '.LastChange'
	, `x_tournament_team`.`changed_by` '.ChangedBy'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 OR `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;
"
            },
            {
                Constants.ExtendedAllPossibleRootsComplexConditionSkipAndTake2Query,
                @"SELECT DISTINCT
`playoff_round_couple`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `playoff_round_couple`.`tournament_team1_id` '.TournamentTeam1Id'
	, `playoff_round_couple`.`tournament_team2_id` '.TournamentTeam2Id'
	, `playoff_round_couple`.`playoff_round` '.PlayoffRound'
	, `playoff_round_couple`.`team1_wins` '.Team1Wins'
	, `playoff_round_couple`.`team2_wins` '.Team2Wins'
	, `playoff_round_couple`.`last_change` '.LastChange'
	, `playoff_round_couple`.`changed_by` '.ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 ) AND ( `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
ORDER BY `match`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `tournament`.`name`, `match`.`match_id`, `match_set_score`.`set_order`
LIMIT {1} OFFSET {0}
;
--
SELECT DISTINCT
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
	, `team`.`team_id` 'Matches[Match].HomeTeam(Team).TeamId'
	, `team`.`name` 'Matches[Match].HomeTeam(Team).Name'
	, `team`.`logo` 'Matches[Match].HomeTeam(Team).Logo'
	, `team`.`registration_date` 'Matches[Match].HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'Matches[Match].HomeTeam(Team).IsActive'
	, `team`.`last_change` 'Matches[Match].HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'Matches[Match].HomeTeam(Team).ChangedBy'
	, `x_team`.`team_id` 'Matches[Match].AwayTeam(Team).TeamId'
	, `x_team`.`name` 'Matches[Match].AwayTeam(Team).Name'
	, `x_team`.`logo` 'Matches[Match].AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'Matches[Match].AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'Matches[Match].AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'Matches[Match].AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'Matches[Match].AwayTeam(Team).ChangedBy'
	, `match_set_score`.`match_set_score_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'Matches[Match].MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'Matches[Match].MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'Matches[Match].MatchSetScores[MatchSetScore].ChangedBy'
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
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 ) AND ( `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].HomeTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`team_player`.`team_player_id` '.TeamPlayerId'
	, `team_player`.`team_id` '.TeamId'
	, `team_player`.`player_id` '.PlayerId'
	, `team_player`.`last_change` '.LastChange'
	, `team_player`.`changed_by` '.ChangedBy'
	, `user`.`user_id` 'Player(User).UserId'
	, `user`.`first_name` 'Player(User).FirstName'
	, `user`.`last_name` 'Player(User).LastName'
	, `user`.`gender` 'Player(User).Gender'
	, `user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `user`.`registration_date` 'Player(User).RegistrationDate'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 ) AND ( `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].HomeTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 ) AND ( `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].AwayTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`x_team_player`.`team_player_id` '.TeamPlayerId'
	, `x_team_player`.`team_id` '.TeamId'
	, `x_team_player`.`player_id` '.PlayerId'
	, `x_team_player`.`last_change` '.LastChange'
	, `x_team_player`.`changed_by` '.ChangedBy'
	, `x_user`.`user_id` 'Player(User).UserId'
	, `x_user`.`first_name` 'Player(User).FirstName'
	, `x_user`.`last_name` 'Player(User).LastName'
	, `x_user`.`gender` 'Player(User).Gender'
	, `x_user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'Player(User).RegistrationDate'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `team_player` `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 ) AND ( `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;

-- Matches[Match].AwayTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`x_tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `x_tournament_team`.`tournament_id` '.TournamentId'
	, `x_tournament_team`.`team_id` '.TeamId'
	, `x_tournament_team`.`basic_group_name` '.BasicGroupName'
	, `x_tournament_team`.`registration_date` '.RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `x_tournament_team`.`last_change` '.LastChange'
	, `x_tournament_team`.`changed_by` '.ChangedBy'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	( `tournament`.`tournament_id` IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2021-01-01 00:00:00.000' )
		
 ) AND ( ( ( `tournament_team`.`tournament_team_id` = 1 OR `tournament_team`.`tournament_team_id` = 2 ) AND ( `x_tournament_team`.`tournament_team_id` = 1 OR `x_tournament_team`.`tournament_team_id` = 2 ) ) ) ) OR ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' )
;
"
            },

            {
                Constants.ExtendedAllPossibleRootsComplexConditionTeam1OrExprNotQuery,
                @"SELECT DISTINCT
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
	, `team`.`team_id` 'Matches[Match].HomeTeam(Team).TeamId'
	, `team`.`name` 'Matches[Match].HomeTeam(Team).Name'
	, `team`.`logo` 'Matches[Match].HomeTeam(Team).Logo'
	, `team`.`registration_date` 'Matches[Match].HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'Matches[Match].HomeTeam(Team).IsActive'
	, `team`.`last_change` 'Matches[Match].HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'Matches[Match].HomeTeam(Team).ChangedBy'
	, `x_team`.`team_id` 'Matches[Match].AwayTeam(Team).TeamId'
	, `x_team`.`name` 'Matches[Match].AwayTeam(Team).Name'
	, `x_team`.`logo` 'Matches[Match].AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'Matches[Match].AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'Matches[Match].AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'Matches[Match].AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'Matches[Match].AwayTeam(Team).ChangedBy'
	, `match_set_score`.`match_set_score_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'Matches[Match].MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'Matches[Match].MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'Matches[Match].MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'Matches[Match].MatchSetScores[MatchSetScore].ChangedBy'
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
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`


WHERE
	`tournament`.`tournament_id` NOT IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2023-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) = 0 AND ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' ) = 0
ORDER BY `match`.`tournament_id` DESC, `team`.`name` DESC, `x_team`.`name` DESC, `tournament`.`name`, `match`.`match_id`, `match_set_score`.`set_order`
;

-- Matches[Match].HomeTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`team_player`.`team_player_id` '.TeamPlayerId'
	, `team_player`.`team_id` '.TeamId'
	, `team_player`.`player_id` '.PlayerId'
	, `team_player`.`last_change` '.LastChange'
	, `team_player`.`changed_by` '.ChangedBy'
	, `user`.`user_id` 'Player(User).UserId'
	, `user`.`first_name` 'Player(User).FirstName'
	, `user`.`last_name` 'Player(User).LastName'
	, `user`.`gender` 'Player(User).Gender'
	, `user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `user`.`registration_date` 'Player(User).RegistrationDate'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	`tournament`.`tournament_id` NOT IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2023-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) = 0 AND ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' ) = 0
;

-- Matches[Match].HomeTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	`tournament`.`tournament_id` NOT IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2023-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) = 0 AND ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' ) = 0
;

-- Matches[Match].AwayTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`x_team_player`.`team_player_id` '.TeamPlayerId'
	, `x_team_player`.`team_id` '.TeamId'
	, `x_team_player`.`player_id` '.PlayerId'
	, `x_team_player`.`last_change` '.LastChange'
	, `x_team_player`.`changed_by` '.ChangedBy'
	, `x_user`.`user_id` 'Player(User).UserId'
	, `x_user`.`first_name` 'Player(User).FirstName'
	, `x_user`.`last_name` 'Player(User).LastName'
	, `x_user`.`gender` 'Player(User).Gender'
	, `x_user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'Player(User).RegistrationDate'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `team_player` `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	`tournament`.`tournament_id` NOT IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2023-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) = 0 AND ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' ) = 0
;

-- Matches[Match].AwayTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`x_tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `x_tournament_team`.`tournament_id` '.TournamentId'
	, `x_tournament_team`.`team_id` '.TeamId'
	, `x_tournament_team`.`basic_group_name` '.BasicGroupName'
	, `x_tournament_team`.`registration_date` '.RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `x_tournament_team`.`last_change` '.LastChange'
	, `x_tournament_team`.`changed_by` '.ChangedBy'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `playoff_round_couple` `playoff_round_couple`
LEFT JOIN `match` `match` ON `playoff_round_couple`.`playoff_round_couple_id` = `match`.`playoff_round_couple_id`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`


WHERE
	`tournament`.`tournament_id` NOT IN  (
		SELECT DISTINCT
		`xxx_tournament`.`tournament_id`
		FROM `tournament` `xxx_tournament`
		LEFT JOIN `tournament_team` `xxx_tournament_team` ON `xxx_tournament`.`tournament_id` = `xxx_tournament_team`.`tournament_id`
		LEFT JOIN `team` `xxx_team` ON `xxx_tournament_team`.`team_id` = `xxx_team`.`team_id`
		
		
		WHERE
			`xxx_tournament`.`tournament_id` NOT IN ( 3, 4 ) AND ( `xxx_team`.`registration_date` >= '2023-01-01 00:00:00.000' )
		
 ) AND ( ( `team`.`name` = 'Team1' OR `team`.`name` = 'Team2' OR `x_team`.`name` = 'Team1' OR `x_team`.`name` = 'Team2' ) ) = 0 AND ( ( `team`.`name` LIKE 'noname%' OR `x_team`.`name` LIKE 'noname%' ) AND `tournament`.`name` LIKE 'noname%' ) = 0
;
"
            },
            {
                Constants.ExtendedFilterInNotInRelationQuery,
                @"SELECT DISTINCT
`team`.`team_id` '.TeamId'
	, `team`.`name` '.Name'
	, `team`.`logo` '.Logo'
	, `team`.`registration_date` '.RegistrationDate'
	, `team`.`is_active` '.IsActive'
	, `team`.`last_change` '.LastChange'
	, `team`.`changed_by` '.ChangedBy'
	, `team_player`.`team_player_id` 'TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`first_name` 'TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
FROM `team` `team`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`


WHERE
	`team`.`team_id` NOT IN  (
		SELECT DISTINCT
		`xxxx_team`.`team_id`
		FROM `team` `xxxx_team`
		LEFT JOIN `tournament_team` `xxxx_tournament_team` ON `xxxx_team`.`team_id` = `xxxx_tournament_team`.`team_id`
		LEFT JOIN `tournament` `xxxx_tournament` ON `xxxx_tournament_team`.`tournament_id` = `xxxx_tournament`.`tournament_id`
		
		
		WHERE
			( `xxxx_team`.`name` LIKE 'name%' OR `xxxx_team`.`last_change` >= '2022-04-19 00:00:00.000' AND `xxxx_team`.`last_change` < '2022-04-25 00:00:00.000' AND `xxxx_team`.`is_active` IN ( 0, 1 ) ) AND `xxxx_tournament`.`tournament_id` IN  (
				SELECT
				`xxxx_xxx_tournament`.`tournament_id`
				FROM `tournament` `xxxx_xxx_tournament`
				
				
				WHERE
					`xxxx_xxx_tournament`.`tournament_id` = 1
				
		 )
		
 ) AND `team`.`team_id` NOT IN  (
		SELECT DISTINCT
		`xxx_team`.`team_id`
		FROM `team` `xxx_team`
		LEFT JOIN `team_player` `xxx_team_player` ON `xxx_team`.`team_id` = `xxx_team_player`.`team_id`
		LEFT JOIN `user` `xxx_user` ON `xxx_team_player`.`player_id` = `xxx_user`.`user_id`
		
		
		WHERE
			`xxx_user`.`first_name` = 'Petr'
		
 )
ORDER BY `team`.`registration_date`, `team`.`name` DESC
;

-- .TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `team` `team`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`


WHERE
	`team`.`team_id` NOT IN  (
		SELECT DISTINCT
		`xxxx_team`.`team_id`
		FROM `team` `xxxx_team`
		LEFT JOIN `tournament_team` `xxxx_tournament_team` ON `xxxx_team`.`team_id` = `xxxx_tournament_team`.`team_id`
		LEFT JOIN `tournament` `xxxx_tournament` ON `xxxx_tournament_team`.`tournament_id` = `xxxx_tournament`.`tournament_id`
		
		
		WHERE
			( `xxxx_team`.`name` LIKE 'name%' OR `xxxx_team`.`last_change` >= '2022-04-19 00:00:00.000' AND `xxxx_team`.`last_change` < '2022-04-25 00:00:00.000' AND `xxxx_team`.`is_active` IN ( 0, 1 ) ) AND `xxxx_tournament`.`tournament_id` IN  (
				SELECT
				`xxxx_xxx_tournament`.`tournament_id`
				FROM `tournament` `xxxx_xxx_tournament`
				
				
				WHERE
					`xxxx_xxx_tournament`.`tournament_id` = 1
				
		 )
		
 ) AND `team`.`team_id` NOT IN  (
		SELECT DISTINCT
		`xxx_team`.`team_id`
		FROM `team` `xxx_team`
		LEFT JOIN `team_player` `xxx_team_player` ON `xxx_team`.`team_id` = `xxx_team_player`.`team_id`
		LEFT JOIN `user` `xxx_user` ON `xxx_team_player`.`player_id` = `xxx_user`.`user_id`
		
		
		WHERE
			`xxx_user`.`first_name` = 'Petr'
		
 )
;
"
            },
            {
                Constants.ExtendedFilterInNotInRelationNotQuery,
                @"SELECT DISTINCT
`team`.`team_id` '.TeamId'
	, `team`.`name` '.Name'
	, `team`.`logo` '.Logo'
	, `team`.`registration_date` '.RegistrationDate'
	, `team`.`is_active` '.IsActive'
	, `team`.`last_change` '.LastChange'
	, `team`.`changed_by` '.ChangedBy'
	, `team_player`.`team_player_id` 'TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`first_name` 'TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
FROM `team` `team`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`


WHERE
	`team`.`team_id` IN  (
		SELECT DISTINCT
		`xxxx_team`.`team_id`
		FROM `team` `xxxx_team`
		LEFT JOIN `tournament_team` `xxxx_tournament_team` ON `xxxx_team`.`team_id` = `xxxx_tournament_team`.`team_id`
		LEFT JOIN `tournament` `xxxx_tournament` ON `xxxx_tournament_team`.`tournament_id` = `xxxx_tournament`.`tournament_id`
		
		
		WHERE
			( `xxxx_team`.`name` LIKE 'name%' OR `xxxx_team`.`last_change` >= '2022-04-19 00:00:00.000' AND `xxxx_team`.`last_change` < '2022-04-25 00:00:00.000' AND `xxxx_team`.`is_active` IN ( 0, 1 ) ) AND `xxxx_tournament`.`tournament_id` IN  (
				SELECT
				`xxxx_xxx_tournament`.`tournament_id`
				FROM `tournament` `xxxx_xxx_tournament`
				
				
				WHERE
					`xxxx_xxx_tournament`.`tournament_id` = 1
				
		 )
		
 ) OR `team`.`team_id` IN  (
		SELECT DISTINCT
		`xxx_team`.`team_id`
		FROM `team` `xxx_team`
		LEFT JOIN `team_player` `xxx_team_player` ON `xxx_team`.`team_id` = `xxx_team_player`.`team_id`
		LEFT JOIN `user` `xxx_user` ON `xxx_team_player`.`player_id` = `xxx_user`.`user_id`
		
		
		WHERE
			`xxx_user`.`first_name` = 'Petr' AND `xxx_user`.`last_name` IN  (
				SELECT
				`xxx_xxx_user`.`last_name`
				FROM `user` `xxx_xxx_user`
				
				
				WHERE
					`xxx_xxx_user`.`gender` = 'male'
				
		 )
		
 )
ORDER BY `team`.`registration_date`, `team`.`name` DESC
;

-- .TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `team` `team`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`


WHERE
	`team`.`team_id` IN  (
		SELECT DISTINCT
		`xxxx_team`.`team_id`
		FROM `team` `xxxx_team`
		LEFT JOIN `tournament_team` `xxxx_tournament_team` ON `xxxx_team`.`team_id` = `xxxx_tournament_team`.`team_id`
		LEFT JOIN `tournament` `xxxx_tournament` ON `xxxx_tournament_team`.`tournament_id` = `xxxx_tournament`.`tournament_id`
		
		
		WHERE
			( `xxxx_team`.`name` LIKE 'name%' OR `xxxx_team`.`last_change` >= '2022-04-19 00:00:00.000' AND `xxxx_team`.`last_change` < '2022-04-25 00:00:00.000' AND `xxxx_team`.`is_active` IN ( 0, 1 ) ) AND `xxxx_tournament`.`tournament_id` IN  (
				SELECT
				`xxxx_xxx_tournament`.`tournament_id`
				FROM `tournament` `xxxx_xxx_tournament`
				
				
				WHERE
					`xxxx_xxx_tournament`.`tournament_id` = 1
				
		 )
		
 ) OR `team`.`team_id` IN  (
		SELECT DISTINCT
		`xxx_team`.`team_id`
		FROM `team` `xxx_team`
		LEFT JOIN `team_player` `xxx_team_player` ON `xxx_team`.`team_id` = `xxx_team_player`.`team_id`
		LEFT JOIN `user` `xxx_user` ON `xxx_team_player`.`player_id` = `xxx_user`.`user_id`
		
		
		WHERE
			`xxx_user`.`first_name` = 'Petr' AND `xxx_user`.`last_name` IN  (
				SELECT
				`xxx_xxx_user`.`last_name`
				FROM `user` `xxx_xxx_user`
				
				
				WHERE
					`xxx_xxx_user`.`gender` = 'male'
				
		 )
		
 )
;
"
            },
//            {
//				ExtendedSimpleOrderQuery,
//				@"SELECT DISTINCT
//	`team`.`team_id` AS '.TeamId'
//	, `team`.`name` AS '.Name'
//	, `team`.`logo` AS '.Logo'
//	, `team`.`registration_date` AS '.RegistrationDate'
//	, `team`.`is_active` AS '.IsActive'
//	, `team`.`last_change` AS '.LastChange'
//	, `team`.`changed_by` AS '.ChangedBy'
// FROM `team` `team`


//WHERE
//	'paramNULL' = 'paramNULL'
//ORDER BY `team`.`registration_date`, `team`.`is_active`, `team`.`name`, `team`.`changed_by`"
//			},
            {
                Constants.ExtendedComplexOrderMatchSkipAndTakeQuery,
                @"SELECT DISTINCT
`match`.`match_id` '.MatchId'
	, `match`.`home_team_id` '.HomeTeamId'
	, `match`.`away_team_id` '.AwayTeamId'
	, `match`.`tournament_id` '.TournamentId'
	, `match`.`tournament_phase` '.TournamentPhase'
	, `match`.`winner_id` '.WinnerId'
	, `match`.`referee_id` '.RefereeId'
	, `match`.`match_date` '.MatchDate'
	, `match`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `match`.`last_change` '.LastChange'
	, `match`.`changed_by` '.ChangedBy'
	, `team`.`registration_date` 'HomeTeam(Team).RegistrationDate'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`


WHERE
	`team`.`name` NOT LIKE 'Team5%'
ORDER BY `match`.`tournament_id` DESC, `team`.`registration_date` DESC, `match`.`match_date` DESC, `team`.`last_change` DESC, `x_team`.`last_change` DESC, `match`.`match_id`, `match`.`referee_id`, `match_set_score`.`set_order`, `team`.`name`, `x_team`.`name`, `team`.`is_active` DESC, `x_team`.`is_active` DESC, `team`.`changed_by`, `x_team`.`changed_by`
LIMIT {1} OFFSET {0}
;
--
SELECT DISTINCT
`match`.`match_id` '.MatchId'
	, `match`.`home_team_id` '.HomeTeamId'
	, `match`.`away_team_id` '.AwayTeamId'
	, `match`.`tournament_id` '.TournamentId'
	, `match`.`tournament_phase` '.TournamentPhase'
	, `match`.`winner_id` '.WinnerId'
	, `match`.`referee_id` '.RefereeId'
	, `match`.`match_date` '.MatchDate'
	, `match`.`playoff_round_couple_id` '.PlayoffRoundCoupleId'
	, `match`.`last_change` '.LastChange'
	, `match`.`changed_by` '.ChangedBy'
	, `team`.`team_id` 'HomeTeam(Team).TeamId'
	, `team`.`name` 'HomeTeam(Team).Name'
	, `team`.`logo` 'HomeTeam(Team).Logo'
	, `team`.`registration_date` 'HomeTeam(Team).RegistrationDate'
	, `team`.`is_active` 'HomeTeam(Team).IsActive'
	, `team`.`last_change` 'HomeTeam(Team).LastChange'
	, `team`.`changed_by` 'HomeTeam(Team).ChangedBy'
	, `x_team`.`team_id` 'AwayTeam(Team).TeamId'
	, `x_team`.`name` 'AwayTeam(Team).Name'
	, `x_team`.`logo` 'AwayTeam(Team).Logo'
	, `x_team`.`registration_date` 'AwayTeam(Team).RegistrationDate'
	, `x_team`.`is_active` 'AwayTeam(Team).IsActive'
	, `x_team`.`last_change` 'AwayTeam(Team).LastChange'
	, `x_team`.`changed_by` 'AwayTeam(Team).ChangedBy'
	, `match_set_score`.`match_set_score_id` 'MatchSetScores[MatchSetScore].MatchSetScoreId'
	, `match_set_score`.`match_id` 'MatchSetScores[MatchSetScore].MatchId'
	, `match_set_score`.`home_team_score` 'MatchSetScores[MatchSetScore].HomeTeamScore'
	, `match_set_score`.`away_team_score` 'MatchSetScores[MatchSetScore].AwayTeamScore'
	, `match_set_score`.`set_order` 'MatchSetScores[MatchSetScore].SetOrder'
	, `match_set_score`.`last_change` 'MatchSetScores[MatchSetScore].LastChange'
	, `match_set_score`.`changed_by` 'MatchSetScores[MatchSetScore].ChangedBy'
	, `tournament`.`tournament_id` 'Tournament.TournamentId'
	, `tournament`.`tour_serie_id` 'Tournament.TourSerieId'
	, `tournament`.`address_id` 'Tournament.AddressId'
	, `tournament`.`name` 'Tournament.Name'
	, `tournament`.`start_date` 'Tournament.StartDate'
	, `tournament`.`end_date` 'Tournament.EndDate'
	, `tournament`.`entry_fee` 'Tournament.EntryFee'
	, `tournament`.`max_num_of_teams` 'Tournament.MaxNumOfTeams'
	, `tournament`.`note` 'Tournament.Note'
	, `tournament`.`last_change` 'Tournament.LastChange'
	, `tournament`.`changed_by` 'Tournament.ChangedBy'
	, `tour_serie`.`tour_serie_id` 'Tournament.TourSerie.TourSerieId'
	, `tour_serie`.`name` 'Tournament.TourSerie.Name'
	, `tour_serie`.`start_date` 'Tournament.TourSerie.StartDate'
	, `tour_serie`.`end_date` 'Tournament.TourSerie.EndDate'
	, `tour_serie`.`category` 'Tournament.TourSerie.Category'
	, `tour_serie`.`note` 'Tournament.TourSerie.Note'
	, `tour_serie`.`last_change` 'Tournament.TourSerie.LastChange'
	, `tour_serie`.`changed_by` 'Tournament.TourSerie.ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `match_set_score` `match_set_score` ON `match`.`match_id` = `match_set_score`.`match_id`
LEFT JOIN `tournament` `tournament` ON `match`.`tournament_id` = `tournament`.`tournament_id`
LEFT JOIN `tour_serie` `tour_serie` ON `tournament`.`tour_serie_id` = `tour_serie`.`tour_serie_id`


WHERE
	`match`.`tournament_id` <= {0:.TournamentId} AND `match`.`tournament_id` >= {1:.TournamentId} AND `team`.`registration_date` <= {2:HomeTeam(Team).RegistrationDate} AND `team`.`registration_date` >= {3:HomeTeam(Team).RegistrationDate} AND ( `team`.`name` NOT LIKE 'Team5%' )
;

-- HomeTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`team_player`.`team_player_id` '.TeamPlayerId'
	, `team_player`.`team_id` '.TeamId'
	, `team_player`.`player_id` '.PlayerId'
	, `team_player`.`last_change` '.LastChange'
	, `team_player`.`changed_by` '.ChangedBy'
	, `user`.`user_id` 'Player(User).UserId'
	, `user`.`first_name` 'Player(User).FirstName'
	, `user`.`last_name` 'Player(User).LastName'
	, `user`.`gender` 'Player(User).Gender'
	, `user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `user`.`registration_date` 'Player(User).RegistrationDate'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`


WHERE
	`match`.`tournament_id` <= {0:.TournamentId} AND `match`.`tournament_id` >= {1:.TournamentId} AND `team`.`registration_date` <= {2:HomeTeam(Team).RegistrationDate} AND `team`.`registration_date` >= {3:HomeTeam(Team).RegistrationDate} AND ( `team`.`name` NOT LIKE 'Team5%' )
;

-- HomeTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`


WHERE
	`match`.`tournament_id` <= {0:.TournamentId} AND `match`.`tournament_id` >= {1:.TournamentId} AND `team`.`registration_date` <= {2:HomeTeam(Team).RegistrationDate} AND `team`.`registration_date` >= {3:HomeTeam(Team).RegistrationDate} AND ( `team`.`name` NOT LIKE 'Team5%' )
;

-- AwayTeam(Team).TeamId,TeamPlayers[TeamPlayer] ...TeamPlayers[TeamPlayer].TeamId
SELECT DISTINCT
`x_team_player`.`team_player_id` '.TeamPlayerId'
	, `x_team_player`.`team_id` '.TeamId'
	, `x_team_player`.`player_id` '.PlayerId'
	, `x_team_player`.`last_change` '.LastChange'
	, `x_team_player`.`changed_by` '.ChangedBy'
	, `x_user`.`user_id` 'Player(User).UserId'
	, `x_user`.`first_name` 'Player(User).FirstName'
	, `x_user`.`last_name` 'Player(User).LastName'
	, `x_user`.`gender` 'Player(User).Gender'
	, `x_user`.`date_of_birth` 'Player(User).DateOfBirth'
	, `x_user`.`registration_date` 'Player(User).RegistrationDate'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `team_player` `x_team_player` ON `x_team`.`team_id` = `x_team_player`.`team_id`
LEFT JOIN `user` `x_user` ON `x_team_player`.`player_id` = `x_user`.`user_id`


WHERE
	`match`.`tournament_id` <= {0:.TournamentId} AND `match`.`tournament_id` >= {1:.TournamentId} AND `team`.`registration_date` <= {2:HomeTeam(Team).RegistrationDate} AND `team`.`registration_date` >= {3:HomeTeam(Team).RegistrationDate} AND ( `team`.`name` NOT LIKE 'Team5%' )
;

-- AwayTeam(Team).TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`x_tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `x_tournament_team`.`tournament_id` '.TournamentId'
	, `x_tournament_team`.`team_id` '.TeamId'
	, `x_tournament_team`.`basic_group_name` '.BasicGroupName'
	, `x_tournament_team`.`registration_date` '.RegistrationDate'
	, `x_tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `x_tournament_team`.`last_change` '.LastChange'
	, `x_tournament_team`.`changed_by` '.ChangedBy'
	, `x_tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `x_tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `x_tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `x_tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `x_tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `x_tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `x_tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `x_tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `x_tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `x_tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `x_tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `x_tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `x_tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `match` `match`
LEFT JOIN `team` `team` ON `match`.`home_team_id` = `team`.`team_id`
LEFT JOIN `team` `x_team` ON `match`.`away_team_id` = `x_team`.`team_id`
LEFT JOIN `tournament_team` `x_tournament_team` ON `x_team`.`team_id` = `x_tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `x_tournament_team_stat` ON `x_tournament_team`.`tournament_team_id` = `x_tournament_team_stat`.`tournament_team_id`


WHERE
	`match`.`tournament_id` <= {0:.TournamentId} AND `match`.`tournament_id` >= {1:.TournamentId} AND `team`.`registration_date` <= {2:HomeTeam(Team).RegistrationDate} AND `team`.`registration_date` >= {3:HomeTeam(Team).RegistrationDate} AND ( `team`.`name` NOT LIKE 'Team5%' )
;
"
            },
            {
                Constants.ExtendedComplexOrderEmptyFilterTeamQuery,
                @"SELECT DISTINCT
`team`.`team_id` '.TeamId'
	, `team`.`name` '.Name'
	, `team`.`logo` '.Logo'
	, `team`.`registration_date` '.RegistrationDate'
	, `team`.`is_active` '.IsActive'
	, `team`.`last_change` '.LastChange'
	, `team`.`changed_by` '.ChangedBy'
	, `team_player`.`team_player_id` 'TeamPlayers[TeamPlayer].TeamPlayerId'
	, `team_player`.`team_id` 'TeamPlayers[TeamPlayer].TeamId'
	, `team_player`.`player_id` 'TeamPlayers[TeamPlayer].PlayerId'
	, `team_player`.`last_change` 'TeamPlayers[TeamPlayer].LastChange'
	, `team_player`.`changed_by` 'TeamPlayers[TeamPlayer].ChangedBy'
	, `user`.`user_id` 'TeamPlayers[TeamPlayer].Player(User).UserId'
	, `user`.`first_name` 'TeamPlayers[TeamPlayer].Player(User).FirstName'
	, `user`.`last_name` 'TeamPlayers[TeamPlayer].Player(User).LastName'
	, `user`.`gender` 'TeamPlayers[TeamPlayer].Player(User).Gender'
	, `user`.`date_of_birth` 'TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, `user`.`registration_date` 'TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
FROM `team` `team`
LEFT JOIN `team_player` `team_player` ON `team`.`team_id` = `team_player`.`team_id`
LEFT JOIN `user` `user` ON `team_player`.`player_id` = `user`.`user_id`


ORDER BY `team`.`registration_date` DESC, `team`.`name` DESC, `team`.`last_change` DESC, `team`.`is_active` DESC, `team`.`changed_by`
;

-- .TeamId,TournamentTeams[TournamentTeam] ...TournamentTeams[TournamentTeam].TeamId
SELECT DISTINCT
`tournament_team`.`tournament_team_id` '.TournamentTeamId'
	, `tournament_team`.`tournament_id` '.TournamentId'
	, `tournament_team`.`team_id` '.TeamId'
	, `tournament_team`.`basic_group_name` '.BasicGroupName'
	, `tournament_team`.`registration_date` '.RegistrationDate'
	, `tournament_team`.`entry_fee_paid` '.EntryFeePaid'
	, `tournament_team`.`last_change` '.LastChange'
	, `tournament_team`.`changed_by` '.ChangedBy'
	, `tournament_team_stat`.`tournament_team_stat_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, `tournament_team_stat`.`tournament_team_id` 'TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, `tournament_team_stat`.`tournament_phase` 'TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, `tournament_team_stat`.`phase_points` 'TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, `tournament_team_stat`.`wins` 'TournamentTeamStats[TournamentTeamStat].Wins'
	, `tournament_team_stat`.`losts` 'TournamentTeamStats[TournamentTeamStat].Losts'
	, `tournament_team_stat`.`ties` 'TournamentTeamStats[TournamentTeamStat].Ties'
	, `tournament_team_stat`.`sets_won` 'TournamentTeamStats[TournamentTeamStat].SetsWon'
	, `tournament_team_stat`.`sets_lost` 'TournamentTeamStats[TournamentTeamStat].SetsLost'
	, `tournament_team_stat`.`score_plus` 'TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, `tournament_team_stat`.`score_minus` 'TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, `tournament_team_stat`.`last_change` 'TournamentTeamStats[TournamentTeamStat].LastChange'
	, `tournament_team_stat`.`changed_by` 'TournamentTeamStats[TournamentTeamStat].ChangedBy'
FROM `team` `team`
LEFT JOIN `tournament_team` `tournament_team` ON `team`.`team_id` = `tournament_team`.`team_id`
LEFT JOIN `tournament_team_stat` `tournament_team_stat` ON `tournament_team`.`tournament_team_id` = `tournament_team_stat`.`tournament_team_id`
;
"
            },
            {
                Constants.BulkUpdateQuery,
                @"UPDATE `team` SET 	`is_active` = 0 WHERE `team_id` IN (SELECT
`team`.`team_id`
FROM `team` `team`


WHERE
	`team`.`registration_date` <= '2012-08-03 00:00:00.000'
);"
            },
            {
                Constants.BulkDeleteQuery,
                @"DELETE FROM `team` WHERE `team_id` IN (SELECT
`team`.`team_id`
FROM `team` `team`


WHERE
	`team`.`registration_date` <= '2012-08-03 00:00:00.000'
)"
            }
        };
    }
}
