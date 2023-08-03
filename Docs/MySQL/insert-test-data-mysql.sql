DELIMITER $$

DROP PROCEDURE IF EXISTS insert_test_data;
$$

Create procedure insert_test_data()
BEGIN

DECLARE team1Id int;
DECLARE team2Id int;
DECLARE team3Id int;
DECLARE player11Id int;
DECLARE player21Id int;
DECLARE player12Id int;
DECLARE player22Id int;
DECLARE player13Id int;
DECLARE player23Id int;
DECLARE addressId int;
DECLARE serieId int;
DECLARE tournamentTeam1Id int;
DECLARE tournamentTeam2Id int;
DECLARE tournamentTeam3Id int;
DECLARE tournamentId int;
DECLARE match1Id int;
DECLARE match2Id int;
DECLARE match3Id int;

Start transaction;


-- users
INSERT INTO `d3orm_sample_test`.`user`
(`email`, `email_confirmed`, `password_hash`, `security_stamp`, `phone_number`, `phone_number_confirmed`, `two_factor_enabled`, `lockout_end_date_utc`, `lockout_enabled`, `access_failed_count`, `user_name`, `first_name`, `last_name`, `gender`, `date_of_birth`, `registration_date`, `external_login`, `registration_guid`, `guidexpiration_date`)
VALUES
('player1@team1.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player1@team1.com', 'Player1', 'ForTeam1', 'male', '2000-01-01', '2022-03-25', 0, NULL, NULL);
INSERT INTO `d3orm_sample_test`.`user`
(`email`, `email_confirmed`, `password_hash`, `security_stamp`, `phone_number`, `phone_number_confirmed`, `two_factor_enabled`, `lockout_end_date_utc`, `lockout_enabled`, `access_failed_count`, `user_name`, `first_name`, `last_name`, `gender`, `date_of_birth`, `registration_date`, `external_login`, `registration_guid`, `guidexpiration_date`)
VALUES
('player2@team1.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player2@team1.com', 'Player2', 'ForTeam1', 'female', '2000-01-02', '2022-03-26', 0, NULL, NULL);
INSERT INTO `d3orm_sample_test`.`user`
(`email`, `email_confirmed`, `password_hash`, `security_stamp`, `phone_number`, `phone_number_confirmed`, `two_factor_enabled`, `lockout_end_date_utc`, `lockout_enabled`, `access_failed_count`, `user_name`, `first_name`, `last_name`, `gender`, `date_of_birth`, `registration_date`, `external_login`, `registration_guid`, `guidexpiration_date`)
VALUES
('player1@team2.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player1@team2.com', 'Player1', 'ForTeam2', 'male', '2000-01-03', '2022-03-27', 0, NULL, NULL);
INSERT INTO `d3orm_sample_test`.`user`
(`email`, `email_confirmed`, `password_hash`, `security_stamp`, `phone_number`, `phone_number_confirmed`, `two_factor_enabled`, `lockout_end_date_utc`, `lockout_enabled`, `access_failed_count`, `user_name`, `first_name`, `last_name`, `gender`, `date_of_birth`, `registration_date`, `external_login`, `registration_guid`, `guidexpiration_date`)
VALUES
('player2@team2.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player2@team2.com', 'Player2', 'ForTeam2', 'female', '2000-01-04', '2022-03-28', 0, NULL, NULL);
INSERT INTO `d3orm_sample_test`.`user`
(`email`, `email_confirmed`, `password_hash`, `security_stamp`, `phone_number`, `phone_number_confirmed`, `two_factor_enabled`, `lockout_end_date_utc`, `lockout_enabled`, `access_failed_count`, `user_name`, `first_name`, `last_name`, `gender`, `date_of_birth`, `registration_date`, `external_login`, `registration_guid`, `guidexpiration_date`)
VALUES
('player1@team3.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player1@team3.com', 'Player1', 'ForTeam3', 'male', '2000-01-05', '2022-03-29', 0, NULL, NULL);
INSERT INTO `d3orm_sample_test`.`user`
(`email`, `email_confirmed`, `password_hash`, `security_stamp`, `phone_number`, `phone_number_confirmed`, `two_factor_enabled`, `lockout_end_date_utc`, `lockout_enabled`, `access_failed_count`, `user_name`, `first_name`, `last_name`, `gender`, `date_of_birth`, `registration_date`, `external_login`, `registration_guid`, `guidexpiration_date`)
VALUES
('player2@team3.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player2@team3.com', 'Player2', 'ForTeam3', 'female', '2000-01-06', '2022-03-30', 0, NULL, NULL);
INSERT INTO `d3orm_sample_test`.`user`
(`email`, `email_confirmed`, `password_hash`, `security_stamp`, `phone_number`, `phone_number_confirmed`, `two_factor_enabled`, `lockout_end_date_utc`, `lockout_enabled`, `access_failed_count`, `user_name`, `first_name`, `last_name`, `gender`, `date_of_birth`, `registration_date`, `external_login`, `registration_guid`, `guidexpiration_date`)
VALUES
('free.player@noteam.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'freeplayer@noteam.com', 'FreePlayer', 'NoTeam', 'male', '2000-01-07', '2022-03-31', 0, NULL, NULL);

Select  `user_id` INTO player11Id from `user` where `email` = 'player1@team1.com';
Select  `user_id` INTO player21Id from `user` where `email` = 'player2@team1.com';
Select  `user_id` INTO player12Id from `user` where `email` = 'player1@team2.com';
Select  `user_id` INTO player22Id from `user` where `email` = 'player2@team2.com';
Select  `user_id` INTO player13Id from `user` where `email` = 'player1@team3.com';
Select  `user_id` INTO player23Id from `user` where `email` = 'player2@team3.com';

-- user roles
INSERT INTO `d3orm_sample_test`.`user_role`
(`user_id`, `role_id`, `is_active`, `team_id_or_default`)
VALUES
(player11Id, 4, 1, 0);
INSERT INTO `d3orm_sample_test`.`user_role`
(`user_id`, `role_id`, `is_active`, `team_id_or_default`)
VALUES
(player21Id, 2, 1, 1);
INSERT INTO `d3orm_sample_test`.`user_role`
(`user_id`, `role_id`, `is_active`, `team_id_or_default`)
VALUES
(player12Id, 3, 1, 2);
INSERT INTO `d3orm_sample_test`.`user_role`
(`user_id`, `role_id`, `is_active`, `team_id_or_default`)
VALUES
(player22Id, 2, 1, 2);
INSERT INTO `d3orm_sample_test`.`user_role`
(`user_id`, `role_id`, `is_active`, `team_id_or_default`)
VALUES
(player13Id, 2, 1, 3);
INSERT INTO `d3orm_sample_test`.`user_role`
(`user_id`, `role_id`, `is_active`, `team_id_or_default`)
VALUES
(player23Id, 2, 1, 3);

-- teams
INSERT INTO `d3orm_sample_test`.`team`
(`name`, `logo`, `registration_date`, `is_active`, `last_change`, `changed_by`)
VALUES
('Team1', NULL, '2022-03-30', 1, '2022-03-30 09:00:00', 1);
INSERT INTO `d3orm_sample_test`.`team`
(`name`, `logo`, `registration_date`, `is_active`, `last_change`, `changed_by`)
VALUES
('Team2', NULL, '2022-03-30', 1, '2022-03-30 10:00:00', 1);
INSERT INTO `d3orm_sample_test`.`team`
(`name`, `logo`, `registration_date`, `is_active`, `last_change`, `changed_by`)
VALUES
('Team3', NULL, '2022-03-30', 1, '2022-03-30 11:00:00', 1);

INSERT INTO `d3orm_sample_test`.`team`
(`name`, `logo`, `registration_date`, `is_active`, `last_change`, `changed_by`)
VALUES
('NewTeam', NULL, '2022-03-30', 1, '2022-03-30 11:00:00', 1);

-- team players
Select  `team_id` INTO team1Id from `team` where `name` = 'Team1';
Select  `team_id` INTO team2Id from `team` where `name` = 'Team2';
Select  `team_id` INTO team3Id from `team` where `name` = 'Team3';

INSERT INTO `d3orm_sample_test`.`team_player`
(`team_id`, `player_id`, `last_change`, `changed_by`)
VALUES  (team1Id, player11Id, '2022-03-30 9:30:00', 1);
INSERT INTO `d3orm_sample_test`.`team_player`
(`team_id`, `player_id`, `last_change`, `changed_by`)
VALUES  (team1Id, player21Id, '2022-03-30 9:35:00', 1);
INSERT INTO `d3orm_sample_test`.`team_player`
(`team_id`, `player_id`, `last_change`, `changed_by`)
VALUES  (team2Id, player12Id, '2022-03-30 10:30:00', 1);
INSERT INTO `d3orm_sample_test`.`team_player`
(`team_id`, `player_id`, `last_change`, `changed_by`)
VALUES  (team2Id, player22Id, '2022-03-30 10:35:00', 1);
INSERT INTO `d3orm_sample_test`.`team_player`
(`team_id`, `player_id`, `last_change`, `changed_by`)
VALUES  (team3Id, player13Id, '2022-03-30 11:30:00', 1);
INSERT INTO `d3orm_sample_test`.`team_player`
(`team_id`, `player_id`, `last_change`, `changed_by`)
VALUES  (team3Id, player23Id, '2022-03-30 11:35:00', 1);

-- tour series
INSERT INTO `d3orm_sample_test`.`tour_serie` (`name`, `start_date`, `end_date`, `category`, `note`, `last_change`, `changed_by`)
VALUES
('TourSerie1',  '2022-04-01', '2022-06-30', 'Mix', NULL, '2022-03-31 11:35:00', 1);

-- addresses
INSERT INTO `d3orm_sample_test`.`address` (`name`, `state`, `town`, `street`, `house_number`, `last_change`, `changed_by`)
VALUES ('Gym', 'Czech republic', 'Praha', 'Sportovní', '1/2', '2022-03-31 12:10:00', 1);

-- tournament
Select  `address_id` INTO addressId from `address` where `name` = 'Gym';
Select  `tour_serie_id` INTO serieId from `tour_serie` where `name` = 'TourSerie1';

INSERT INTO `d3orm_sample_test`.`tournament` (`tour_serie_id`, `address_id`, `name`, `start_date`, `end_date`, `entry_fee`, `max_num_of_teams`, `note`, `last_change`, `changed_by`)
VALUES  (serieId, addressId, 'Tournament1', '2022-04-01', '2022-04-01', 200, 16, NULL, '2022-03-31 12:11:12', 1);
INSERT INTO `d3orm_sample_test`.`tournament` (`tour_serie_id`, `address_id`, `name`, `start_date`, `end_date`, `entry_fee`, `max_num_of_teams`, `note`, `last_change`, `changed_by`)
VALUES  (serieId, addressId, 'Tournament2', '2022-04-25', '2022-04-25', 350, 16, NULL, '2022-03-31 12:15:09', 1);

-- tournament teams
Select  `tournament_id` INTO tournamentId from `tournament` where `name` = 'Tournament1';


INSERT INTO `d3orm_sample_test`.`tournament_team` (`tournament_id`, `team_id`, `basic_group_name`, `registration_date`, `entry_fee_paid`, `last_change`, `changed_by`)
VALUES  (tournamentId, team1Id, 'Group A', '2022-03-31 14:18:10', 1, '2022-03-31 14:18:10', 1);
INSERT INTO `d3orm_sample_test`.`tournament_team` (`tournament_id`, `team_id`, `basic_group_name`, `registration_date`, `entry_fee_paid`, `last_change`, `changed_by`)
VALUES  (tournamentId, team2Id, 'Group A', '2022-03-31 17:24:59', 1, '2022-03-31 17:24:59', 1);
INSERT INTO `d3orm_sample_test`.`tournament_team` (`tournament_id`, `team_id`, `basic_group_name`, `registration_date`, `entry_fee_paid`, `last_change`, `changed_by`)
VALUES  (tournamentId, team3Id, 'Group A', '2022-04-01 07:19:10', 0, '2022-04-01 07:19:10', 1);

-- tournament team stats
Select  `tournament_team_id` INTO tournamentTeam1Id from `tournament_team` tt INNER JOIN `team` t ON tt.team_id = t.team_id WHERE t.`name` = 'Team1';
Select  `tournament_team_id` INTO tournamentTeam2Id from `tournament_team` tt INNER JOIN `team` t ON tt.team_id = t.team_id WHERE t.`name` = 'Team2';
Select  `tournament_team_id` INTO tournamentTeam3Id from `tournament_team` tt INNER JOIN `team` t ON tt.team_id = t.team_id WHERE t.`name` = 'Team3';

INSERT INTO `d3orm_sample_test`.`tournament_team_stat` (`tournament_team_id`, `tournament_phase`, `phase_points`, `wins`, `losts`, `ties`, `sets_won`, `sets_lost`, `score_plus`, `score_minus`, `last_change`, `changed_by`)
VALUES (tournamentTeam1Id, 0, 8, 2, 1, 0, 17, 1, 17*25, 18*25 - 25, '2022-04-01 18:45:00', 1);
INSERT INTO `d3orm_sample_test`.`tournament_team_stat` (`tournament_team_id`, `tournament_phase`, `phase_points`, `wins`, `losts`, `ties`, `sets_won`, `sets_lost`, `score_plus`, `score_minus`, `last_change`, `changed_by`)
VALUES (tournamentTeam2Id, 0, 9, 3, 0, 0, 18, 0, 18*25, 18*25 - 50, '2022-04-01 18:45:00', 1);
INSERT INTO `d3orm_sample_test`.`tournament_team_stat` (`tournament_team_id`, `tournament_phase`, `phase_points`, `wins`, `losts`, `ties`, `sets_won`, `sets_lost`, `score_plus`, `score_minus`, `last_change`, `changed_by`)
VALUES (tournamentTeam3Id, 0, 7, 1, 2, 0, 16, 2, 16*25, 18*25, '2022-04-01 18:45:00', 1);

-- matches
INSERT INTO `d3orm_sample_test`.`match` (`home_team_id`, `away_team_id`, `tournament_id`, `tournament_phase`, `winner_id`, `referee_id`, `match_date`, `last_change`, `changed_by`)
VALUES ( team1Id, team2Id, tournamentId, 0, team1Id, NULL, '2022-04-01 8:00:00', '2022-04-01 8:00:00', 1);
INSERT INTO `d3orm_sample_test`.`match` (`home_team_id`, `away_team_id`, `tournament_id`, `tournament_phase`, `winner_id`, `referee_id`, `match_date`, `last_change`, `changed_by`)
VALUES ( team2Id, team3Id, tournamentId, 0, team3Id, NULL, '2022-04-01 8:45:00', '2022-04-01 8:45:00', 1);
INSERT INTO `d3orm_sample_test`.`match` (`home_team_id`, `away_team_id`, `tournament_id`, `tournament_phase`, `winner_id`, `referee_id`, `match_date`, `last_change`, `changed_by`)
VALUES ( team1Id, team3Id, tournamentId, 0, team1Id, NULL, '2022-04-01 9:30:00', '2022-04-01 9:30:00', 1);

INSERT INTO `d3orm_sample_test`.`match` (`home_team_id`, `away_team_id`, `tournament_id`, `tournament_phase`, `winner_id`, `referee_id`, `match_date`, `last_change`, `changed_by`)
VALUES (3, 4, null, 0, 0, null, '2022-05-31 11:18:00', '2022-05-31 11:18:00', null);

-- match set scores
Select  `match_id` INTO match1Id from `match` where `home_team_id` = team1Id AND `away_team_id` = team2Id;
Select  `match_id` INTO match2Id from `match` where `home_team_id` = team2Id AND `away_team_id` = team3Id;
Select  `match_id` INTO match3Id from `match` where `home_team_id` = team1Id AND `away_team_id` = team3Id;


INSERT INTO `d3orm_sample_test`.`match_set_score` (`match_id`, `home_team_score`, `away_team_score`, `set_order`, `last_change`, `changed_by`)
VALUES ( match1Id, 23, 25, 1, '2022-04-01 8:15:00', 1);
INSERT INTO `d3orm_sample_test`.`match_set_score` (`match_id`, `home_team_score`, `away_team_score`, `set_order`, `last_change`, `changed_by`)
VALUES ( match1Id, 25, 22, 2, '2022-04-01 8:30:00', 1);
INSERT INTO `d3orm_sample_test`.`match_set_score` (`match_id`, `home_team_score`, `away_team_score`, `set_order`, `last_change`, `changed_by`)
VALUES ( match1Id, 25, 21, 3, '2022-04-01 8:45:00', 1);

INSERT INTO `d3orm_sample_test`.`match_set_score` (`match_id`, `home_team_score`, `away_team_score`, `set_order`, `last_change`, `changed_by`)
VALUES ( match2Id, 20, 25, 1, '2022-04-01 9:05:00', 1);
INSERT INTO `d3orm_sample_test`.`match_set_score` (`match_id`, `home_team_score`, `away_team_score`, `set_order`, `last_change`, `changed_by`)
VALUES ( match2Id, 19, 25, 2, '2022-04-01 9:18:00', 1);

INSERT INTO `d3orm_sample_test`.`match_set_score` (`match_id`, `home_team_score`, `away_team_score`, `set_order`, `last_change`, `changed_by`)
VALUES ( match3Id, 18, 25, 1, '2022-04-01 9:45:00', 1);
INSERT INTO `d3orm_sample_test`.`match_set_score` (`match_id`, `home_team_score`, `away_team_score`, `set_order`, `last_change`, `changed_by`)
VALUES ( match3Id, 25, 17, 2, '2022-04-01 10:10:00', 1);
INSERT INTO `d3orm_sample_test`.`match_set_score` (`match_id`, `home_team_score`, `away_team_score`, `set_order`, `last_change`, `changed_by`)
VALUES ( match3Id, 25, 16, 3, '2022-04-01 10:28:00', 1);

-- tournament player stats
INSERT INTO `d3orm_sample_test`.`tournament_player_stat` (`tournament_id`, `player_id`, `tour_points`, `attack_points`, `attack_percentage`, `service_points`, `service_percentage`, `unforced_errors`, `last_change`, `changed_by`)
VALUES  (tournamentId, player11Id, 10, 93, 93 + 4, 12, 95 + 4, 40, '2022-04-03 10:28:00', 1);
INSERT INTO `d3orm_sample_test`.`tournament_player_stat` (`tournament_id`, `player_id`, `tour_points`, `attack_points`, `attack_percentage`, `service_points`, `service_percentage`, `unforced_errors`, `last_change`, `changed_by`)
VALUES  (tournamentId, player21Id, 10, 83, 83 + 4, 11, 85 + 4, 39, '2022-04-03 10:38:00', 1);
INSERT INTO `d3orm_sample_test`.`tournament_player_stat` (`tournament_id`, `player_id`, `tour_points`, `attack_points`, `attack_percentage`, `service_points`, `service_percentage`, `unforced_errors`, `last_change`, `changed_by`)
VALUES  (tournamentId, player12Id, 09, 92, 92 + 4, 10, 94 + 4, 38, '2022-04-03 10:48:00', 1);
INSERT INTO `d3orm_sample_test`.`tournament_player_stat` (`tournament_id`, `player_id`, `tour_points`, `attack_points`, `attack_percentage`, `service_points`, `service_percentage`, `unforced_errors`, `last_change`, `changed_by`)
VALUES  (tournamentId, player22Id, 09, 82, 82 + 4, 09, 84 + 4, 37, '2022-04-03 10:58:00', 1);
INSERT INTO `d3orm_sample_test`.`tournament_player_stat` (`tournament_id`, `player_id`, `tour_points`, `attack_points`, `attack_percentage`, `service_points`, `service_percentage`, `unforced_errors`, `last_change`, `changed_by`)
VALUES  (tournamentId, player13Id, 08, 71, 71 + 4, 08, 73 + 4, 36, '2022-04-03 11:08:00', 1);
INSERT INTO `d3orm_sample_test`.`tournament_player_stat` (`tournament_id`, `player_id`, `tour_points`, `attack_points`, `attack_percentage`, `service_points`, `service_percentage`, `unforced_errors`, `last_change`, `changed_by`)
VALUES  (tournamentId, player23Id, 08, 61, 61 + 4, 07, 63 + 4, 35, '2022-04-03 11:18:00', 1);

-- playoff round couples
INSERT INTO `d3orm_sample_test`.`playoff_round_couple` (`tournament_team1_id`, `tournament_team2_id`, `playoff_round`, `team1_wins`, `team2_wins`, `last_change`, `changed_by`)
VALUES (1, 2, 1, 0, 0,  '2022-10-01', 1);

UPDATE `match` SET `playoff_round_couple_id` = 1 WHERE `match`.`match_id` < 4;

commit;
END;
$$

CALL insert_test_data();
$$

