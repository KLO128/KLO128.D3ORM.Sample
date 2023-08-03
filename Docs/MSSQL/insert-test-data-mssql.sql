USE [D3ORMSample];

BEGIN TRY  
     BEGIN Transaction;

	DECLARE @team1Id int;
	DECLARE @team2Id int;
	DECLARE @team3Id int;
	DECLARE @player11Id int;
	DECLARE @player21Id int;
	DECLARE @player12Id int;
	DECLARE @player22Id int;
	DECLARE @player13Id int;
	DECLARE @player23Id int;
	DECLARE @addressId int;
	DECLARE @serieId int;
	DECLARE @tournamentTeam1Id int;
	DECLARE @tournamentTeam2Id int;
	DECLARE @tournamentTeam3Id int;
	DECLARE @tournamentId int;
	DECLARE @match1Id int;
	DECLARE @match2Id int;
	DECLARE @match3Id int;

	-- users
	INSERT INTO dbo.[User]
	([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
	VALUES
	('player1@team1.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player1@team1.com', 'Player1', 'ForTeam1', 'male', '2000-01-01', '2022-03-25', 0, NULL, NULL);
	INSERT INTO dbo.[User]
	([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
	VALUES
	('player2@team1.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player2@team1.com', 'Player2', 'ForTeam1', 'female', '2000-01-02', '2022-03-26', 0, NULL, NULL);
	INSERT INTO dbo.[User]
	([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
	VALUES
	('player1@team2.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player1@team2.com', 'Player1', 'ForTeam2', 'male', '2000-01-03', '2022-03-27', 0, NULL, NULL);
	INSERT INTO dbo.[User]
	([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
	VALUES
	('player2@team2.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player2@team2.com', 'Player2', 'ForTeam2', 'female', '2000-01-04', '2022-03-28', 0, NULL, NULL);
	INSERT INTO dbo.[User]
	([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
	VALUES
	('player1@team3.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player1@team3.com', 'Player1', 'ForTeam3', 'male', '2000-01-05', '2022-03-29', 0, NULL, NULL);
	INSERT INTO dbo.[User]
	([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
	VALUES
	('player2@team3.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player2@team3.com', 'Player2', 'ForTeam3', 'female', '2000-01-06', '2022-03-30', 0, NULL, NULL);
	INSERT INTO dbo.[User]
	([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
	VALUES
	('free.player@noteam.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'freeplayer@noteam.com', 'FreePlayer', 'NoTeam', 'male', '2000-01-07', '2022-03-31', 0, NULL, NULL);

	SET @player11Id = (Select  [UserId] from dbo.[User] where [Email] = 'player1@team1.com');
	SET @player21Id = (Select  [UserId] from dbo.[User] where [Email] = 'player2@team1.com');
	SET @player12Id = (Select  [UserId] from dbo.[User] where [Email] = 'player1@team2.com');
	SET @player22Id = (Select  [UserId] from dbo.[User] where [Email] = 'player2@team2.com');
	SET @player13Id = (Select  [UserId] from dbo.[User] where [Email] = 'player1@team3.com');
	SET @player23Id = (Select  [UserId] from dbo.[User] where [Email] = 'player2@team3.com');

	-- user roles
	INSERT INTO dbo.[UserRole]
	([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
	VALUES
	(@player11Id, 4, 1, 0);
	INSERT INTO dbo.[UserRole]
	([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
	VALUES
	(@player21Id, 2, 1, 1);
	INSERT INTO dbo.[UserRole]
	([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
	VALUES
	(@player12Id, 3, 1, 2);
	INSERT INTO dbo.[UserRole]
	([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
	VALUES
	(@player22Id, 2, 1, 2);
	INSERT INTO dbo.[UserRole]
	([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
	VALUES
	(@player13Id, 2, 1, 3);
	INSERT INTO dbo.[UserRole]
	([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
	VALUES
	(@player23Id, 2, 1, 3);

	-- teams
	INSERT INTO dbo.[Team]
	([Name], [Logo], [RegistrationDate], [IsActive], [LastChange], [ChangedBy])
	VALUES
	('Team1', NULL, '2022-03-30', 1, '2022-03-30 09:00:00', 1);
	INSERT INTO dbo.[Team]
	([Name], [Logo], [RegistrationDate], [IsActive], [LastChange], [ChangedBy])
	VALUES
	('Team2', NULL, '2022-03-30', 1, '2022-03-30 10:00:00', 1);
	INSERT INTO dbo.[Team]
	([Name], [Logo], [RegistrationDate], [IsActive], [LastChange], [ChangedBy])
	VALUES
	('Team3', NULL, '2022-03-30', 1, '2022-03-30 11:00:00', 1);

	INSERT INTO dbo.[Team]
	([Name], [Logo], [RegistrationDate], [IsActive], [LastChange], [ChangedBy])
	VALUES
	('NewTeam', NULL, '2022-03-30', 1, '2022-03-30 11:00:00', 1);

	-- team players
	SET @team1Id = (Select  [teamId] from dbo.[Team] where [Name] = 'Team1');
	SET @team2Id = (Select  [teamId] from dbo.[Team] where [Name] = 'Team2');
	SET @team3Id = (Select  [teamId] from dbo.[Team] where [Name] = 'Team3');

	INSERT INTO dbo.[TeamPlayer]
	([TeamId], [PlayerId], [LastChange], [ChangedBy])
	VALUES  (@team1Id, @player11Id, '2022-03-30 9:30:00', 1);
	INSERT INTO dbo.[TeamPlayer]
	([TeamId], [PlayerId], [LastChange], [ChangedBy])
	VALUES  (@team1Id, @player21Id, '2022-03-30 9:35:00', 1);
	INSERT INTO dbo.[TeamPlayer]
	([TeamId], [PlayerId], [LastChange], [ChangedBy])
	VALUES  (@team2Id, @player12Id, '2022-03-30 10:30:00', 1);
	INSERT INTO dbo.[TeamPlayer]
	([TeamId], [PlayerId], [LastChange], [ChangedBy])
	VALUES  (@team2Id, @player22Id, '2022-03-30 10:35:00', 1);
	INSERT INTO dbo.[TeamPlayer]
	([TeamId], [PlayerId], [LastChange], [ChangedBy])
	VALUES  (@team3Id, @player13Id, '2022-03-30 11:30:00', 1);
	INSERT INTO dbo.[TeamPlayer]
	([TeamId], [PlayerId], [LastChange], [ChangedBy])
	VALUES  (@team3Id, @player23Id, '2022-03-30 11:35:00', 1);

	-- tour series
	INSERT INTO dbo.[TourSerie] ([Name], [StartDate], [EndDate], [Category], [Note], [LastChange], [ChangedBy])
	VALUES
	('TourSerie1',  '2022-04-01', '2022-06-30', 'Mix', NULL, '2022-03-31 11:35:00', 1);

	-- addresses
	INSERT INTO dbo.[Address] ([Name], [State], [Town], [Street], [HouseNumber], [LastChange], [ChangedBy])
	VALUES ('Gym', 'Czech republic', 'Praha', 'Sportovní', '1/2', '2022-03-31 12:10:00', 1);

	-- tournament
	SET @addressId = (Select  [AddressId] from dbo.[Address] where [Name] = 'Gym');
	SET @serieId = (Select  [TourSerieId] from dbo.[TourSerie] where [Name] = 'TourSerie1');

	INSERT INTO dbo.[Tournament] ([TourSerieId], [AddressId], [Name], [StartDate], [EndDate], [EntryFee], [MaxNumOfTeams], [Note], [LastChange], [ChangedBy])
	VALUES  (@serieId, @addressId, 'Tournament1', '2022-04-01', '2022-04-01', 200, 16, NULL, '2022-03-31 12:11:12', 1);
	INSERT INTO dbo.[Tournament] ([TourSerieId], [AddressId], [Name], [StartDate], [EndDate], [EntryFee], [MaxNumOfTeams], [Note], [LastChange], [ChangedBy])
	VALUES  (@serieId, @addressId, 'Tournament2', '2022-04-25', '2022-04-25', 350, 16, NULL, '2022-03-31 12:15:09', 1);

	-- tournament teams
	SET @tournamentId = (Select  [TournamentId] from dbo.[Tournament] where [Name] = 'Tournament1');


	INSERT INTO dbo.[TournamentTeam] ([TournamentId], [TeamId], [BasicGroupName], [RegistrationDate], [EntryFeePaid], [LastChange], [ChangedBy])
	VALUES  (@tournamentId, @team1Id, 'Group A', '2022-03-31 14:18:10', 1, '2022-03-31 14:18:10', 1);
	INSERT INTO dbo.[TournamentTeam] ([TournamentId], [TeamId], [BasicGroupName], [RegistrationDate], [EntryFeePaid], [LastChange], [ChangedBy])
	VALUES  (@tournamentId, @team2Id, 'Group A', '2022-03-31 17:24:59', 1, '2022-03-31 17:24:59', 1);
	INSERT INTO dbo.[TournamentTeam] ([TournamentId], [TeamId], [BasicGroupName], [RegistrationDate], [EntryFeePaid], [LastChange], [ChangedBy])
	VALUES  (@tournamentId, @team3Id, 'Group A', '2022-04-01 07:19:10', 0, '2022-04-01 07:19:10', 1);

	-- tournament team stats
	SET @tournamentTeam1Id = (Select  [TournamentTeamId] from dbo.[TournamentTeam] tt INNER JOIN [Team] t ON tt.[TeamId] = t.[TeamId] WHERE t.[Name] = 'Team1');
	SET @tournamentTeam2Id = (Select  [TournamentTeamId] from dbo.[TournamentTeam] tt INNER JOIN [Team] t ON tt.[TeamId] = t.[TeamId] WHERE t.[Name] = 'Team2');
	SET @tournamentTeam3Id = (Select  [TournamentTeamId] from dbo.[TournamentTeam] tt INNER JOIN [Team] t ON tt.[TeamId] = t.[TeamId] WHERE t.[Name] = 'Team3');

	INSERT INTO dbo.[TournamentTeamStat] ([TournamentTeamId], [TournamentPhase], [PhasePoints], [Wins], [Losts], [Ties], [SetsWon], [SetsLost], [ScorePlus], [ScoreMinus], [LastChange], [ChangedBy])
	VALUES (@tournamentTeam1Id, 0, 8, 2, 1, 0, 17, 1, 17*25, 18*25 - 25, '2022-04-01 18:45:00', 1);
	INSERT INTO dbo.[TournamentTeamStat] ([TournamentTeamId], [TournamentPhase], [PhasePoints], [Wins], [Losts], [Ties], [SetsWon], [SetsLost], [ScorePlus], [ScoreMinus], [LastChange], [ChangedBy])
	VALUES (@tournamentTeam2Id, 0, 9, 3, 0, 0, 18, 0, 18*25, 18*25 - 50, '2022-04-01 18:45:00', 1);
	INSERT INTO dbo.[TournamentTeamStat] ([TournamentTeamId], [TournamentPhase], [PhasePoints], [Wins], [Losts], [Ties], [SetsWon], [SetsLost], [ScorePlus], [ScoreMinus], [LastChange], [ChangedBy])
	VALUES (@tournamentTeam3Id, 0, 7, 1, 2, 0, 16, 2, 16*25, 18*25, '2022-04-01 18:45:00', 1);

	-- matches
	INSERT INTO dbo.[Match] ([HomeTeamId], [AwayTeamId], [TournamentId], [TournamentPhase], [WinnerId], [RefereeId], [MatchDate], [LastChange], [ChangedBy])
	VALUES ( @team1Id, @team2Id, @tournamentId, 0, @team1Id, NULL, '2022-04-01 8:00:00', '2022-04-01 8:00:00', 1);
	INSERT INTO dbo.[Match] ([HomeTeamId], [AwayTeamId], [TournamentId], [TournamentPhase], [WinnerId], [RefereeId], [MatchDate], [LastChange], [ChangedBy])
	VALUES ( @team2Id, @team3Id, @tournamentId, 0, @team3Id, NULL, '2022-04-01 8:45:00', '2022-04-01 8:45:00', 1);
	INSERT INTO dbo.[Match] ([HomeTeamId], [AwayTeamId], [TournamentId], [TournamentPhase], [WinnerId], [RefereeId], [MatchDate], [LastChange], [ChangedBy])
	VALUES ( @team1Id, @team3Id, @tournamentId, 0, @team1Id, NULL, '2022-04-01 9:30:00', '2022-04-01 9:30:00', 1);

	INSERT INTO dbo.[Match] ([HomeTeamId], [AwayTeamId], [TournamentId], [TournamentPhase], [WinnerId], [RefereeId], [MatchDate], [LastChange], [ChangedBy])
	VALUES (3, 4, null, 0, 0, null, '2022-05-31 11:18:00', '2022-05-31 11:18:00', null);

	-- match set scores
	SET @match1Id = (Select  [MatchId] from dbo.[Match] where [homeTeamId] = @team1Id AND [awayTeamId] = @team2Id);
	SET @match2Id = (Select  [MatchId] from dbo.[Match] where [homeTeamId] = @team2Id AND [awayTeamId] = @team3Id);
	SET @match3Id = (Select  [MatchId] from dbo.[Match] where [homeTeamId] = @team1Id AND [awayTeamId] = @team3Id);


	INSERT INTO dbo.[MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
	VALUES (@match1Id, 23, 25, 1, '2022-04-01 8:15:00', 1);
	INSERT INTO dbo.[MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
	VALUES (@match1Id, 25, 22, 2, '2022-04-01 8:30:00', 1);
	INSERT INTO dbo.[MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
	VALUES (@match1Id, 25, 21, 3, '2022-04-01 8:45:00', 1);

	INSERT INTO dbo.[MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
	VALUES (@match2Id, 20, 25, 1, '2022-04-01 9:05:00', 1);
	INSERT INTO dbo.[MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
	VALUES (@match2Id, 19, 25, 2, '2022-04-01 9:18:00', 1);

	INSERT INTO dbo.[MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
	VALUES (@match3Id, 18, 25, 1, '2022-04-01 9:45:00', 1);
	INSERT INTO dbo.[MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
	VALUES (@match3Id, 25, 17, 2, '2022-04-01 10:10:00', 1);
	INSERT INTO dbo.[MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
	VALUES (@match3Id, 25, 16, 3, '2022-04-01 10:28:00', 1);

	-- tournament player stats
	INSERT INTO dbo.[TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
	VALUES  (@tournamentId, @player11Id, 10, 93, 93 + 4, 12, 95 + 4, 40, '2022-04-03 10:28:00', 1);
	INSERT INTO dbo.[TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
	VALUES  (@tournamentId, @player21Id, 10, 83, 83 + 4, 11, 85 + 4, 39, '2022-04-03 10:38:00', 1);
	INSERT INTO dbo.[TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
	VALUES  (@tournamentId, @player12Id, 09, 92, 92 + 4, 10, 94 + 4, 38, '2022-04-03 10:48:00', 1);
	INSERT INTO dbo.[TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
	VALUES  (@tournamentId, @player22Id, 09, 82, 82 + 4, 09, 84 + 4, 37, '2022-04-03 10:58:00', 1);
	INSERT INTO dbo.[TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
	VALUES  (@tournamentId, @player13Id, 08, 71, 71 + 4, 08, 73 + 4, 36, '2022-04-03 11:08:00', 1);
	INSERT INTO dbo.[TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
	VALUES  (@tournamentId, @player23Id, 08, 61, 61 + 4, 07, 63 + 4, 35, '2022-04-03 11:18:00', 1);

	-- playoff round couples
	INSERT INTO dbo.[PlayoffRoundCouple] ([TournamentTeam1Id], [TournamentTeam2Id], [PlayoffRound], [Team1Wins], [Team2Wins], [LastChange], [ChangedBy])
	VALUES (1, 2, 1, 0, 0,  '2022-10-01', 1);

	UPDATE [Match] SET [PlayoffRoundCoupleId] = 1 WHERE [Match].[MatchId] < 4;

	commit;
END TRY
BEGIN CATCH
	Rollback;
	SELECT Error_Message();
END CATCH;
