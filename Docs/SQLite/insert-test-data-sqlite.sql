
BEGIN TRANSACTION;

-- users
INSERT INTO [User]
([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
VALUES
('player1@team1.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player1@team1.com', 'Player1', 'ForTeam1', 'male', '2000-01-01', '2022-03-25', 0, NULL, NULL);
INSERT INTO [User]
([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
VALUES
('player2@team1.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player2@team1.com', 'Player2', 'ForTeam1', 'female', '2000-01-02', '2022-03-26', 0, NULL, NULL);
INSERT INTO [User]
([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
VALUES
('player1@team2.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player1@team2.com', 'Player1', 'ForTeam2', 'male','2000-01-03', '2022-03-27', 0, NULL, NULL);
INSERT INTO [User]
([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
VALUES
('player2@team2.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player2@team2.com', 'Player2', 'ForTeam2', 'female','2000-01-04', '2022-03-28', 0, NULL, NULL);
INSERT INTO [User]
([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
VALUES
('player1@team3.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player1@team3.com', 'Player1', 'ForTeam3', 'male','2000-01-05', '2022-03-29', 0, NULL, NULL);
INSERT INTO [User]
([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
VALUES
('player2@team3.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'player2@team3.com', 'Player2', 'ForTeam3', 'female','2000-01-06', '2022-03-30', 0, NULL, NULL);
INSERT INTO [User]
([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Gender], [DateOfBirth], [RegistrationDate], [ExternalLogin], [RegistrationGuid], [GuidexpirationDate])
VALUES
('free.player@noteam.com', 0, 'VGVzdDEyMzQ=', NULL, NULL, 0, 0, NULL, 1, 0, 'freeplayer@noteam.com', 'FreePlayer', 'NoTeam', 'male','2000-01-07', '2022-03-31', 0, NULL, NULL);

-- user roles
INSERT INTO [UserRole]
([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
VALUES
((SELECT  [UserId] FROM [User] WHERE [Email] = 'player1@team1.com'), 4, 1, 0);
INSERT INTO [UserRole]
([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
VALUES
((SELECT  [UserId] FROM [User] WHERE [Email] = 'player2@team1.com'), 2, 1, 1);
INSERT INTO [UserRole]
([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
VALUES
((SELECT  [UserId] FROM [User] WHERE [Email] = 'player1@team2.com'), 3, 1, 2);
INSERT INTO [UserRole]
([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
VALUES
((SELECT  [UserId] FROM [User] WHERE [Email] = 'player2@team2.com'), 2, 1, 2);
INSERT INTO [UserRole]
([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
VALUES
((SELECT  [UserId] FROM [User] WHERE [Email] = 'player1@team3.com'), 2, 1, 3);
INSERT INTO [UserRole]
([UserId], [RoleId], [IsActive], [TeamIdOrDefault])
VALUES
((SELECT  [UserId] FROM [User] WHERE [Email] = 'player2@team3.com'), 2, 1, 3);

-- teams
INSERT INTO [Team]
([Name], [Logo], [RegistrationDate], [IsActive], [LastChange], [ChangedBy])
VALUES
('Team1', NULL, '2022-03-30', 1, '2022-03-30 09:00:00', 1);
INSERT INTO [Team]
([Name], [Logo], [RegistrationDate], [IsActive], [LastChange], [ChangedBy])
VALUES
('Team2', NULL, '2022-03-30', 1, '2022-03-30 10:00:00', 1);
INSERT INTO [Team]
([Name], [Logo], [RegistrationDate], [IsActive], [LastChange], [ChangedBy])
VALUES
('Team3', NULL, '2022-03-30', 1, '2022-03-30 11:00:00', 1);

INSERT INTO [Team]
([Name], [Logo], [RegistrationDate], [IsActive], [LastChange], [ChangedBy])
VALUES
('NewTeam', NULL, '2022-03-30', 1, '2022-03-30 11:00:00', 1);

-- team players

INSERT INTO [TeamPlayer]
([TeamId], [PlayerId], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player1@team1.com'), '2022-03-30 09:30:00', 1);
INSERT INTO [TeamPlayer]
([TeamId], [PlayerId], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player2@team1.com'), '2022-03-30 09:35:00', 1);
INSERT INTO [TeamPlayer]
([TeamId], [PlayerId], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player1@team2.com'), '2022-03-30 10:30:00', 1);
INSERT INTO [TeamPlayer]
([TeamId], [PlayerId], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player2@team2.com'), '2022-03-30 10:35:00', 1);
INSERT INTO [TeamPlayer]
([TeamId], [PlayerId], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player1@team3.com'), '2022-03-30 11:30:00', 1);
INSERT INTO [TeamPlayer]
([TeamId], [PlayerId], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player2@team3.com'), '2022-03-30 11:35:00', 1);

-- tour series
INSERT INTO [TourSerie] ([Name], [StartDate], [EndDate], [Category], [Note], [LastChange], [ChangedBy])
VALUES
('TourSerie1',  '2022-04-01', '2022-06-30', 'Mix', NULL, '2022-03-31 11:35:00', 1);

-- addresses
INSERT INTO [Address] ([Name], [State], [Town], [Street], [HouseNumber], [LastChange], [ChangedBy])
VALUES ('Gym', 'Czech republic', 'Praha', 'Sportovní', '1/2', '2022-03-31 12:10:00', 1);

-- tournament

INSERT INTO [Tournament] ([TourSerieId], [AddressId], [Name], [StartDate], [EndDate], [EntryFee], [MaxNumOfTeams], [Note], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TourSerieId] FROM [TourSerie] WHERE [Name] = 'TourSerie1'), (SELECT  [AddressId] FROM [Address] WHERE [Name] = 'Gym'), 'Tournament1', '2022-04-01', '2022-04-01', 200, 16, NULL, '2022-03-31 12:11:12', 1);
INSERT INTO [Tournament] ([TourSerieId], [AddressId], [Name], [StartDate], [EndDate], [EntryFee], [MaxNumOfTeams], [Note], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TourSerieId] FROM [TourSerie] WHERE [Name] = 'TourSerie1'), (SELECT  [AddressId] FROM [Address] WHERE [Name] = 'Gym'), 'Tournament2', '2022-04-25', '2022-04-25', 350, 16, NULL, '2022-03-31 12:15:09', 1);

-- tournament teams

INSERT INTO [TournamentTeam] ([TournamentId], [TeamId], [BasicGroupName], [RegistrationDate], [EntryFeePaid], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1'), 'Group A', '2022-03-31 14:18:10', 1, '2022-03-31 14:18:10', 1);
INSERT INTO [TournamentTeam] ([TournamentId], [TeamId], [BasicGroupName], [RegistrationDate], [EntryFeePaid], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2'), 'Group A', '2022-03-31 17:24:59', 1, '2022-03-31 17:24:59', 1);
INSERT INTO [TournamentTeam] ([TournamentId], [TeamId], [BasicGroupName], [RegistrationDate], [EntryFeePaid], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3'), 'Group A', '2022-04-01 07:19:10', 0, '2022-04-01 07:19:10', 1);

-- tournament team stats
INSERT INTO [TournamentTeamStat] ([TournamentTeamId], [TournamentPhase], [PhasePoints], [Wins], [Losts], [Ties], [SetsWon], [SetsLost], [ScorePlus], [ScoreMinus], [LastChange], [ChangedBy])
VALUES ((SELECT tt.[TournamentTeamId] FROM [TournamentTeam] tt INNER JOIN [Team] t ON tt.[TeamId] = t.[TeamId] WHERE t.[Name] = 'Team1'), 0, 8, 2, 1, 0, 17, 1, 17*25, 18*25 - 25, '2022-04-01 18:45:00', 1);
INSERT INTO [TournamentTeamStat] ([TournamentTeamId], [TournamentPhase], [PhasePoints], [Wins], [Losts], [Ties], [SetsWon], [SetsLost], [ScorePlus], [ScoreMinus], [LastChange], [ChangedBy])
VALUES ((SELECT tt.[TournamentTeamId] FROM [TournamentTeam] tt INNER JOIN [Team] t ON tt.[TeamId] = t.[TeamId] WHERE t.[Name] = 'Team2'), 0, 9, 3, 0, 0, 18, 0, 18*25, 18*25 - 50, '2022-04-01 18:45:00', 1);
INSERT INTO [TournamentTeamStat] ([TournamentTeamId], [TournamentPhase], [PhasePoints], [Wins], [Losts], [Ties], [SetsWon], [SetsLost], [ScorePlus], [ScoreMinus], [LastChange], [ChangedBy])
VALUES ((SELECT tt.[TournamentTeamId] FROM [TournamentTeam] tt INNER JOIN [Team] t ON tt.[TeamId] = t.[TeamId] WHERE t.[Name] = 'Team3'), 0, 7, 1, 2, 0, 16, 2, 16*25, 18*25, '2022-04-01 18:45:00', 1);

-- matches
INSERT INTO [Match] ([HomeTeamId], [AwayTeamId], [TournamentId], [TournamentPhase], [WinnerId], [RefereeId], [MatchDate], [LastChange], [ChangedBy])
VALUES ( (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1'), (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2'), (SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), 0, (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1'), NULL, '2022-04-01 08:00:00', '2022-04-01 8:00:00', 1);
INSERT INTO [Match] ([HomeTeamId], [AwayTeamId], [TournamentId], [TournamentPhase], [WinnerId], [RefereeId], [MatchDate], [LastChange], [ChangedBy])
VALUES ( (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2'), (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3'), (SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), 0, (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3'), NULL, '2022-04-01 08:45:00', '2022-04-01 8:45:00', 1);
INSERT INTO [Match] ([HomeTeamId], [AwayTeamId], [TournamentId], [TournamentPhase], [WinnerId], [RefereeId], [MatchDate], [LastChange], [ChangedBy])
VALUES ( (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1'), (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3'), (SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), 0, (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1'), NULL, '2022-04-01 09:30:00', '2022-04-01 9:30:00', 1);

INSERT INTO [Match] ([HomeTeamId], [AwayTeamId], [TournamentId], [TournamentPhase], [WinnerId], [RefereeId], [MatchDate], [LastChange], [ChangedBy])
VALUES (3, 4, NULL, 0, 0, NULL, '2022-05-31 11:18:00', '2022-05-31 11:18:00', NULL);

-- match set scores

INSERT INTO [MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
VALUES ( (SELECT  [MatchId] FROM [Match] WHERE [HomeTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1') AND [AwayTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2')), 23, 25, 1, '2022-04-01 08:15:00', 1);
INSERT INTO [MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
VALUES ( (SELECT  [MatchId] FROM [Match] WHERE [HomeTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1') AND [AwayTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2')), 25, 22, 2, '2022-04-01 08:30:00', 1);
INSERT INTO [MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
VALUES ( (SELECT  [MatchId] FROM [Match] WHERE [HomeTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1') AND [AwayTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2')), 25, 21, 3, '2022-04-01 08:45:00', 1);

INSERT INTO [MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
VALUES ( (SELECT  [MatchId] FROM [Match] WHERE [HomeTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2') AND [AwayTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3')), 20, 25, 1, '2022-04-01 09:05:00', 1);
INSERT INTO [MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
VALUES ( (SELECT  [MatchId] FROM [Match] WHERE [HomeTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team2') AND [AwayTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3')), 19, 25, 2, '2022-04-01 09:18:00', 1);

INSERT INTO [MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
VALUES ( (SELECT  [MatchId] FROM [Match] WHERE [HomeTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1') AND [AwayTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3')), 18, 25, 1, '2022-04-01 09:45:00', 1);
INSERT INTO [MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
VALUES ( (SELECT  [MatchId] FROM [Match] WHERE [HomeTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1') AND [AwayTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3')), 25, 17, 2, '2022-04-01 10:10:00', 1);
INSERT INTO [MatchSetScore] ([MatchId], [HomeTeamScore], [AwayTeamScore], [SetOrder], [LastChange], [ChangedBy])
VALUES ( (SELECT  [MatchId] FROM [Match] WHERE [HomeTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team1') AND [AwayTeamId] = (SELECT  [TeamId] FROM [Team] WHERE [Name] = 'Team3')), 25, 16, 3, '2022-04-01 10:28:00', 1);

-- tournament player stats
INSERT INTO [TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player1@team1.com'), 10, 93, 93 + 4, 12, 95 + 4, 40, '2022-04-03 10:28:00', 1);
INSERT INTO [TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player2@team1.com'), 10, 83, 83 + 4, 11, 85 + 4, 39, '2022-04-03 10:38:00', 1);
INSERT INTO [TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player1@team2.com'), 09, 92, 92 + 4, 10, 94 + 4, 38, '2022-04-03 10:48:00', 1);
INSERT INTO [TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player2@team2.com'), 09, 82, 82 + 4, 09, 84 + 4, 37, '2022-04-03 10:58:00', 1);
INSERT INTO [TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player1@team3.com'), 08, 71, 71 + 4, 08, 73 + 4, 36, '2022-04-03 11:08:00', 1);
INSERT INTO [TournamentPlayerStat] ([TournamentId], [PlayerId], [TourPoints], [AttackPoints], [AttackPercentage], [ServicePoints], [ServicePercentage], [UnforcedErrors], [LastChange], [ChangedBy])
VALUES  ((SELECT  [TournamentId] FROM [Tournament] WHERE [Name] = 'Tournament1'), (SELECT  [UserId] FROM [User] WHERE [Email] = 'player2@team3.com'), 08, 61, 61 + 4, 07, 63 + 4, 35, '2022-04-03 11:18:00', 1);

-- playoff round couples
INSERT INTO [PlayoffRoundCouple] ([TournamentTeam1Id], [TournamentTeam2Id], [PlayoffRound], [Team1Wins], [Team2Wins], [LastChange], [ChangedBy])
VALUES (1, 2, 1, 0, 0,  '2022-10-01', 1);

UPDATE [Match] SET [PlayoffRoundCoupleId] = 1 WHERE [Match].[MatchId] < 4;


COMMIT;
