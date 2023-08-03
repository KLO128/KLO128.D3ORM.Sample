using KLO128.D3ORM.Common.Extensions;
using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Application.Web.Extensions;
using KLO128.D3ORM.Sample.Domain.Models;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using BaseExtensions = KLO128.D3ORM.Sample.Tests.Extensions;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Application
{
    public abstract class TournamentWebServiceTestBase
    {
        public TournamentWebServiceTestBase(DatabaseType databaseType)
        {
            ServiceConfig.InjectAll(databaseType);
        }

        [TestMethod]
        [DataRow(128, 9, 3, 4, 8)]
        [DataRow(128, 9, 2, 2, 8)]
        [DataRow(128, 9, 1, 4, 8)]
        [DataRow(128, 8, 3, 4, 2)]
        [DataRow(128, 11, 3, 4, null)]
        [DataRow(128, 9, 1, 2, 2)]
        [DataRow(512, 9, 1, 3, null)]
        [DataRow(512, 23, 4, 6, 8)]
        [DataRow(512, 23, 4, 6, 4)]
        [DataRow(512, 23, 4, 7, 4)]
        [DataRow(512, 37, 4, 8, 16)]
        [DataRow(512, 17, 3, 5, null)]
        [DataRow(512, 16, 3, 5, 8)]
        [DataRow(512, 8, 2, 4, 8)]
        [DataRow(512, 8, 2, 4, null)]
        public void TournamentWebService_Draw_WhenSignedUp_ThenStartPlayoff(int seed, int numOfTeams, int minGroupTeamsCount, int maxGroupTeamsCount, int? playoffPass)
        {
            var rand = new Random(seed);
            var tournamentId = 2;

            using (var scope = ServiceConfig.CreateScope())
            {
                ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () =>
                {
                    var teams = new List<Team>();
                    var tournamentTeams = new List<TournamentTeamDTO>();

                    for (int i = 1; i <= 3; i++)
                    {
                        teams.Add(new Team
                        {
                            TeamId = i,
                            Name = string.Concat("Team", i),
                            IsActive = true,
                            RegistrationDate = DateTime.UtcNow
                        });
                    }

                    for (int i = 4; i <= numOfTeams; i++)
                    {
                        teams.Add(ServiceConfig.TeamDomainService(scope).CreateTeam(string.Concat("Team", i), 1));
                    }

                    Assert.AreEqual(numOfTeams, teams.Count);

                    //
                    // sign-up
                    //
                    foreach (var team in teams)
                    {
                        tournamentTeams.Add(ServiceConfig.TournamentWebService(scope).SignUpTeamUnsafe(new SignUpTeamArgs
                        {
                            TeamId = team.TeamId,
                            TournamentId = tournamentId
                        }, 1, false));
                    }

                    Assert.AreEqual(numOfTeams, tournamentTeams.Count);

                    //
                    // draw groups
                    //
                    var drawGroupResult = ServiceConfig.TournamentWebService(scope).DrawGroupsUnsafe(
                        rand,
                        new DrawGroupsArgs
                        {
                            MinNumberOfTeamsPerGroup = minGroupTeamsCount,
                            MaxNumberOfTeamsPerGroup = maxGroupTeamsCount,
                            TournamentId = tournamentId
                        }, 1, false);
                    var key = new Tuple<int, int>(numOfTeams, minGroupTeamsCount);

                    Assert.AreEqual(0, drawGroupResult.Count(x => x.Teams.Count < minGroupTeamsCount));
                    Assert.AreEqual(0, drawGroupResult.Count(x => x.Teams.Count >= maxGroupTeamsCount + 3));
                    Assert.IsTrue(numOfTeams / minGroupTeamsCount >= drawGroupResult.Count);
                    Assert.IsTrue(numOfTeams / maxGroupTeamsCount <= drawGroupResult.Count);

                    var groupTeamsCounts = new List<int>();
                    var teamIdUsed = new HashSet<int>();

                    foreach (var item in drawGroupResult)
                    {
                        Assert.AreEqual(tournamentId, item.TournamentId);

                        groupTeamsCounts.Add(item.Teams.Count);

                        foreach (var team in item.Teams)
                        {
                            if (teamIdUsed.Contains(team.TeamId))
                            {
                                Assert.Fail($"The team {team.TeamId} has been drawn to 2 groups.");
                            }

                            teamIdUsed.Add(team.TeamId);
                        }
                    }

                    Assert.AreEqual(0, groupTeamsCounts.Count(x => x < minGroupTeamsCount || x >= maxGroupTeamsCount + 3));

                    //
                    // draw matches
                    //
                    var matches = ServiceConfig.TournamentWebService(scope).DrawMatchesUnsafe(
                       rand,
                       new DrawMatchesArgs
                       {
                           TournamentId = tournamentId
                       }, 1, false);

                    Assert.AreEqual(0, matches.Count(x => drawGroupResult.FirstOrDefault(y => y.Teams.Any(z => z.TeamId == x.HomeTeamId))?.GroupName != drawGroupResult.FirstOrDefault(y => y.Teams.Any(z => z.TeamId == x.AwayTeamId))?.GroupName));

                    var expectedMatchesCount = 0;

                    foreach (var count in groupTeamsCounts)
                    {
                        expectedMatchesCount += BaseExtensions.Factorial(count) / (BaseExtensions.Factorial(count - 2) * 2);
                    }

                    Assert.AreEqual(expectedMatchesCount, matches.Count);

                    //
                    // solve matches
                    //
                    foreach (var match in matches)
                    {
                        ServiceConfig.MatchWebService(scope).AddMatchSetScore(new AddMatchSetScoreArgs
                        {
                            MatchId = match.MatchId,
                            SetOrder = 1
                        }, 1, false);

                        ServiceConfig.MatchWebService(scope).UpdateMatchSetScoreUnsafe(new UpdateMatchSetScoreArgs
                        {
                            AwayTeamScore = rand.Next(0, 26),
                            HomeTeamScore = rand.Next(0, 26),
                            MatchId = match.MatchId,
                            SetOrder = 1
                        }, 1, false);

                        ServiceConfig.MatchWebService(scope).EndMatchUnsafe(new EndMatchArgs
                        {
                            MatchId = match.MatchId
                        }, 1, false);
                    }

                    //
                    // play-off
                    //
                    var teamRanking = GetTeamRanking(scope, tournamentId);
                    var playoffResult = ServiceConfig.TournamentWebService(scope).CreatePlayoffFirstRoundCouplesUnsafe(new CreatePlayoffRoundArgs
                    {
                        TournamentId = tournamentId,
                        PlayoffPass = playoffPass
                    }, 1, false);

                    if (playoffPass == null)
                    {
                        playoffPass = (int)Math.Pow(2, (int)Math.Floor(Math.Log2(numOfTeams)));
                    }

                    var pairModulo = drawGroupResult.Count.IsPowerOfTwo();
                    var qc = ServiceConfig.QC(scope);

                    Assert.IsNotNull(teamRanking);

                    foreach (var couple in playoffResult)
                    {
                        var team1Rank = teamRanking.Where(x => teamRanking.Count == 1 || x.Key == couple.TournamentTeam1.BasicGroupName).SelectMany(x => x.Value).ToList().FindIndex(x => x.TournamentTeamRankId == couple.TournamentTeam1Id) + 1;
                        var team2Rank = teamRanking.Where(x => teamRanking.Count == 1 || x.Key == couple.TournamentTeam2.BasicGroupName).SelectMany(x => x.Value).ToList().FindIndex(x => x.TournamentTeamRankId == couple.TournamentTeam2Id) + 1;

                        Assert.IsNotNull(team1Rank);
                        Assert.IsNotNull(team2Rank);

                        Assert.AreEqual(Math.Abs(1 - team1Rank), Math.Abs(((playoffPass / teamRanking.Count) ?? 0) - team2Rank));
                    }

                    //
                    // get play-off
                    //
                    var playoffGetResult = ServiceConfig.TournamentWebService(scope).GetPlayoffCouples(tournamentId, 1);

                    Assert.IsTrue(playoffGetResult.Succeeded);
                    Assert.IsNotNull(playoffGetResult.Result);

                    foreach (var getCouple in playoffGetResult.Result)
                    {
                        Assert.IsNotNull(playoffResult.FirstOrDefault(x => x.TournamentTeam1Id == getCouple.TournamentTeam1Id && x.TournamentTeam2Id == getCouple.TournamentTeam2Id && x.PlayoffRound == getCouple.PlayoffRound));
                    }

                    return new ServiceResult<object>();
                });
            }
        }

        private Dictionary<string, List<TournamentTeamRank>> GetTeamRanking(IServiceScope scope, int tournamentId)
        {
            var list = new List<TournamentTeamRank>();
            var connection = ServiceConfig.DbConnection(scope);

            var query = connection.Database.Contains("d3orm_sample_test") ? $@"SELECT  
	`t2`.`tournament_team_id` AS 'TournamentTeamId'
	, `t1`.`sets_won` - `t1`.`sets_lost` AS 'SetsWonLostDiff'
	, `t1`.`score_plus` - `t1`.`score_minus` AS 'ScorePlusMinus'
	, `t1`.`tournament_phase` AS 'TournamentPhase'
	, `t1`.`phase_points` AS '.PhasePoints'
	, `t2`.`basic_group_name` AS 'BasicGroupName'
	, `t3`.`team_id` AS 'TeamId'
	, `t3`.`name` AS 'TeamName'
FROM `tournament_team_stat` AS `t1`
INNER JOIN `tournament_team` AS `t2` ON `t1`.`tournament_team_id` = `t2`.`tournament_team_id`
INNER JOIN `team` AS `t3` ON `t2`.`team_id` = `t3`.`team_id`

WHERE
	`t1`.`tournament_phase` = 0 AND `t2`.`tournament_id` = {tournamentId}
ORDER BY `t1`.`tournament_phase`, `t1`.`phase_points` DESC, 2 DESC, 3 DESC"
                : $@"SELECT  
	[t2].[TournamentTeamId] AS 'TournamentTeamRankId'
	, [t1].[SetsWon] - [t1].[SetsLost] AS 'SetsWonLostDiff'
	, [t1].[ScorePlus] - [t1].[ScoreMinus] AS 'ScorePlusMinus'
	, [t1].[TournamentPhase] AS 'TournamentPhase'
	, [t1].[PhasePoints] AS 'PhasePoints'
	, [t2].[BasicGroupName] AS 'BasicGroupName'
	, [t3].[TeamId] AS 'TeamId'
	, [t3].[Name] AS 'TeamName'
FROM [TournamentTeamStat] AS [t1]
INNER JOIN [TournamentTeam] AS [t2] ON [t1].[TournamentTeamId] = [t2].[TournamentTeamId]
INNER JOIN [Team] AS [t3] ON [t2].[TeamId] = [t3].[TeamId]

WHERE
	[T1].[TournamentPhase] = 0 AND [t2].[TournamentId] = {tournamentId}
ORDER BY [t1].[TournamentPhase], [t1].[PhasePoints] DESC, 2 DESC, 3 DESC";

            using (var cmd = connection.CreateCommand())
            {
                connection.OpenIfNot();
                cmd.CommandText = query;
                connection.AttachTransaction(cmd);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tts = new TournamentTeamStatRank();
                        var t = new TeamRank();
                        var tt = new TournamentTeamRank
                        {
                            Team = t,
                            TournamentTeamStats = new List<TournamentTeamStatRank>
                        {
                            tts
                        }
                        };

                        tt.TournamentTeamRankId = reader.GetInt32(0);
                        tts.SetsWonLostDiff = reader.GetInt32(1);
                        tts.ScorePlusMinus = reader.GetInt32(2);
                        tts.TournamentPhase = reader.GetInt32(3);
                        tts.PhasePoints = reader.GetInt32(4);
                        tt.BasicGroupName = reader.GetString(5);
                        t.TeamRankId = reader.GetInt32(6);
                        t.Name = reader.GetString(7);

                        list.Add(tt);
                    }
                }
            }

            var pairModulo = list.Select(t => t.BasicGroupName).Distinct().ToList().Count % 2 == 0;

            var ret = new Dictionary<string, List<TournamentTeamRank>>();

            if (pairModulo)
            {
                foreach (var t in list)
                {
                    var groupName = t.BasicGroupName ?? string.Empty;

                    if (ret.ContainsKey(groupName))
                    {
                        ret[groupName].Add(t);
                    }
                    else
                    {
                        ret.Add(groupName, new List<TournamentTeamRank> { t });
                    }
                }
            }
            else
            {
                var groupName = list.FirstOrDefault()?.BasicGroupName ?? string.Empty;
                ret.Add(groupName, new List<TournamentTeamRank>());

                foreach (var t in list)
                {
                    t.BasicGroupName = groupName;

                    ret[groupName].Add(t);
                }
            }

            return ret;
        }

        [TestMethod]
        [DataRow("TestTournament", 200, 12)]
        public void TournamentWebService_CreateTournament(string tournamentName, int entryFee, int maxNumberOfTeams)
        {
            using (var scope = ServiceConfig.CreateScope())
            {
                var result = ServiceConfig.D3Context(scope).RollbackAction(ServiceConfig.DbConnection(scope), () => ServiceConfig.TournamentWebService(scope).CreateTournament(new CreateTournamentArgs
                {
                    EndDate = DateTime.Today.AddDays(5),
                    StartDate = DateTime.Today.AddDays(5),
                    EntryFee = entryFee,
                    MaxNumOfTeams = maxNumberOfTeams,
                    Name = tournamentName
                }, 1, false));

                Assert.IsTrue(result.Succeeded);
                Assert.IsNotNull(result.Result);
                Assert.AreNotEqual(0, result.Result.TournamentId);
                Assert.AreEqual(tournamentName, result.Result.Name);
                Assert.AreEqual(maxNumberOfTeams, result.Result.MaxNumOfTeams);
            }
        }
    }
}
