-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Petr Kloza
-- Create date: 19.02.2023
-- Description:	Stored Procedures Initialization
-- =============================================
CREATE PROCEDURE [dbo].[sp__all_possible_roots__complex_condition]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SELECT
[playoffRoundCouple].[PlayoffRoundCoupleId] '.PlayoffRoundCoupleId'
	, [playoffRoundCouple].[TournamentTeam1Id] '.TournamentTeam1Id'
	, [playoffRoundCouple].[TournamentTeam2Id] '.TournamentTeam2Id'
	, [playoffRoundCouple].[PlayoffRound] '.PlayoffRound'
	, [playoffRoundCouple].[Team1Wins] '.Team1Wins'
	, [playoffRoundCouple].[Team2Wins] '.Team2Wins'
	, [playoffRoundCouple].[LastChange] '.LastChange'
	, [playoffRoundCouple].[ChangedBy] '.ChangedBy'
	, [match].[MatchId] 'Matches[Match].MatchId'
	, [match].[HomeTeamId] 'Matches[Match].HomeTeamId'
	, [match].[AwayTeamId] 'Matches[Match].AwayTeamId'
	, [match].[TournamentId] 'Matches[Match].TournamentId'
	, [match].[TournamentPhase] 'Matches[Match].TournamentPhase'
	, [match].[WinnerId] 'Matches[Match].WinnerId'
	, [match].[RefereeId] 'Matches[Match].RefereeId'
	, [match].[MatchDate] 'Matches[Match].MatchDate'
	, [match].[PlayoffRoundCoupleId] 'Matches[Match].PlayoffRoundCoupleId'
	, [match].[LastChange] 'Matches[Match].LastChange'
	, [match].[ChangedBy] 'Matches[Match].ChangedBy'
	, [matchSetScore].[MatchSetScoreId] 'Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
	, [matchSetScore].[MatchId] 'Matches[Match].MatchSetScores[MatchSetScore].MatchId'
	, [matchSetScore].[HomeTeamScore] 'Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, [matchSetScore].[AwayTeamScore] 'Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, [matchSetScore].[SetOrder] 'Matches[Match].MatchSetScores[MatchSetScore].SetOrder'
	, [matchSetScore].[LastChange] 'Matches[Match].MatchSetScores[MatchSetScore].LastChange'
	, [matchSetScore].[ChangedBy] 'Matches[Match].MatchSetScores[MatchSetScore].ChangedBy'
	, [team].[TeamId] 'Matches[Match].HomeTeam(Team).TeamId'
	, [team].[Name] 'Matches[Match].HomeTeam(Team).Name'
	, [team].[Logo] 'Matches[Match].HomeTeam(Team).Logo'
	, [team].[RegistrationDate] 'Matches[Match].HomeTeam(Team).RegistrationDate'
	, [team].[IsActive] 'Matches[Match].HomeTeam(Team).IsActive'
	, [team].[LastChange] 'Matches[Match].HomeTeam(Team).LastChange'
	, [team].[ChangedBy] 'Matches[Match].HomeTeam(Team).ChangedBy'
	, [teamPlayer].[TeamPlayerId] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].TeamPlayerId'
	, [teamPlayer].[TeamId] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].TeamId'
	, [teamPlayer].[PlayerId] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].PlayerId'
	, [teamPlayer].[LastChange] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].LastChange'
	, [teamPlayer].[ChangedBy] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].ChangedBy'
	, [user].[UserId] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).UserId'
	, [user].[FirstName] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).FirstName'
	, [user].[LastName] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).LastName'
	, [user].[Gender] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).Gender'
	, [user].[DateOfBirth] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, [user].[RegistrationDate] 'Matches[Match].HomeTeam(Team).TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
	, [tournamentTeam].[TournamentTeamId] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamId'
	, [tournamentTeam].[TournamentId] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentId'
	, [tournamentTeam].[TeamId] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TeamId'
	, [tournamentTeam].[BasicGroupName] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].BasicGroupName'
	, [tournamentTeam].[RegistrationDate] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].RegistrationDate'
	, [tournamentTeam].[EntryFeePaid] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].EntryFeePaid'
	, [tournamentTeam].[LastChange] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].LastChange'
	, [tournamentTeam].[ChangedBy] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].ChangedBy'
	, [tournamentTeamStat].[TournamentTeamStatId] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, [tournamentTeamStat].[TournamentTeamId] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, [tournamentTeamStat].[TournamentPhase] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, [tournamentTeamStat].[PhasePoints] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, [tournamentTeamStat].[Wins] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Wins'
	, [tournamentTeamStat].[Losts] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Losts'
	, [tournamentTeamStat].[Ties] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Ties'
	, [tournamentTeamStat].[SetsWon] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsWon'
	, [tournamentTeamStat].[SetsLost] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsLost'
	, [tournamentTeamStat].[ScorePlus] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, [tournamentTeamStat].[ScoreMinus] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, [tournamentTeamStat].[LastChange] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].LastChange'
	, [tournamentTeamStat].[ChangedBy] 'Matches[Match].HomeTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, [x_team].[TeamId] 'Matches[Match].AwayTeam(Team).TeamId'
	, [x_team].[Name] 'Matches[Match].AwayTeam(Team).Name'
	, [x_team].[Logo] 'Matches[Match].AwayTeam(Team).Logo'
	, [x_team].[RegistrationDate] 'Matches[Match].AwayTeam(Team).RegistrationDate'
	, [x_team].[IsActive] 'Matches[Match].AwayTeam(Team).IsActive'
	, [x_team].[LastChange] 'Matches[Match].AwayTeam(Team).LastChange'
	, [x_team].[ChangedBy] 'Matches[Match].AwayTeam(Team).ChangedBy'
	, [x_teamPlayer].[TeamPlayerId] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].TeamPlayerId'
	, [x_teamPlayer].[TeamId] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].TeamId'
	, [x_teamPlayer].[PlayerId] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].PlayerId'
	, [x_teamPlayer].[LastChange] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].LastChange'
	, [x_teamPlayer].[ChangedBy] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].ChangedBy'
	, [x_user].[UserId] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).UserId'
	, [x_user].[FirstName] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).FirstName'
	, [x_user].[LastName] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).LastName'
	, [x_user].[Gender] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).Gender'
	, [x_user].[DateOfBirth] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).DateOfBirth'
	, [x_user].[RegistrationDate] 'Matches[Match].AwayTeam(Team).TeamPlayers[TeamPlayer].Player(User).RegistrationDate'
	, [x_tournamentTeam].[TournamentTeamId] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamId'
	, [x_tournamentTeam].[TournamentId] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentId'
	, [x_tournamentTeam].[TeamId] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TeamId'
	, [x_tournamentTeam].[BasicGroupName] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].BasicGroupName'
	, [x_tournamentTeam].[RegistrationDate] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].RegistrationDate'
	, [x_tournamentTeam].[EntryFeePaid] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].EntryFeePaid'
	, [x_tournamentTeam].[LastChange] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].LastChange'
	, [x_tournamentTeam].[ChangedBy] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].ChangedBy'
	, [x_tournamentTeamStat].[TournamentTeamStatId] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamStatId'
	, [x_tournamentTeamStat].[TournamentTeamId] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentTeamId'
	, [x_tournamentTeamStat].[TournamentPhase] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].TournamentPhase'
	, [x_tournamentTeamStat].[PhasePoints] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].PhasePoints'
	, [x_tournamentTeamStat].[Wins] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Wins'
	, [x_tournamentTeamStat].[Losts] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Losts'
	, [x_tournamentTeamStat].[Ties] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].Ties'
	, [x_tournamentTeamStat].[SetsWon] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsWon'
	, [x_tournamentTeamStat].[SetsLost] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].SetsLost'
	, [x_tournamentTeamStat].[ScorePlus] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScorePlus'
	, [x_tournamentTeamStat].[ScoreMinus] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ScoreMinus'
	, [x_tournamentTeamStat].[LastChange] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].LastChange'
	, [x_tournamentTeamStat].[ChangedBy] 'Matches[Match].AwayTeam(Team).TournamentTeams[TournamentTeam].TournamentTeamStats[TournamentTeamStat].ChangedBy'
	, [tournament].[TournamentId] 'Matches[Match].Tournament.TournamentId'
	, [tournament].[TourSerieId] 'Matches[Match].Tournament.TourSerieId'
	, [tournament].[AddressId] 'Matches[Match].Tournament.AddressId'
	, [tournament].[Name] 'Matches[Match].Tournament.Name'
	, [tournament].[StartDate] 'Matches[Match].Tournament.StartDate'
	, [tournament].[EndDate] 'Matches[Match].Tournament.EndDate'
	, [tournament].[EntryFee] 'Matches[Match].Tournament.EntryFee'
	, [tournament].[MaxNumOfTeams] 'Matches[Match].Tournament.MaxNumOfTeams'
	, [tournament].[Note] 'Matches[Match].Tournament.Note'
	, [tournament].[LastChange] 'Matches[Match].Tournament.LastChange'
	, [tournament].[ChangedBy] 'Matches[Match].Tournament.ChangedBy'
	, [tourSerie].[TourSerieId] 'Matches[Match].Tournament.TourSerie.TourSerieId'
	, [tourSerie].[Name] 'Matches[Match].Tournament.TourSerie.Name'
	, [tourSerie].[StartDate] 'Matches[Match].Tournament.TourSerie.StartDate'
	, [tourSerie].[EndDate] 'Matches[Match].Tournament.TourSerie.EndDate'
	, [tourSerie].[Category] 'Matches[Match].Tournament.TourSerie.Category'
	, [tourSerie].[Note] 'Matches[Match].Tournament.TourSerie.Note'
	, [tourSerie].[LastChange] 'Matches[Match].Tournament.TourSerie.LastChange'
	, [tourSerie].[ChangedBy] 'Matches[Match].Tournament.TourSerie.ChangedBy'
FROM [PlayoffRoundCouple] [playoffRoundCouple]
LEFT JOIN ( SELECT [Match].* FROM [Match] INNER JOIN [PlayoffRoundCouple] ON [Match].[PlayoffRoundCoupleId] = [PlayoffRoundCouple].[PlayoffRoundCoupleId] ) AS [match] ON [playoffRoundCouple].[PlayoffRoundCoupleId] = [match].[PlayoffRoundCoupleId]
LEFT JOIN ( SELECT [MatchSetScore].* FROM [MatchSetScore] INNER JOIN [Match] ON [MatchSetScore].[MatchId] = [Match].[MatchId] ) AS [matchSetScore] ON [match].[MatchId] = [matchSetScore].[MatchId]
LEFT JOIN [Team] [team] ON [match].[HomeTeamId] = [team].[TeamId]
LEFT JOIN ( SELECT [TeamPlayer].* FROM [TeamPlayer] INNER JOIN [Team] ON [TeamPlayer].[TeamId] = [Team].[TeamId] ) AS [teamPlayer] ON [team].[TeamId] = [teamPlayer].[TeamId]
LEFT JOIN [User] [user] ON [teamPlayer].[PlayerId] = [user].[UserId]
LEFT JOIN ( SELECT [TournamentTeam].* FROM [TournamentTeam] INNER JOIN [Team] ON [TournamentTeam].[TeamId] = [Team].[TeamId] ) AS [tournamentTeam] ON [team].[TeamId] = [tournamentTeam].[TeamId]
LEFT JOIN ( SELECT [TournamentTeamStat].* FROM [TournamentTeamStat] INNER JOIN [TournamentTeam] ON [TournamentTeamStat].[TournamentTeamId] = [TournamentTeam].[TournamentTeamId] ) AS [tournamentTeamStat] ON [tournamentTeam].[TournamentTeamId] = [tournamentTeamStat].[TournamentTeamId]
LEFT JOIN [Team] [x_team] ON [match].[AwayTeamId] = [x_team].[TeamId]
LEFT JOIN ( SELECT [TeamPlayer].* FROM [TeamPlayer] INNER JOIN [Team] ON [TeamPlayer].[TeamId] = [Team].[TeamId] ) AS [x_teamPlayer] ON [x_team].[TeamId] = [x_teamPlayer].[TeamId]
LEFT JOIN [User] [x_user] ON [x_teamPlayer].[PlayerId] = [x_user].[UserId]
LEFT JOIN ( SELECT [TournamentTeam].* FROM [TournamentTeam] INNER JOIN [Team] ON [TournamentTeam].[TeamId] = [Team].[TeamId] ) AS [x_tournamentTeam] ON [x_team].[TeamId] = [x_tournamentTeam].[TeamId]
LEFT JOIN ( SELECT [TournamentTeamStat].* FROM [TournamentTeamStat] INNER JOIN [TournamentTeam] ON [TournamentTeamStat].[TournamentTeamId] = [TournamentTeam].[TournamentTeamId] ) AS [x_tournamentTeamStat] ON [x_tournamentTeam].[TournamentTeamId] = [x_tournamentTeamStat].[TournamentTeamId]
LEFT JOIN [Tournament] [tournament] ON [match].[TournamentId] = [tournament].[TournamentId]
LEFT JOIN [TourSerie] [tourSerie] ON [tournament].[TourSerieId] = [tourSerie].[TourSerieId]

WHERE
	( [tournament].[TournamentId] IN  (
		SELECT
		[xxx_tournament].[TournamentId]
		FROM [Tournament] [xxx_tournament]
		LEFT JOIN ( SELECT [TournamentTeam].* FROM [TournamentTeam] INNER JOIN [Tournament] ON [TournamentTeam].[TournamentId] = [Tournament].[TournamentId] ) AS [xxx_tournamentTeam] ON [xxx_tournament].[TournamentId] = [xxx_tournamentTeam].[TournamentId]
		LEFT JOIN [Team] [xxx_team] ON [xxx_tournamentTeam].[TeamId] = [xxx_team].[TeamId]
		
		
		WHERE
			[xxx_tournament].[TournamentId] NOT IN ( 3, 4 ) AND [xxx_team].[RegistrationDate] >= '20210101 00:00:00.000'
		
 ) AND ( ( [team].[Name] = 'Team1' OR [x_team].[Name] = 'Team1' ) OR ( [team].[Name] = 'Team2' OR [x_team].[Name] = 'Team2' ) ) ) OR ( ( [team].[Name] LIKE 'noname%' OR [x_team].[Name] LIKE 'noname%' ) AND [tournament].[Name] LIKE 'noname%' )
ORDER BY [tournament].[TournamentId] DESC, [team].[Name] DESC, [x_team].[Name] DESC, [tournament].[Name], [match].[MatchId], [matchSetScore].[SetOrder];
END
GO
