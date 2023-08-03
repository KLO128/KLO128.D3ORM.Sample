using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Extensions;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests.Mocks
{
    public class TestData
    {
        private static StringBuilder Locker { get; set; } = new StringBuilder();

        public static TestData StaticData { get; private set; } = new TestData();

        public List<Team> TeamAggregates { get; set; } = new List<Team>();

        public List<Tournament> TournamentAggregates { get; set; } = new List<Tournament>();

        public List<TourSerie> TourSerieAggregates { get; set; } = new List<TourSerie>();

        public List<Match> MatchesAgregates { get; set; } = new List<Match>();

        public List<TournamentPlayerStat> PlayerStatAggregates { get; set; } = new List<TournamentPlayerStat>();

        public List<User> UserAggregates { get; set; } = new List<User>();

        public List<PlayoffRoundCouple> PlayoffRoundCouples { get; set; } = new List<PlayoffRoundCouple>();

        public static void InitData(IServiceScope scope)
        {
            if (ServiceConfig.TournamentRepository(scope).FindBy(ServiceConfig.QC(scope).GetTournamentNameFilterQuery("Tournament1")) is not Tournament tournament1)
            {
                switch (ServiceConfig.DbConnection(scope).GetType().Name)
                {
                    case nameof(SqliteConnection):
                        using (var cmd = ServiceConfig.DbConnection(scope).CreateCommand())
                        {
                            ServiceConfig.DbConnection(scope).OpenIfNot();
                            cmd.CommandText = File.ReadAllText(@"../../../../Docs/SQLite/insert-test-data-sqlite.sql");

                            cmd.ExecuteNonQuery();
                        }

                        break;
                    case "SqlConnection":
                        using (var cmd = ServiceConfig.DbConnection(scope).CreateCommand())
                        {
                            ServiceConfig.DbConnection(scope).OpenIfNot();
                            cmd.CommandText = File.ReadAllText(@"../../../../Docs/MSSQL/insert-test-data-mssql.sql");

                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case nameof(MySqlConnection):
                    default:
                        //using (var cmd = TestData.DbConnection.CreateCommand())
                        //{
                        //    var script = File.ReadAllText(@"../../../Integration/insert-test-data-mysql.sql").Substring("DELIMITER $$".Length);
                        //    var start = script.IndexOf("BEGIN");
                        //    var end = script.LastIndexOf("END");

                        //    cmd.CommandText = string.Concat(script.Substring(start, end - start), "\r\nEND;");
                        //    cmd.ExecuteNonQuery();
                        //    InitData_ScriptCompleted(cmd, new EventArgs());
                        //}

                        var script = new MySqlScript(ServiceConfig.DbConnection(scope) as MySqlConnection, File.ReadAllText(@"../../../../Docs/MySQL/insert-test-data-mysql.sql").Substring("DELIMITER $$".Length).Replace("$$", ";;"));
                        //script.ScriptCompleted += InitData_ScriptCompleted;
                        script.Delimiter = ";;";
                        script.ExecuteAsync().Wait();
                        break;
                }
            }

            if (StaticData.TournamentAggregates.Count == 0)
            {
                InitData_ScriptCompleted(scope, Locker, new EventArgs());
            }
        }

        private static void InitData_ScriptCompleted(IServiceScope scope, object? sender, EventArgs e)
        {
            lock (Locker)
            {
                if (ServiceConfig.DataInitializedForConnType == ServiceConfig.DbConnection(scope).GetType())
                {
                    return;
                }

                using (var cmd = ServiceConfig.DbConnection(scope).CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Tournament))} WHERE {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Tournament.Name))} = 'Tournament1'";
                    var tournament1 = ReadFlat<Tournament>(ServiceConfig.D3Context(scope), cmd).FirstOrDefault() ?? new Tournament();

                    cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Tournament))} WHERE {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Tournament.Name))} = 'Tournament2'";
                    var tournament2 = ReadFlat<Tournament>(ServiceConfig.D3Context(scope), cmd).FirstOrDefault() ?? new Tournament();

                    // players
                    cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(User))}";
                    StaticData.UserAggregates = ReadFlat<User>(ServiceConfig.D3Context(scope), cmd);

                    // player stats
                    cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(TournamentPlayerStat))} WHERE {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(TournamentPlayerStat.TournamentId))} = {tournament1.TournamentId}";
                    StaticData.PlayerStatAggregates = ReadFlat<TournamentPlayerStat>(ServiceConfig.D3Context(scope), cmd);

                    foreach (var user in StaticData.UserAggregates)
                    {
                        var range = StaticData.PlayerStatAggregates.FindAll(x => x.PlayerId == user.UserId /*&& x.TournamentId == tournament.TournamentId*/);

                        range.ForEach(x => { x.Player = user; x.Tournament = tournament1; });

                        if (range != null)
                        {
                            user.TournamentPlayerStats = range;
                        }

                        // user roles
                        cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(UserRole))} WHERE {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(UserRole.UserId))} = {user.UserId}";
                        user.UserRoles = ReadFlat<UserRole>(ServiceConfig.D3Context(scope), cmd);
                    }

                    //teams
                    cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Team))}";
                    StaticData.TeamAggregates = ReadFlat<Team>(ServiceConfig.D3Context(scope), cmd);

                    cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(TeamPlayer))}";
                    var teamPlayers = ReadFlat<TeamPlayer>(ServiceConfig.D3Context(scope), cmd);

                    //tournament teams
                    cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(TournamentTeam))} WHERE {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(TournamentTeam.TournamentId))} = {tournament1.TournamentId}";
                    var tournamentTeams = ReadFlat<TournamentTeam>(ServiceConfig.D3Context(scope), cmd);

                    foreach (var team in StaticData.TeamAggregates)
                    {
                        var range = teamPlayers.FindAll(x => x.TeamId == team.TeamId);

                        range.ForEach(x => x.Player = StaticData.UserAggregates.Find(y => x.PlayerId == y.UserId) ?? new User());

                        team.TeamPlayers = range;

                        var range2 = tournamentTeams.FindAll(x => x.TeamId == team.TeamId /*&& x.TournamentId == tournament.TournamentId*/);

                        foreach (var tournamentTeam in range2)
                        {
                            //tournament team stats
                            cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(TournamentTeamStat))} WHERE {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(TournamentTeamStat.TournamentTeamId))} = {tournamentTeam.TournamentTeamId}";
                            tournamentTeam.TournamentTeamStats = ReadFlat<TournamentTeamStat>(ServiceConfig.D3Context(scope), cmd);
                            tournamentTeam.Team = team;
                        }

                        team.TournamentTeams = range2;
                    }

                    //tour series
                    cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(TourSerie))}";
                    StaticData.TourSerieAggregates = ReadFlat<TourSerie>(ServiceConfig.D3Context(scope), cmd);

                    foreach (var serie in StaticData.TourSerieAggregates)
                    {
                        if (serie.TourSerieId == tournament1.TourSerieId)
                        {
                            serie.Tournaments.Add(tournament1);
                            tournament1.TourSerie = serie;
                        }

                        if (serie.TourSerieId == tournament2.TourSerieId)
                        {
                            serie.Tournaments.Add(tournament2);
                            tournament2.TourSerie = serie;
                        }
                    }

                    //matches
                    cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Match))} WHERE {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Match.TournamentId))} = {tournament1.TournamentId} OR {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Match.TournamentId))} = {tournament2.TournamentId} ORDER BY {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Match.TournamentId))}, {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Match.MatchId))}";
                    StaticData.MatchesAgregates = ReadFlat<Match>(ServiceConfig.D3Context(scope), cmd);

                    foreach (var match in StaticData.MatchesAgregates)
                    {
                        match.HomeTeam = StaticData.TeamAggregates.Find(x => x.TeamId == match.HomeTeamId) ?? new Team();
                        match.AwayTeam = StaticData.TeamAggregates.Find(x => x.TeamId == match.AwayTeamId) ?? new Team();
                        match.Tournament = match.TournamentId == tournament1.TournamentId ? tournament1 : tournament2;

                        //match set score
                        cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(MatchSetScore))} WHERE {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(MatchSetScore.MatchId))} = {match.MatchId} ORDER BY {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(MatchSetScore.MatchId))}, {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(MatchSetScore.SetOrder))}";
                        var sets = ReadFlat<MatchSetScore>(ServiceConfig.D3Context(scope), cmd);

                        match.MatchSetScores = sets;
                    }

                    //tournaments
                    StaticData.TournamentAggregates.Clear();
                    StaticData.TournamentAggregates.Add(tournament1);
                    StaticData.TournamentAggregates.Add(tournament2);

                    foreach (var tournament in StaticData.TournamentAggregates)
                    {
                        tournament.TournamentTeams = tournamentTeams.FindAll(x => x.TournamentId == tournament.TournamentId);
                        tournament.Matches = StaticData.MatchesAgregates.FindAll(x => x.TournamentId == tournament.TournamentId);

                        //address
                        cmd.CommandText = $"SELECT * FROM {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Address))} WHERE {ServiceConfig.D3Context(scope).GetDbNameQuoted(nameof(Address.AddressId))} = {tournament.AddressId}";
                        tournament.Address = ReadFlat<Address>(ServiceConfig.D3Context(scope), cmd).FirstOrDefault() ?? new Address();
                    }

                    ServiceConfig.DataInitializedForConnType = ServiceConfig.DbConnection(scope).GetType();
                }

                // play-off
                // PlayoffGroupInit(scope);
            }
        }

        [Obsolete("Done by script")]
        private static bool PlayoffGroupInit(IServiceScope scope)
        {
            var playoff = new PlayoffRoundCouple
            {
                ChangedBy = 1,
                LastChange = DateTime.UtcNow,
                Team1Wins = 0,
                Team2Wins = 0,
                PlayoffRound = 1,
                TournamentTeam1Id = 1,
                TournamentTeam2Id = 2
            };

            if (ServiceConfig.PlayoffRoundCoupleRepository(scope).FindBy(ServiceConfig.QC(scope).GetPlayoffRoundCoupleFilterQuery(1, 1)) is not PlayoffRoundCouple)
            {
                ServiceConfig.PlayoffRoundCoupleRepository(scope).AddRoot(playoff);

                for (int i = 1; i <= 3; i++)
                {
                    var match = ServiceConfig.MatchRepository(scope).FindByIdSingle(i);

                    if (match == null)
                    {
                        Assert.Fail($"match with id {i} not found");
                        return false;
                    }

                    //var playoffTmp = new PlayoffRoundCouple
                    //{
                    //    ChangedBy = 1,
                    //    LastChange = DateTime.UtcNow,
                    //    Team1Wins = 0,
                    //    Team2Wins = 0,
                    //    PlayoffRound = 1,
                    //    TournamentTeam1Id = match.HomeTeamId, // the same as tournamentTeamId in our case
                    //    TournamentTeam2Id = match.AwayTeamId // the same as tournamentTeamId in our case
                    //};

                    //ServiceConfig.PlayoffRoundCoupleRepository(scope).AddRoot(playoffTmp);

                    ServiceConfig.MatchRepository(scope).UpdateProperties(match, x => x.PlayoffRoundCoupleId, playoff.PlayoffRoundCoupleId);
                }
            }

            return true;
        }

        private static List<TEntity> ReadFlat<TEntity>(ID3Context d3Context, IDbCommand? cmd) where TEntity : class, new()
        {
            if (cmd == null)
            {
                return new List<TEntity>();
            }

            using (var reader = cmd.ExecuteReader())
            {
                var ret = new List<TEntity>();
                while (reader.Read())
                {
                    var toAdd = new TEntity();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (typeof(TEntity).GetProperty(reader.GetName(i).Replace("_", string.Empty), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) is PropertyInfo prop && reader.GetValue(i) is object obj && obj != Convert.DBNull)
                        {
                            prop.SetValue(toAdd, d3Context.ConvertsDbValue(obj, prop.PropertyType));
                        }
                    }

                    ret.Add(toAdd);
                }

                return ret;
            }
        }

        public class Application
        {
            public static Dictionary<Tuple<int, int, int>, List<TournamentTeam>> TournamentGroupTeams { get; set; } = new Dictionary<Tuple<int, int, int>, List<TournamentTeam>>();
        }
    }
}
