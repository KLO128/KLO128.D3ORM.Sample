
///
/// generated class
///

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks
{
    public static class SQLiteQueries
    {
        public const string UserIdNoPassQuery = @"SELECT  
	[u0].[UserId] AS '.UserId'
	, [u0].[Email] AS '.Email'
	, [u0].[EmailConfirmed] AS '.EmailConfirmed'
	, [u0].[SecurityStamp] AS '.SecurityStamp'
	, [u0].[PhoneNumber] AS '.PhoneNumber'
	, [u0].[PhoneNumberConfirmed] AS '.PhoneNumberConfirmed'
	, [u0].[TwoFactorEnabled] AS '.TwoFactorEnabled'
	, [u0].[LockoutEndDateUtc] AS '.LockoutEndDateUtc'
	, [u0].[LockoutEnabled] AS '.LockoutEnabled'
	, [u0].[AccessFailedCount] AS '.AccessFailedCount'
	, [u0].[UserName] AS '.UserName'
	, [u0].[FirstName] AS '.FirstName'
	, [u0].[LastName] AS '.LastName'
	, [u0].[Gender] AS '.Gender'
	, [u0].[DateOfBirth] AS '.DateOfBirth'
	, [u0].[RegistrationDate] AS '.RegistrationDate'
	, [u0].[ExternalLogin] AS '.ExternalLogin'
	, [u0].[RegistrationGuid] AS '.RegistrationGuid'
	, [u0].[GuidexpirationDate] AS '.GuidexpirationDate'
	, [u1].[UserRoleId] AS 'UserRoles[UserRole].UserRoleId'
	, [u1].[UserId] AS 'UserRoles[UserRole].UserId'
	, [u1].[RoleId] AS 'UserRoles[UserRole].RoleId'
	, [u1].[IsActive] AS 'UserRoles[UserRole].IsActive'
	, [u1].[TeamIdOrDefault] AS 'UserRoles[UserRole].TeamIdOrDefault'
FROM [User] AS [u0]
LEFT JOIN [UserRole] AS [u1] ON [u0].[UserId] = [u1].[UserId]

WHERE
	[u0].[UserId] = 1
ORDER BY [u0].[UserId], [u1].[TeamIdOrDefault]

";

        public const string InsertMatchQuery = @"INSERT INTO [Match] (

	[HomeTeamId]
	, [AwayTeamId]
	, [TournamentId]
	, [TournamentPhase]
	, [WinnerId]
	, [RefereeId]
	, [MatchDate]
	, [PlayoffRoundCoupleId]
	, [LastChange]
	, [ChangedBy]




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
	[t0].[TournamentPlayerStatId] AS '.TournamentPlayerStatId'
	, [t0].[TournamentId] AS '.TournamentId'
	, [t0].[PlayerId] AS '.PlayerId'
	, [t0].[TourPoints] AS '.TourPoints'
	, [t0].[AttackPoints] AS '.AttackPoints'
	, [t0].[AttackPercentage] AS '.AttackPercentage'
	, [t0].[ServicePoints] AS '.ServicePoints'
	, [t0].[ServicePercentage] AS '.ServicePercentage'
	, [t0].[UnforcedErrors] AS '.UnforcedErrors'
	, [t0].[LastChange] AS '.LastChange'
	, [t0].[ChangedBy] AS '.ChangedBy'
	, [u0].[UserId] AS 'Player(User).UserId'
	, [u0].[FirstName] AS 'Player(User).FirstName'
	, [u0].[LastName] AS 'Player(User).LastName'
	, [u0].[Gender] AS 'Player(User).Gender'
	, [u0].[DateOfBirth] AS 'Player(User).DateOfBirth'
	, [u0].[RegistrationDate] AS 'Player(User).RegistrationDate'
	, [t1].[TournamentId] AS 'Tournament.TournamentId'
	, [t1].[TourSerieId] AS 'Tournament.TourSerieId'
	, [t1].[AddressId] AS 'Tournament.AddressId'
	, [t1].[Name] AS 'Tournament.Name'
	, [t1].[StartDate] AS 'Tournament.StartDate'
	, [t1].[EndDate] AS 'Tournament.EndDate'
	, [t1].[EntryFee] AS 'Tournament.EntryFee'
	, [t1].[MaxNumOfTeams] AS 'Tournament.MaxNumOfTeams'
	, [t1].[Note] AS 'Tournament.Note'
	, [t1].[LastChange] AS 'Tournament.LastChange'
	, [t1].[ChangedBy] AS 'Tournament.ChangedBy'
FROM [TournamentPlayerStat] AS [t0]
INNER JOIN [User] AS [u0] ON [t0].[PlayerId] = [u0].[UserId]
INNER JOIN [Tournament] AS [t1] ON [t0].[TournamentId] = [t1].[TournamentId]

WHERE
	[t0].[TournamentId] = 1 AND [t0].[PlayerId] = 1

";

        public const string TournamentTeamGetBasicGroupStatsQuery = @"SELECT  
	[t1].[TournamentTeamStatId] AS '.TournamentTeamStatRankId'
	, [t1].[SetsWon] - [t1].[SetsLost] AS '.SetsWonLostDiff'
	, [t1].[ScorePlus] - [t1].[ScoreMinus] AS '.ScorePlusMinus'
	, [t1].[TournamentPhase] AS '.TournamentPhase'
	, [t1].[PhasePoints] AS '.PhasePoints'
	, [t1].[LastChange] AS '.LastChange'
	, [t2].[TournamentTeamId] AS 'TournamentTeamStats[TournamentTeamStatRank].TournamentTeamRankId'
	, [t2].[BasicGroupName] AS 'TournamentTeamStats[TournamentTeamStatRank].BasicGroupName'
	, [t2].[LastChange] AS 'TournamentTeamStats[TournamentTeamStatRank].LastChange'
	, [t3].[TeamId] AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).TeamRankId'
	, [t3].[Name] AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).Name'
	, [t3].[Logo] AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).Logo'
	, [t3].[RegistrationDate] AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).RegistrationDate'
	, [t3].[IsActive] AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).IsActive'
	, [t3].[LastChange] AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).LastChange'
	, [t3].[ChangedBy] AS 'TournamentTeamStats[TournamentTeamStatRank].Team(TeamRank).ChangedBy'
FROM [TournamentTeamStat] AS [t1]
INNER JOIN [TournamentTeam] AS [t2] ON [t1].[TournamentTeamId] = [t2].[TournamentTeamId]
INNER JOIN [Team] AS [t3] ON [t2].[TeamId] = [t3].[TeamId]

WHERE
	[t1].[TournamentPhase] = 0 AND [t2].[TournamentId] = 1
ORDER BY [t1].[TournamentPhase], [t1].[PhasePoints] DESC, 2 DESC, 3 DESC

";

        public const string PlayoffCountForEachMatchAvgMaxMinSumScoreHomePlayedSkipAndTakeQuery = @"SELECT DISTINCT 
	[p0].[PlayoffRoundCoupleId] AS '.PlayoffRoundCoupleId'
FROM [PlayoffRoundCouple] AS [p0]
INNER JOIN [TournamentTeam] AS [t0] ON [p0].[TournamentTeam1Id] = [t0].[TournamentTeamId]
INNER JOIN [TournamentTeam] AS [t2] ON [p0].[TournamentTeam2Id] = [t2].[TournamentTeamId]
INNER JOIN [Tournament] AS [t1] ON [t0].[TournamentId] = [t1].[TournamentId]
LEFT JOIN (
	SELECT [x100].[MatchId], [x100].[HomeTeamId], [x100].[AwayTeamId], [x100].[TournamentId], [x100].[TournamentPhase], [x100].[WinnerId], [x100].[RefereeId], [x100].[MatchDate], [x100].[PlayoffRoundCoupleId], [x100].[LastChange], [x100].[ChangedBy], [x100100].[AwayTeamScore], [x100100].[HomeTeamScore], [x100100].[MatchSetScoreId]
	FROM [Match] AS [x100]
	LEFT JOIN [MatchSetScore] AS [x100100] ON [x100].[MatchId] = [x100100].[MatchId]
 ) AS [m0] ON [p0].[PlayoffRoundCoupleId] = [m0].[PlayoffRoundCoupleId]

WHERE
	[p0].[PlayoffRound] = 1 AND [m0].[HomeTeamId] = 1 AND ( [t0].[TeamId] = 1 OR [t2].[TeamId] = 1 )
GROUP BY [p0].[PlayoffRoundCoupleId]
ORDER BY 1

LIMIT {1} OFFSET {0}
;
--
SELECT  
	[p0].[PlayoffRoundCoupleId] AS '.PlayoffRoundCoupleId'
	, [m0].[MatchId] AS 'Matches[Match].MatchId'
	, [m0].[HomeTeamId] AS 'Matches[Match].HomeTeamId'
	, [m0].[AwayTeamId] AS 'Matches[Match].AwayTeamId'
	, [m0].[TournamentId] AS 'Matches[Match].TournamentId'
	, [m0].[TournamentPhase] AS 'Matches[Match].TournamentPhase'
	, [m0].[WinnerId] AS 'Matches[Match].WinnerId'
	, [m0].[RefereeId] AS 'Matches[Match].RefereeId'
	, [m0].[MatchDate] AS 'Matches[Match].MatchDate'
	, [m0].[PlayoffRoundCoupleId] AS 'Matches[Match].PlayoffRoundCoupleId'
	, [m0].[LastChange] AS 'Matches[Match].LastChange'
	, [m0].[ChangedBy] AS 'Matches[Match].ChangedBy'
	, SUM([m0].[AwayTeamScore]) AS 'SUM Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, AVG([m0].[AwayTeamScore]) AS 'AVG Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, MIN([m0].[AwayTeamScore]) AS 'MIN Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, MAX([m0].[AwayTeamScore]) AS 'MAX Matches[Match].MatchSetScores[MatchSetScore].AwayTeamScore'
	, SUM([m0].[HomeTeamScore]) AS 'SUM Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, AVG([m0].[HomeTeamScore]) AS 'AVG Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, MIN([m0].[HomeTeamScore]) AS 'MIN Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, MAX([m0].[HomeTeamScore]) AS 'MAX Matches[Match].MatchSetScores[MatchSetScore].HomeTeamScore'
	, COUNT([m0].[MatchSetScoreId]) AS 'CNT Matches[Match].MatchSetScores[MatchSetScore].MatchSetScoreId'
FROM [PlayoffRoundCouple] AS [p0]
INNER JOIN [TournamentTeam] AS [t0] ON [p0].[TournamentTeam1Id] = [t0].[TournamentTeamId]
INNER JOIN [TournamentTeam] AS [t2] ON [p0].[TournamentTeam2Id] = [t2].[TournamentTeamId]
INNER JOIN [Tournament] AS [t1] ON [t0].[TournamentId] = [t1].[TournamentId]
LEFT JOIN (
	SELECT [x100].[MatchId], [x100].[HomeTeamId], [x100].[AwayTeamId], [x100].[TournamentId], [x100].[TournamentPhase], [x100].[WinnerId], [x100].[RefereeId], [x100].[MatchDate], [x100].[PlayoffRoundCoupleId], [x100].[LastChange], [x100].[ChangedBy], [x100100].[AwayTeamScore], [x100100].[HomeTeamScore], [x100100].[MatchSetScoreId]
	FROM [Match] AS [x100]
	LEFT JOIN [MatchSetScore] AS [x100100] ON [x100].[MatchId] = [x100100].[MatchId]
 ) AS [m0] ON [p0].[PlayoffRoundCoupleId] = [m0].[PlayoffRoundCoupleId]

WHERE
	[p0].[PlayoffRoundCoupleId] IN ( |RANGE| ) AND  ([p0].[PlayoffRound] = 1 AND [m0].[HomeTeamId] = 1 AND ( [t0].[TeamId] = 1 OR [t2].[TeamId] = 1 ) )
GROUP BY [p0].[PlayoffRoundCoupleId], [m0].[MatchId], [m0].[HomeTeamId], [m0].[AwayTeamId], [m0].[TournamentId], [m0].[TournamentPhase], [m0].[WinnerId], [m0].[RefereeId], [m0].[MatchDate], [m0].[PlayoffRoundCoupleId], [m0].[LastChange], [m0].[ChangedBy]
ORDER BY [p0].[PlayoffRoundCoupleId], [t0].[TournamentTeamId], [t2].[TournamentTeamId], [t1].[TournamentId], 21 DESC, [m0].[MatchId], 20, 16

";

        public const string MatchSetScoreDifferenceQuerySkipAndTakeAsDTO = @"SELECT DISTINCT 
	[m1].[MatchSetScoreId] AS '.MatchSetScoreId'
FROM [MatchSetScore] AS [m1]

WHERE
	[m1].[LastChange] >= '2022-03-22 00:00:00.000'
GROUP BY [m1].[MatchSetScoreId], [m1].[MatchId], [m1].[SetOrder], [m1].[LastChange], [m1].[ChangedBy]
ORDER BY 1

LIMIT {1} OFFSET {0}
;
--
SELECT  
	[m1].[MatchSetScoreId] AS '.MatchSetScoreId'
	, SUM(( CASE WHEN [m1].[HomeTeamScore] >= [m1].[AwayTeamScore] THEN [m1].[HomeTeamScore] ELSE [m1].[AwayTeamScore] END ) - ( CASE WHEN [m1].[HomeTeamScore] < [m1].[AwayTeamScore] THEN [m1].[HomeTeamScore] ELSE [m1].[AwayTeamScore] END )) AS 'ScoreDifference .HomeTeamScore'
	, [m1].[MatchId] AS '.MatchId'
	, [m1].[SetOrder] AS '.SetOrder'
	, [m1].[LastChange] AS '.LastChange'
	, [m1].[ChangedBy] AS '.ChangedBy'
	, [m2].[MatchId] AS 'MatchSetScores[MatchSetScoreDTO].MatchId'
	, [m2].[HomeTeamId] AS 'MatchSetScores[MatchSetScoreDTO].HomeTeamId'
	, [m2].[AwayTeamId] AS 'MatchSetScores[MatchSetScoreDTO].AwayTeamId'
	, [m2].[TournamentId] AS 'MatchSetScores[MatchSetScoreDTO].TournamentId'
	, [m2].[TournamentPhase] AS 'MatchSetScores[MatchSetScoreDTO].TournamentPhase'
	, [m2].[WinnerId] AS 'MatchSetScores[MatchSetScoreDTO].WinnerIdTest'
	, [m2].[MatchDate] AS 'MatchSetScores[MatchSetScoreDTO].MatchDate'
	, [m2].[PlayoffRoundCoupleId] AS 'MatchSetScores[MatchSetScoreDTO].PlayoffRoundCoupleId'
	, [m2].[LastChange] AS 'MatchSetScores[MatchSetScoreDTO].LastChange'
	, [m2].[ChangedBy] AS 'MatchSetScores[MatchSetScoreDTO].ChangedBy'
FROM [MatchSetScore] AS [m1]
INNER JOIN [Match] AS [m2] ON [m1].[MatchId] = [m2].[MatchId]

WHERE
	[m1].[MatchSetScoreId] IN ( |RANGE| ) AND  ([m1].[LastChange] >= '2022-03-22 00:00:00.000' )
GROUP BY [m1].[MatchSetScoreId], [m1].[MatchId], [m1].[SetOrder], [m1].[LastChange], [m1].[ChangedBy], [m2].[MatchId], [m2].[HomeTeamId], [m2].[AwayTeamId], [m2].[TournamentId], [m2].[TournamentPhase], [m2].[WinnerId], [m2].[MatchDate], [m2].[PlayoffRoundCoupleId], [m2].[LastChange], [m2].[ChangedBy]
ORDER BY 2 DESC

";

        public const string UnionsMAtchesWonAsHomeUnionAsAwayDataSkipAndTakeQuery = @"SELECT  
	0 as ROWID,
	[p0].[PlayoffRoundCoupleId] AS '.PlayoffRoundCoupleId'
FROM [PlayoffRoundCouple] AS [p0]
LEFT JOIN [Match] AS [m0] ON [p0].[PlayoffRoundCoupleId] = [m0].[PlayoffRoundCoupleId]

WHERE
	[m0].[HomeTeamId] = 1 AND [m0].[WinnerId] = 1
UNION

SELECT  
	1 as ROWID,
	[p0].[PlayoffRoundCoupleId] AS '.PlayoffRoundCoupleId'
FROM [PlayoffRoundCouple] AS [p0]
LEFT JOIN [Match] AS [m0] ON [p0].[PlayoffRoundCoupleId] = [m0].[PlayoffRoundCoupleId]

WHERE
	[m0].[AwayTeamId] = 1 AND [m0].[WinnerId] = 1
UNION

SELECT  
	2 as ROWID,
	[p0].[PlayoffRoundCoupleId] AS '.PlayoffRoundCoupleId'
FROM [PlayoffRoundCouple] AS [p0]
LEFT JOIN [Match] AS [m0] ON [p0].[PlayoffRoundCoupleId] = [m0].[PlayoffRoundCoupleId]

WHERE
	[m0].[HomeTeamId] = 1 OR [m0].[AwayTeamId] = 1
ORDER BY 1

LIMIT {1} OFFSET {0}
;
--
SELECT  
	0 as ROWID,
	[p0].[PlayoffRoundCoupleId] AS '.PlayoffRoundCoupleId'
	, [p0].[TournamentTeam1Id] AS '.TournamentTeam1Id'
	, [p0].[TournamentTeam2Id] AS '.TournamentTeam2Id'
	, [p0].[PlayoffRound] AS '.PlayoffRound'
	, [p0].[Team1Wins] AS '.Team1Wins'
	, [p0].[Team2Wins] AS '.Team2Wins'
	, [p0].[LastChange] AS '.LastChange'
	, [p0].[ChangedBy] AS '.ChangedBy'
	, [m0].[MatchId] AS 'Matches[Match].MatchId'
	, [m0].[HomeTeamId] AS 'Matches[Match].HomeTeamId'
	, [m0].[AwayTeamId] AS 'Matches[Match].AwayTeamId'
	, [m0].[TournamentId] AS 'Matches[Match].TournamentId'
	, [m0].[TournamentPhase] AS 'Matches[Match].TournamentPhase'
	, [m0].[WinnerId] AS 'Matches[Match].WinnerId'
	, [m0].[RefereeId] AS 'Matches[Match].RefereeId'
	, [m0].[MatchDate] AS 'Matches[Match].MatchDate'
	, [m0].[PlayoffRoundCoupleId] AS 'Matches[Match].PlayoffRoundCoupleId'
	, [m0].[LastChange] AS 'Matches[Match].LastChange'
	, [m0].[ChangedBy] AS 'Matches[Match].ChangedBy'
FROM [PlayoffRoundCouple] AS [p0]
LEFT JOIN [Match] AS [m0] ON [p0].[PlayoffRoundCoupleId] = [m0].[PlayoffRoundCoupleId]

WHERE
	[p0].[PlayoffRoundCoupleId] IN ( |RANGE| ) AND  ([m0].[HomeTeamId] = 1 AND [m0].[WinnerId] = 1 )
UNION

SELECT  
	1 as ROWID,
	[p0].[PlayoffRoundCoupleId] AS '.PlayoffRoundCoupleId'
	, [p0].[TournamentTeam1Id] AS '.TournamentTeam1Id'
	, [p0].[TournamentTeam2Id] AS '.TournamentTeam2Id'
	, [p0].[PlayoffRound] AS '.PlayoffRound'
	, [p0].[Team1Wins] AS '.Team1Wins'
	, [p0].[Team2Wins] AS '.Team2Wins'
	, [p0].[LastChange] AS '.LastChange'
	, [p0].[ChangedBy] AS '.ChangedBy'
	, [m0].[MatchId] AS 'Matches[Match].MatchId'
	, [m0].[HomeTeamId] AS 'Matches[Match].HomeTeamId'
	, [m0].[AwayTeamId] AS 'Matches[Match].AwayTeamId'
	, [m0].[TournamentId] AS 'Matches[Match].TournamentId'
	, [m0].[TournamentPhase] AS 'Matches[Match].TournamentPhase'
	, [m0].[WinnerId] AS 'Matches[Match].WinnerId'
	, [m0].[RefereeId] AS 'Matches[Match].RefereeId'
	, [m0].[MatchDate] AS 'Matches[Match].MatchDate'
	, [m0].[PlayoffRoundCoupleId] AS 'Matches[Match].PlayoffRoundCoupleId'
	, [m0].[LastChange] AS 'Matches[Match].LastChange'
	, [m0].[ChangedBy] AS 'Matches[Match].ChangedBy'
FROM [PlayoffRoundCouple] AS [p0]
LEFT JOIN [Match] AS [m0] ON [p0].[PlayoffRoundCoupleId] = [m0].[PlayoffRoundCoupleId]

WHERE
	[p0].[PlayoffRoundCoupleId] IN ( |RANGE| ) AND  ([m0].[AwayTeamId] = 1 AND [m0].[WinnerId] = 1 )
UNION

SELECT  
	2 as ROWID,
	[p0].[PlayoffRoundCoupleId] AS '.PlayoffRoundCoupleId'
	, [p0].[TournamentTeam1Id] AS '.TournamentTeam1Id'
	, [p0].[TournamentTeam2Id] AS '.TournamentTeam2Id'
	, [p0].[PlayoffRound] AS '.PlayoffRound'
	, [p0].[Team1Wins] AS '.Team1Wins'
	, [p0].[Team2Wins] AS '.Team2Wins'
	, [p0].[LastChange] AS '.LastChange'
	, [p0].[ChangedBy] AS '.ChangedBy'
	, [m0].[MatchId] AS 'Matches[Match].MatchId'
	, [m0].[HomeTeamId] AS 'Matches[Match].HomeTeamId'
	, [m0].[AwayTeamId] AS 'Matches[Match].AwayTeamId'
	, [m0].[TournamentId] AS 'Matches[Match].TournamentId'
	, [m0].[TournamentPhase] AS 'Matches[Match].TournamentPhase'
	, [m0].[WinnerId] AS 'Matches[Match].WinnerId'
	, [m0].[RefereeId] AS 'Matches[Match].RefereeId'
	, [m0].[MatchDate] AS 'Matches[Match].MatchDate'
	, [m0].[PlayoffRoundCoupleId] AS 'Matches[Match].PlayoffRoundCoupleId'
	, [m0].[LastChange] AS 'Matches[Match].LastChange'
	, [m0].[ChangedBy] AS 'Matches[Match].ChangedBy'
FROM [PlayoffRoundCouple] AS [p0]
LEFT JOIN [Match] AS [m0] ON [p0].[PlayoffRoundCoupleId] = [m0].[PlayoffRoundCoupleId]

WHERE
	[p0].[PlayoffRoundCoupleId] IN ( |RANGE| ) AND  ([m0].[HomeTeamId] = 1 OR [m0].[AwayTeamId] = 1 )

";

        public const string BulkUpdateQuery = @"UPDATE [Team] SET 	[IsActive] = 0 WHERE [RegistrationDate] <= '2012-08-03 00:00:00.000'";


    }
}
