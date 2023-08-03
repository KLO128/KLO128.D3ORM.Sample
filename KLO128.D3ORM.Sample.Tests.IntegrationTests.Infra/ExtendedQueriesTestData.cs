using KLO128.D3ORM.Sample.Tests.UnitTests.Infra.Mocks.DTOs;
using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Infra
{
    public static class ExtendedQueriesTestData
    {
        public static Dictionary<string, object> ExpectedOrderedData { get; set; } = new Dictionary<string, object>
        {
            { // Count, Avg, Min, Max, Sum leads to Expando objects; sorting does not work from a child collection as expected
                QueryConstants.PlayoffCountForEachMatchAvgMaxMinSumScoreHomePlayedSkipAndTakeQuery,
                new List<object>
                {
                    new
                    {
                        PlayoffRoundCoupleId = 1,
                        Matches = new List<object>
                        {
                            new
                            {
                                MatchId = 1,
                                HomeTeamId = 1,
                                AwayTeamId = 2,
                                TournamentId = 1,
                                TournamentPhase = 0,
                                WinnerId = 1,
                                RefereeId = default(int?),
                                MatchDate = new DateTime(2022, 4, 1, 8, 0, 0),
                                PlayoffRoundCoupleId = 1,
                                LastChange = new DateTime(2022, 4, 1, 8, 0, 0),
                                ChangedBy = 1,
                                CNT_MatchSetScoreId = 3,
                                SUM_HomeTeamScore = 73,
                                AVG_HomeTeamScore = 24.3333f,
                                MIN_HomeTeamScore = 23,
                                MAX_HomeTeamScore = 25,
                                SUM_AwayTeamScore = 68,
                                AVG_AwayTeamScore = 22.6667f,
                                MIN_AwayTeamScore = 21,
                                MAX_AwayTeamScore = 25
                            },
                            new
                            {
                                MatchId = 3,
                                HomeTeamId = 1,
                                AwayTeamId = 3,
                                TournamentId = 1,
                                TournamentPhase = 0,
                                WinnerId = 1,
                                RefereeId = default(int?),
                                MatchDate = new DateTime(2022, 4, 1, 9, 30, 0),
                                PlayoffRoundCoupleId = 1,
                                LastChange = new DateTime(2022, 4, 1, 9, 30, 0),
                                ChangedBy = 1,
                                CNT_MatchSetScoreId = 3,
                                SUM_HomeTeamScore = 68,
                                AVG_HomeTeamScore = 22.6667f,
                                MIN_HomeTeamScore = 18,
                                MAX_HomeTeamScore = 25,
                                SUM_AwayTeamScore = 58,
                                AVG_AwayTeamScore = 19.3333f,
                                MIN_AwayTeamScore = 16,
                                MAX_AwayTeamScore = 25
                            },
                        },
                    },
                }
            },
            { // Expando objects are also convertible to DTO
                QueryConstants.PlayoffCountForEachMatchAvgMaxMinSumScoreHomePlayedSkipAndTakeQueryAsDTO,
                new List<PlayoffComputeStatsDTO>
                {
                    new PlayoffComputeStatsDTO
                    {
                        PlayoffRoundCoupleId = 1,
                        Matches = new List<PlayoffMatchComputeStatsDTO>
                        {
                            new PlayoffMatchComputeStatsDTO
                            {
                                MatchId = 1,
                                HomeTeamId = 1,
                                AwayTeamId = 2,
                                TournamentId = 1,
                                TournamentPhase = 0,
                                WinnerId = 1,
                                RefereeId = default(int?),
                                MatchDate = new DateTime(2022, 4, 1, 8, 0, 0),
                                PlayoffRoundCoupleId = 1,
                                LastChange = new DateTime(2022, 4, 1, 8, 0, 0),
                                ChangedBy = 1,
                                CNT_MatchSetScoreId = 3,
                                SUM_HomeTeamScore = 73,
                                AVG_HomeTeamScore = 24.3333f,
                                MIN_HomeTeamScore = 23,
                                MAX_HomeTeamScore = 25,
                                SUM_AwayTeamScore = 68,
                                AVG_AwayTeamScore = 22.6667f,
                                MIN_AwayTeamScore = 21,
                                MAX_AwayTeamScore = 25
                            },
                            new PlayoffMatchComputeStatsDTO
                            {
                                MatchId = 3,
                                HomeTeamId = 1,
                                AwayTeamId = 3,
                                TournamentId = 1,
                                TournamentPhase = 0,
                                WinnerId = 1,
                                RefereeId = default(int?),
                                MatchDate = new DateTime(2022, 4, 1, 9, 30, 0),
                                PlayoffRoundCoupleId = 1,
                                LastChange = new DateTime(2022, 4, 1, 9, 30, 0),
                                ChangedBy = 1,
                                CNT_MatchSetScoreId = 3,
                                SUM_HomeTeamScore = 68,
                                AVG_HomeTeamScore = 22.6667f,
                                MIN_HomeTeamScore = 18,
                                MAX_HomeTeamScore = 25,
                                SUM_AwayTeamScore = 58,
                                AVG_AwayTeamScore = 19.3333f,
                                MIN_AwayTeamScore = 16,
                                MAX_AwayTeamScore = 25
                            },
                        },
                    },
                }
            }
        };
    }
}
