/* ---------------------------------------------------- */
/*  Created On : 30-bře-2022 18:31:12 				    */
/*  DBMS       : MySQL						            */
/* ---------------------------------------------------- */
/* Drop Tables */

DROP TABLE  iF EXISTS `match_set_score` CASCADE;
DROP TABLE  iF EXISTS `match` CASCADE;
DROP TABLE  iF EXISTS `playoff_round_couple` CASCADE;

DROP TABLE  iF EXISTS `tournament_team_stat` CASCADE;

DROP TABLE  iF EXISTS `tournament_team` CASCADE;

DROP TABLE  iF EXISTS `tournament_player_stat` CASCADE;

DROP TABLE iF EXISTS `team_player` CASCADE;

DROP TABLE  iF EXISTS `tournament` CASCADE;
DROP TABLE  iF EXISTS `tour_serie` CASCADE;



DROP TABLE  iF EXISTS `team` CASCADE;

DROP TABLE  iF EXISTS `user_claim` CASCADE;

DROP TABLE  iF EXISTS `user_login` CASCADE;

DROP TABLE  iF EXISTS `user_role` CASCADE;

DROP TABLE  iF EXISTS `user` CASCADE;

DROP TABLE  iF EXISTS `role` CASCADE;

DROP TABLE  iF EXISTS `address` CASCADE;

/* Create Tables */

CREATE TABLE `address`
(
	`address_id` int NOT NULL AUTO_INCREMENT,
	`name` varchar(70) NOT NULL,
	`state` nvarchar(50) NOT NULL,
	`town` nvarchar(50) NOT NULL,
	`street` nvarchar(75) NOT NULL,
	`house_number` varchar(50) NOT NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__address`
	PRIMARY KEY CLUSTERED (`address_id` ASC)
)
;

CREATE TABLE `match`
(
	`match_id` int NOT NULL AUTO_INCREMENT,
	`home_team_id` int NOT NULL,
	`away_team_id` int NOT NULL,
	`tournament_id` int NULL,
	`tournament_phase` int NOT NULL,
    `winner_id` int NULL,
	`referee_id` int NULL,
    `match_date` datetime NULL,
    `playoff_round_couple_id` int NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__match`
	PRIMARY KEY CLUSTERED (`match_id` ASC)
)
;

CREATE TABLE `match_set_score`
(
	`match_set_score_id` int NOT NULL AUTO_INCREMENT,
    `match_id` int NOT NULL,
	`home_team_score` int NOT NULL,
	`away_team_score` int NOT NULL,
	`set_order` int NOT NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__match_set_score`
	PRIMARY KEY CLUSTERED (`match_set_score_id` ASC)
)
;

CREATE TABLE `playoff_round_couple`
(
	`playoff_round_couple_id` int NOT NULL AUTO_INCREMENT,
    `tournament_team1_id` int NOT NULL,
    `tournament_team2_id` int NOT NULL,
    `playoff_round` int NOT NULL,
    `team1_wins` int NOT NULL,
    `team2_wins` int NOT NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
	CONSTRAINT `pk__playoff_round_couple`
	PRIMARY KEY CLUSTERED (`playoff_round_couple_id` ASC)
);

CREATE TABLE `role`
(
	`role_id` int NOT NULL AUTO_INCREMENT,
	`name` nvarchar(100) NOT NULL,
    CONSTRAINT `pk__role`
	PRIMARY KEY CLUSTERED (`role_id` ASC)
)
;

CREATE TABLE `team`
(
	`team_id` int NOT NULL AUTO_INCREMENT,
	`name` nvarchar(50) NOT NULL,
	`logo` varchar(4000) NULL,
	`registration_date` datetime NOT NULL,
	`is_active` bool NOT NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__team`
	PRIMARY KEY CLUSTERED (`team_id` ASC)
)
;

CREATE TABLE `team_player`
(
	`team_player_id` int NOT NULL AUTO_INCREMENT,
	`team_id` int NOT NULL,
	`player_id` int NOT NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__team_player`
	PRIMARY KEY CLUSTERED (`team_player_id` ASC)
)
;

CREATE TABLE `tournament`
(
	`tournament_id` int NOT NULL AUTO_INCREMENT,
	`tour_serie_id` int NULL,
	`address_id` int NULL,
	`name` nvarchar(100) NOT NULL,
	`start_date` datetime NOT NULL,
	`end_date` datetime NOT NULL,
	`entry_fee` float NULL,
	`max_num_of_teams` int NULL,
	`note` nvarchar(100) NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__tournament`
	PRIMARY KEY CLUSTERED (`tournament_id` ASC)
)
;

CREATE TABLE `tournament_team`
(
	`tournament_team_id` int NOT NULL AUTO_INCREMENT,
	`tournament_id` int NOT NULL,
	`team_id` int NOT NULL,
    `basic_group_name` nvarchar(25) NULL,
	`registration_date` datetime NOT NULL,
	`entry_fee_paid` bool NOT NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__tournament_team`
	PRIMARY KEY CLUSTERED (`tournament_team_id` ASC)
)
;

CREATE TABLE `tournament_player_stat`
(
	`tournament_player_stat_id` int NOT NULL AUTO_INCREMENT,
	`tournament_id` int NOT NULL,
	`player_id` int NOT NULL,
	`tour_points` int NULL,
	`attack_points` int NULL,
	`attack_percentage` float NULL,
	`service_points` int NULL,
	`service_percentage` int NULL,
	`unforced_errors` int NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__tournament_player_stat`
	PRIMARY KEY CLUSTERED (`tournament_player_stat_id` ASC)
)
;

CREATE TABLE `tour_serie`
(
	`tour_serie_id` int NOT NULL AUTO_INCREMENT,
	`name` nvarchar(100) NOT NULL,
	`start_date` datetime NOT NULL,
	`end_date` datetime NULL,
	`category` nvarchar(50) NULL,
	`note` nvarchar(100) NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__tour`
	PRIMARY KEY CLUSTERED (`tour_serie_id` ASC)
)
;

CREATE TABLE `tournament_team_stat`
(
	`tournament_team_stat_id` int NOT NULL AUTO_INCREMENT,
    `tournament_team_id` int NOT NULL,
	`tournament_phase` int NOT NULL,
    `phase_points` int NOT NULL,
	`wins` int NOT NULL,
	`losts` int NOT NULL,
	`ties` int NOT NULL,
	`sets_won` int NOT NULL,
	`sets_lost` int NOT NULL,
	`score_plus` int NOT NULL,
	`score_minus` int NOT NULL,
	`last_change` datetime NOT NULL,
	`changed_by` int NULL,
    CONSTRAINT `pk__tournament_team_stat`
	PRIMARY KEY CLUSTERED (`tournament_team_stat_id` ASC)
)
;

CREATE TABLE `user`
(
	`user_id` int NOT NULL AUTO_INCREMENT,
	`email` varchar(255) NOT NULL,
	`email_confirmed` bool NOT NULL,
	`password_hash` nvarchar(2000) NULL,
	`security_stamp` nvarchar(2000) NULL,
	`phone_number` nvarchar(50) NULL,
	`phone_number_confirmed` bool NOT NULL,
	`two_factor_enabled` bool NOT NULL,
	`lockout_end_date_utc` datetime NULL,
	`lockout_enabled` bool NOT NULL,
	`access_failed_count` int NOT NULL,
	`user_name` nvarchar(255) NOT NULL,
	`first_name` nvarchar(75) NOT NULL,
	`last_name` nvarchar(50) NOT NULL,
	`gender` varchar(10) NOT NULL,
    `date_of_birth` datetime NOT NULL,
    `registration_date` datetime NOT NULL,
	`external_login` bool NOT NULL,
	`registration_guid` varchar(100) NULL,
	`guidexpiration_date` datetime NULL,
    CONSTRAINT `pk__user`
	PRIMARY KEY CLUSTERED (`user_id` ASC)
)
;

CREATE TABLE `user_claim`
(
	`user_claim_id` int NOT NULL AUTO_INCREMENT,
	`user_id` int NOT NULL,
	`claim_type` nvarchar(1000) NOT NULL,
	`claim_value` nvarchar(500) NOT NULL,
    CONSTRAINT `pk__user_claim`
	PRIMARY KEY CLUSTERED (`user_claim_id` ASC)
)
;

CREATE TABLE `user_login`
(
	`login_provider` nvarchar(128) NOT NULL,
	`provider_key` nvarchar(128) NOT NULL,
	`user_id` int NOT NULL,
    CONSTRAINT `pk__user_login`
	PRIMARY KEY CLUSTERED (`login_provider` ASC,`provider_key` ASC,`user_id` ASC)
)
;

CREATE TABLE `user_role`
(
	`user_role_id` int NOT NULL AUTO_INCREMENT,
	`user_id` int NOT NULL,
	`role_id` int NOT NULL,
    `is_active` bool NOT NULL,
    `team_id_or_default` int NOT NULL,
    CONSTRAINT `pk__user_role`
	PRIMARY KEY CLUSTERED (`user_role_id` ASC)
)
;

/* Create Indexes, Uniques, Checks */

CREATE INDEX `ixfk__match__tournament` 
 ON `match` (`tournament_id` ASC)
;

CREATE INDEX `ixfk__match__home_team` 
 ON `match` (`home_team_id` ASC)
;

CREATE INDEX `ixfk__match__away_team` 
 ON `match` (`away_team_id` ASC)
;

CREATE INDEX `ixfk__match__playoff_round_couple` 
 ON `match` (`playoff_round_couple_id` ASC)
;

CREATE INDEX `ixfk__match_set_score__match` 
 ON `match_set_score` (`match_id` ASC)
;

CREATE INDEX `ixfk__playoff_round_couple__tournament_team1` 
 ON `playoff_round_couple` (`tournament_team1_id` ASC)
;

CREATE INDEX `ixfk__playoff_round_couple__tournament_team2` 
 ON `playoff_round_couple` (`tournament_team2_id` ASC)
;

CREATE INDEX `ixfk__team_player__team` 
 ON `team_player` (`team_id` ASC)
;

CREATE INDEX `ixfk__team_player__user` 
 ON `team_player` (`player_id` ASC)
;

CREATE INDEX `ixfk__tournament__address` 
 ON `tournament` (`address_id` ASC)
;

CREATE INDEX `ixfk__tournament__tour_serie` 
 ON `tournament` (`tour_serie_id` ASC)
;

CREATE INDEX `ixfk__tournament_team__team` 
 ON `tournament_team` (`team_id` ASC)
;

CREATE INDEX `ixfk__tournament_team__tournament` 
 ON `tournament_team` (`tournament_id` ASC)
;

CREATE INDEX `ixfk__tournament_team_stat__tournament_team` 
 ON `tournament_team_stat` (`tournament_team_id` ASC)
;

CREATE INDEX `ixfk__tournament_player_stat__tournament` 
 ON `tournament_player_stat` (`tournament_id` ASC)
;

CREATE INDEX `ixfk__user_claim__user` 
 ON `user_claim` (`user_id` ASC)
;

CREATE INDEX `ixfk__user_login__user` 
 ON `user_login` (`user_id` ASC)
;

CREATE INDEX `ixfk__user_role__role` 
 ON `user_role` (`role_id` ASC)
;

CREATE INDEX `ixfk__user_role__user` 
 ON `user_role` (`user_id` ASC)
;

ALTER TABLE `user` ADD CONSTRAINT ch__user__gender CHECK(`gender` in ('male', 'female')); 

/* Create Foreign Key Constraints */
ALTER TABLE `match` ADD CONSTRAINT `fk__match__tournament`
	FOREIGN KEY (`tournament_id`) REFERENCES `tournament` (`tournament_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `match` ADD CONSTRAINT `fk__match__away_team`
	FOREIGN KEY (`away_team_id`) REFERENCES `team` (`team_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `match` ADD CONSTRAINT `fk__match__home_team`
	FOREIGN KEY (`home_team_id`) REFERENCES `team` (`team_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `match` ADD CONSTRAINT `fk__match__playoff_round_couple`
	FOREIGN KEY (`playoff_round_couple_id`) REFERENCES `playoff_round_couple` (`playoff_round_couple_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `playoff_round_couple` ADD CONSTRAINT `fk__playoff_round_couple_tournament_team1`
	FOREIGN KEY (`tournament_team1_id`) REFERENCES `tournament_team` (`tournament_team_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `playoff_round_couple` ADD CONSTRAINT `fk__playoff_round_couple_tournament_team2`
	FOREIGN KEY (`tournament_team2_id`) REFERENCES `tournament_team` (`tournament_team_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `match_set_score` ADD CONSTRAINT `fk__match_set_score__match`
	FOREIGN KEY (`match_id`) REFERENCES `match` (`match_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `team_player` ADD CONSTRAINT `fk__team_player__team`
	FOREIGN KEY (`team_id`) REFERENCES `team` (`team_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `team_player` ADD CONSTRAINT `fk__team_player__user`
	FOREIGN KEY (`player_id`) REFERENCES `user` (`user_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `tournament` ADD CONSTRAINT `fk__tournament__address`
	FOREIGN KEY (`address_id`) REFERENCES `address` (`address_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `tournament` ADD CONSTRAINT `fk__tournament__tour_serie`
	FOREIGN KEY (`tour_serie_id`) REFERENCES `tour_serie` (`tour_serie_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `tournament_team` ADD CONSTRAINT `fk__tournament_team__team`
	FOREIGN KEY (`team_id`) REFERENCES `team` (`team_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `tournament_team` ADD CONSTRAINT `fk__tournament_team__tournament`
	FOREIGN KEY (`tournament_id`) REFERENCES `tournament` (`tournament_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `tournament_team_stat` ADD CONSTRAINT `fk__tournament_team_stat__tournament_team`
	FOREIGN KEY (`tournament_team_id`) REFERENCES `tournament_team` (`tournament_team_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `tournament_player_stat` ADD CONSTRAINT `fk__tournament_player_stat__tournament`
	FOREIGN KEY (`tournament_id`) REFERENCES `tournament` (`tournament_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `tournament_player_stat` ADD CONSTRAINT `fk__tournament_player_stat__user`
	FOREIGN KEY (`player_id`) REFERENCES `user` (`user_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `user_claim` ADD CONSTRAINT `fk__user_claim__user`
	FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `user_login` ADD CONSTRAINT `fk__user_login__user`
	FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `user_role` ADD CONSTRAINT `fk__user_role__role`
	FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE `user_role` ADD CONSTRAINT `fk__user_role__user`
	FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`) ON DELETE No Action ON UPDATE No Action
;

/* additional indexes */

CREATE INDEX `ix__team_name` 
 ON `team` (`name` ASC)
;

INSERT INTO `role` (`name`) VALUES ('Host');
INSERT INTO `role` (`name`) VALUES ('Player');
INSERT INTO `role` (`name`) VALUES ('TeamAdmin');
INSERT INTO `role` (`name`) VALUES ('Admin');
