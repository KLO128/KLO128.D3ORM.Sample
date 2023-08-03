﻿/* ---------------------------------------------------- */
/*  Generated by Enterprise Architect Version 14.1 		*/
/*  Created On : 15-říj-2022 15:27:21       			*/
/*  DBMS       : SQL Server 2012 						*/
/* ---------------------------------------------------- */

USE D3ORMSample;

/* Drop Foreign Key Constraints */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_Match_AwayTeam]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[Match] DROP CONSTRAINT [FK_Match_AwayTeam]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_Match_HomeTeam]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[Match] DROP CONSTRAINT [FK_Match_HomeTeam]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_Match_Tournament]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[Match] DROP CONSTRAINT [FK_Match_Tournament]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_Match_PlayoffRoundCouple]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[Match] DROP CONSTRAINT [FK_Match_PlayoffRoundCouple]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_MatchSetScore_Match]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[MatchSetScore] DROP CONSTRAINT [FK_MatchSetScore_Match]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_PlayoffRoundCouple_TournamentTeam1]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[PlayoffRoundCouple] DROP CONSTRAINT [FK_PlayoffRoundCouple_TournamentTeam1]

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_PlayoffRoundCouple_TournamentTeam2]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[PlayoffRoundCouple] DROP CONSTRAINT [FK_PlayoffRoundCouple_TournamentTeam2]

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_TeamPlayer_Team]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[TeamPlayer] DROP CONSTRAINT [FK_TeamPlayer_Team]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_TeamPlayer_User]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[TeamPlayer] DROP CONSTRAINT [FK_TeamPlayer_User]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_Id(N'[FK_Tournament_Address]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[Tournament] DROP CONSTRAINT [FK_Tournament_Address]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_Tournament_TourSerie]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[Tournament] DROP CONSTRAINT [FK_Tournament_TourSerie]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_TournamentTeam_Team]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [TournamentTeam] DROP CONSTRAINT [FK_TournamentTeam_Team]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_TournamentTeam_Tournament]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[TournamentTeam] DROP CONSTRAINT [FK_TournamentTeam_Tournament]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_TournamentTeamStat_TournamentTeam]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE [TournamentTeamStat] DROP CONSTRAINT [FK_TournamentTeamStat_TournamentTeam]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_TournamentPlayerStat_Tournament]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[TournamentPlayerStat] DROP CONSTRAINT [FK_TournamentPlayerStat_Tournament]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_TournamentPlayerStat_User]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[TournamentPlayerStat] DROP CONSTRAINT [FK_TournamentPlayerStat_User]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_UserClaim_User]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[UserClaim] DROP CONSTRAINT [FK_UserClaim_User]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_UserLogin_User]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[UserLogin] DROP CONSTRAINT [FK_UserLogin_User]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_UserRole_Role]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[UserRole] DROP CONSTRAINT [FK_UserRole_Role]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[FK_UserRole_User]') AND OBJECTPROPERTY(id, N'IsForeignKey') = 1) 
ALTER TABLE dbo.[UserRole] DROP CONSTRAINT [FK_UserRole_User]
GO

/* Drop Tables */

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Address]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[Address]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Match]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[Match]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[MatchSetScore]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[MatchSetScore]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[PlayoffRoundCouple]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[PlayoffRoundCouple]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Role]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[Role]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Team]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[Team]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[TeamPlayer]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[TeamPlayer]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[Tournament]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[Tournament]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[TournamentTeam]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[TournamentTeam]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[TournamentPlayerStat]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[TournamentPlayerStat]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[TourSerie]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[TourSerie]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[TournamentTeamStat]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[TournamentTeamStat]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[User]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[User]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[UserClaim]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[UserClaim]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[UserLogin]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[UserLogin]
GO

IF EXISTS (SELECT 1 FROM dbo.sysobjects WHERE id = object_id(N'[UserRole]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
DROP TABLE dbo.[UserRole]
GO

/* Create Tables */

CREATE TABLE dbo.[Address]
(
	[AddressId] int NOT NULL IDENTITY (1, 1),
	[Name] varchar(70) NOT NULL,
	[State] nvarchar(50) NOT NULL,
	[Town] nvarchar(50) NOT NULL,
	[Street] nvarchar(75) NOT NULL,
	[HouseNumber] varchar(50) NOT NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE dbo.[Match]
(
	[MatchId] int NOT NULL IDENTITY (1, 1),
	[HomeTeamId] int NOT NULL,
	[AwayTeamId] int NOT NULL,
    [TournamentId] int NULL,
    [TournamentPhase] int NOT NULL,
    [WinnerId] int NULL,
	[RefereeId] int NULL,
	[MatchDate] datetime NULL,
	[PlayoffRoundCoupleId] int NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE dbo.[MatchSetScore]
(
	[MatchSetScoreId] int NOT NULL IDENTITY (1, 1),
	[MatchId] int NOT NULL,
	[HomeTeamScore] int NOT NULL,
	[AwayTeamScore] int NOT NULL,
	[SetOrder] int NOT NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE [PlayoffRoundCouple]
(
	[PlayoffRoundCoupleId] int NOT NULL IDENTITY(1,1),
    [TournamentTeam1Id] int NOT NULL,
    [TournamentTeam2Id] int NOT NULL,
    [PlayoffRound] int NOT NULL,
    [Team1Wins] int NOT NULL,
    [Team2Wins] int NOT NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL,
)
GO

CREATE TABLE dbo.[Role]
(
	[RoleId] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(100) NOT NULL
)
GO

CREATE TABLE dbo.[Team]
(
	[TeamId] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(50) NOT NULL,
	[Logo] varchar(max) NULL,
	[RegistrationDate] datetime NOT NULL,
	[IsActive] bit NOT NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE dbo.[TeamPlayer]
(
	[TeamPlayerId] int NOT NULL IDENTITY (1, 1),
	[TeamId] int NOT NULL,
	[PlayerId] int NOT NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE dbo.[Tournament]
(
	[TournamentId] int NOT NULL IDENTITY (1, 1),
	[TourSerieId] int NULL,
	[AddressId] int NULL,
	[Name] nvarchar(100) NOT NULL,
	[StartDate] datetime NOT NULL,
	[EndDate] datetime NOT NULL,
	[EntryFee] float NULL,
	[MaxNumOfTeams] int NULL,
	[Note] nvarchar(100) NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE dbo.[TournamentTeam]
(
	[TournamentTeamId] int NOT NULL IDENTITY (1, 1),
	[TournamentId] int NOT NULL,
	[TeamId] int NOT NULL,
    [BasicGroupName] nvarchar(40) NULL,
	[RegistrationDate] datetime NOT NULL,
	[EntryFeePaid] bit NOT NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE dbo.[TournamentPlayerStat]
(
	[TournamentPlayerStatId] int NOT NULL IDENTITY (1, 1),
	[TournamentId] int NOT NULL,
	[PlayerId] int NOT NULL,
	[TourPoints] int NULL,
	[AttackPoints] int NULL,
	[AttackPercentage] float NULL,
	[ServicePoints] int NULL,
	[ServicePercentage] int NULL,
	[UnforcedErrors] int NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE dbo.[TourSerie]
(
	[TourSerieId] int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(100) NOT NULL,
	[StartDate] datetime NOT NULL,
	[EndDate] datetime NULL,
	[Category] nvarchar(50) NULL,
	[Note] nvarchar(100) NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE dbo.[TournamentTeamStat]
(
	[TournamentTeamStatId] int NOT NULL IDENTITY (1, 1),
	[TournamentTeamId] int NOT NULL,
	[TournamentPhase] int NOT NULL,
	[PhasePoints] int NOT NULL,
	[Wins] int NOT NULL,
	[Losts] int NOT NULL,
	[Ties] int NOT NULL,
	[SetsWon] int NOT NULL,
	[SetsLost] int NOT NULL,
	[ScorePlus] int NOT NULL,
	[ScoreMinus] int NOT NULL,
	[LastChange] datetime NOT NULL,
	[ChangedBy] int NULL
)
GO

CREATE TABLE dbo.[User]
(
	[UserId] int NOT NULL IDENTITY (1, 1),
	[Email] varchar(255) NOT NULL,
	[EmailConfirmed] bit NOT NULL,
	[PasswordHash] nvarchar(max) NULL,
	[SecurityStamp] nvarchar(max) NULL,
	[PhoneNumber] nvarchar(50) NULL,
	[PhoneNumberConfirmed] bit NOT NULL,
	[TwoFactorEnabled] bit NOT NULL,
	[LockoutEndDateUtc] datetime NULL,
	[LockoutEnabled] bit NOT NULL,
	[AccessFailedCount] int NOT NULL,
	[UserName] nvarchar(255) NOT NULL,
	[FirstName] nvarchar(75) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Gender] varchar(10) NOT NULL,
    [DateOfBirth] datetime NOT NULL,
    [RegistrationDate] datetime NOT NULL,
	[ExternalLogin] bit NOT NULL,
	[RegistrationGUID] varchar(100) NULL,
	[GUIDExpirationDate] datetime NULL
)
GO

CREATE TABLE dbo.[UserClaim]
(
	[UserClaimId] int NOT NULL IDENTITY (1, 1),
	[UserId] int NOT NULL,
	[ClaimType] nvarchar(max) NOT NULL,
	[ClaimValue] nvarchar(500) NOT NULL
)
GO

CREATE TABLE dbo.[UserLogin]
(
	[LoginProvider] nvarchar(128) NOT NULL,
	[ProviderKey] nvarchar(128) NOT NULL,
	[UserId] int NOT NULL
)
GO

CREATE TABLE dbo.[UserRole]
(
	[UserRoleId] int NOT NULL IDENTITY(1,1),
	[UserId] int NOT NULL,
	[RoleId] int NOT NULL,
    [IsActive] bit NOT NULL,
	[TeamIdOrDefault] int NOT NULL
)
GO

/* Create Primary Keys, Indexes, Uniques, Checks */

ALTER TABLE dbo.[Address] 
 ADD CONSTRAINT [PK_Address]
	PRIMARY KEY CLUSTERED ([AddressId] ASC)
GO

ALTER TABLE dbo.[Match] 
 ADD CONSTRAINT [PK_Match]
	PRIMARY KEY CLUSTERED ([MatchId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Match_Tournament] 
 ON dbo.[Match] ([TournamentId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Match_Home_Team] 
 ON dbo.[Match] ([HomeTeamId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Match_Away_Team] 
 ON dbo.[Match] ([AwayTeamId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Match_PlayoffRoundCouple]
	 ON dbo.[Match] ([PlayoffRoundCoupleId] ASC)
GO

ALTER TABLE dbo.[MatchSetScore] 
 ADD CONSTRAINT [PK_MatchSetScore]
	PRIMARY KEY CLUSTERED ([MatchSetScoreId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_MatchSetScore_Match] 
 ON dbo.[MatchSetScore] ([MatchId] ASC)
GO

ALTER TABLE dbo.[PlayoffRoundCouple] 
 ADD CONSTRAINT [PK_PlayoffRoundCouple]
	PRIMARY KEY CLUSTERED ([PlayoffRoundCoupleId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_PlayoffRoundCouple_TournamentTeam1]
	 ON dbo.[PlayoffRoundCouple] ([TournamentTeam1Id] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_PlayoffRoundCouple_TournamentTeam2]
	 ON dbo.[PlayoffRoundCouple] ([TournamentTeam2Id] ASC)
GO

ALTER TABLE dbo.[Role] 
 ADD CONSTRAINT [PK_Role]
	PRIMARY KEY CLUSTERED ([RoleId] ASC)
GO

ALTER TABLE dbo.[Team] 
 ADD CONSTRAINT [PK_Team]
	PRIMARY KEY CLUSTERED ([TeamId] ASC)
GO

ALTER TABLE dbo.[TeamPlayer] 
 ADD CONSTRAINT [PK_TeamPlayer]
	PRIMARY KEY CLUSTERED ([TeamPlayerId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_TeamPlayer_Team] 
 ON dbo.[TeamPlayer] ([TeamId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_TeamPlayer_User] 
 ON dbo.[TeamPlayer] ([PlayerId] ASC)
GO

ALTER TABLE dbo.[Tournament] 
 ADD CONSTRAINT [PK_Tournament]
	PRIMARY KEY CLUSTERED ([TournamentId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Tournament_Address] 
 ON dbo.[Tournament] ([AddressId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_Tournament_TourSerie] 
 ON dbo.[Tournament] ([TourSerieId] ASC)
GO

ALTER TABLE dbo.[TournamentTeam] 
 ADD CONSTRAINT [PK_TournamentTeam]
	PRIMARY KEY CLUSTERED ([TournamentTeamId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_TournamentTeam_Team] 
 ON dbo.[TournamentTeam] ([TeamId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_TournamentTeam_Tournament] 
 ON dbo.[TournamentTeam] ([TournamentId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_TournamentTeamStat_TournamentTeam] 
 ON dbo.[TournamentTeamStat] ([TournamentTeamId] ASC)
GO

ALTER TABLE dbo.[TournamentPlayerStat] 
 ADD CONSTRAINT [PK_TournamentPlayerStat]
	PRIMARY KEY CLUSTERED ([TournamentPlayerStatId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_TournamentPlayerStat_Tournament] 
 ON dbo.[TournamentPlayerStat] ([TournamentId] ASC)
GO

ALTER TABLE dbo.[TourSerie] 
 ADD CONSTRAINT [PK_Tour]
	PRIMARY KEY CLUSTERED ([TourSerieId] ASC)
GO

ALTER TABLE dbo.[TournamentTeamStat] 
 ADD CONSTRAINT [PK_Stats]
	PRIMARY KEY CLUSTERED ([TournamentTeamStatId] ASC)
GO

ALTER TABLE dbo.[User] 
 ADD CONSTRAINT [PK_User]
	PRIMARY KEY CLUSTERED ([UserId] ASC)
GO

ALTER TABLE dbo.[UserClaim] 
 ADD CONSTRAINT [PK_UserClaim]
	PRIMARY KEY CLUSTERED ([UserClaimId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_UserClaim_User] 
 ON dbo.[UserClaim] ([UserId] ASC)
GO

ALTER TABLE dbo.[UserLogin] 
 ADD CONSTRAINT [PK_UserLogin]
	PRIMARY KEY CLUSTERED ([LoginProvider] ASC,[ProviderKey] ASC,[UserId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_UserLogin_User] 
 ON dbo.[UserLogin] ([UserId] ASC)
GO

ALTER TABLE dbo.[UserRole] 
 ADD CONSTRAINT [PK_UserRole]
	PRIMARY KEY CLUSTERED ([UserRoleId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_UserRole_Role] 
 ON dbo.[UserRole] ([RoleId] ASC)
GO

CREATE NONCLUSTERED INDEX [IXFK_UserRole_User] 
 ON dbo.[UserRole] ([UserId] ASC)
GO

ALTER TABLE dbo.[User] ADD CONSTRAINT ch_User_Gender CHECK([Gender] in ('male', 'female')); 

/* Create Foreign Key Constraints */

ALTER TABLE dbo.[Match] ADD CONSTRAINT [FK_Match_AwayTeam]
	FOREIGN KEY ([AwayTeamId]) REFERENCES dbo.[Team] ([TeamId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[Match] ADD CONSTRAINT [FK_Match_HomeTeam]
	FOREIGN KEY ([HomeTeamId]) REFERENCES dbo.[Team] ([TeamId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[Match] ADD CONSTRAINT [FK_Match_PlayoffRoundCouple]
	FOREIGN KEY ([PlayoffRoundCoupleId]) REFERENCES dbo.[PlayoffRoundCouple] ([PlayoffRoundCoupleId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[Match] ADD CONSTRAINT [FK_Match_Tournament]
	FOREIGN KEY ([TournamentId]) REFERENCES dbo.[Tournament] ([TournamentId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[MatchSetScore] ADD CONSTRAINT [FK_MatchSetScore_Match]
	FOREIGN KEY ([MatchId]) REFERENCES dbo.[Match] ([MatchId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[PlayoffRoundCouple] ADD CONSTRAINT [FK_PlayoffRoundCouple_TournamentTeam1]
	FOREIGN KEY ([TournamentTeam1Id]) REFERENCES dbo.[TournamentTeam] ([TournamentTeamId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[PlayoffRoundCouple] ADD CONSTRAINT [FK_PlayoffRoundCouple_TournamentTeam2]
	FOREIGN KEY ([TournamentTeam2Id]) REFERENCES dbo.[TournamentTeam] ([TournamentTeamId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[TeamPlayer] ADD CONSTRAINT [FK_TeamPlayer_Team]
	FOREIGN KEY ([TeamId]) REFERENCES dbo.[Team] ([TeamId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[TeamPlayer] ADD CONSTRAINT [FK_TeamPlayer_User]
	FOREIGN KEY ([PlayerId]) REFERENCES dbo.[User] ([UserId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[Tournament] ADD CONSTRAINT [FK_Tournament_Address]
	FOREIGN KEY ([AddressId]) REFERENCES dbo.[Address] ([AddressId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[Tournament] ADD CONSTRAINT [FK_Tournament_TourSerie]
	FOREIGN KEY ([TourSerieId]) REFERENCES dbo.[TourSerie] ([TourSerieId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[TournamentTeam] ADD CONSTRAINT [FK_TournamentTeam_Team]
	FOREIGN KEY ([TeamId]) REFERENCES dbo.[Team] ([TeamId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[TournamentTeam] ADD CONSTRAINT [FK_TournamentTeam_Tournament]
	FOREIGN KEY ([TournamentId]) REFERENCES dbo.[Tournament] ([TournamentId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[TournamentTeamStat] ADD CONSTRAINT [FK_TournamentTeamStat_TournamentTeam]
	FOREIGN KEY ([TournamentTeamId]) REFERENCES dbo.[TournamentTeam] ([TournamentTeamId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[TournamentPlayerStat] ADD CONSTRAINT [FK_TournamentPlayerStat_Tournament]
	FOREIGN KEY ([TournamentId]) REFERENCES dbo.[Tournament] ([TournamentId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[TournamentPlayerStat] ADD CONSTRAINT [FK_TournamentPlayerStat_User]
	FOREIGN KEY ([PlayerId]) REFERENCES dbo.[User] ([UserId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[UserClaim] ADD CONSTRAINT [FK_UserClaim_User]
	FOREIGN KEY ([UserId]) REFERENCES dbo.[User] ([UserId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[UserLogin] ADD CONSTRAINT [FK_UserLogin_User]
	FOREIGN KEY ([UserId]) REFERENCES dbo.[User] ([UserId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[UserRole] ADD CONSTRAINT [FK_UserRole_Role]
	FOREIGN KEY ([RoleId]) REFERENCES dbo.[Role] ([RoleId]) ON DELETE No Action ON UPDATE No Action
GO

ALTER TABLE dbo.[UserRole] ADD CONSTRAINT [FK_UserRole_User]
	FOREIGN KEY ([UserId]) REFERENCES dbo.[User] ([UserId]) ON DELETE No Action ON UPDATE No Action
GO

/* additional indexes */

CREATE NONCLUSTERED INDEX [IX_TeamName] 
 ON dbo.[Team] ([Name] ASC)
GO

INSERT INTO [Role] ([Name]) VALUES ('Host');
INSERT INTO [Role] ([Name]) VALUES ('Player');
INSERT INTO [Role] ([Name]) VALUES ('TeamAdmin');
INSERT INTO [Role] ([Name]) VALUES ('Admin');