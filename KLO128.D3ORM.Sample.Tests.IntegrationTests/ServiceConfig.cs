using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Application.Web;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.Sample.Domain.Repositories;
using KLO128.D3ORM.Sample.Domain.Services;
using KLO128.D3ORM.Sample.Domain.Services.Impl;
using KLO128.D3ORM.Sample.Infra.D3ORM;
using KLO128.D3ORM.Sample.Infra.D3ORM.Repositories;
using KLO128.D3ORM.Sample.Tests.IntegrationTests.Properties;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BaseExtensions = KLO128.D3ORM.Sample.Tests.Extensions;

namespace KLO128.D3ORM.Sample.Tests.IntegrationTests
{
    public static class ServiceConfig
    {
        public static Type? DataInitializedForConnType { get; set; }

        private static bool Injected { get; set; }

        private static StringBuilder Locker { get; set; } = new StringBuilder();

        private static ServiceProvider ServiceProvider { get; set; } = null!;

        public static IQueryContainer QC(IServiceScope scope)
        {
            return scope.GetService<IQueryContainer>() ?? throw new Exception("Invalid injection...");
        }

        public static IDbConnection DbConnection(IServiceScope scope)
        {
            return scope.GetService<IDbConnection>() ?? throw new Exception("Invalid injection...");
        }
        public static ID3Context D3Context(IServiceScope scope)
        {
            return scope.GetService<ID3Context>() ?? throw new Exception("Invalid injection...");
        }

        public static ITeamDomainService TeamDomainService(IServiceScope scope)
        {
            return scope.GetService<ITeamDomainService>() ?? throw new Exception("Invalid injection...");
        }

        public static ITournamentDomainService TournamentDomainService(IServiceScope scope)
        {
            return scope.GetService<ITournamentDomainService>() ?? throw new Exception("Invalid injection...");
        }

        public static IMatchDomainService MatchDomainService(IServiceScope scope)
        {
            return scope.GetService<IMatchDomainService>() ?? throw new Exception("Invalid injection...");
        }

        public static ITournamentPlayerStatDomainService TournamentPlayerStatDomainService(IServiceScope scope)
        {
            return scope.GetService<ITournamentPlayerStatDomainService>() ?? throw new Exception("Invalid injection...");
        }

        public static IUserDomainService UserDomainService(IServiceScope scope)
        {
            return scope.GetService<IUserDomainService>() ?? throw new Exception("Invalid injection...");
        }

        public static IUnitOfWork UnitOfWork(IServiceScope scope)
        {
            return scope.GetService<IUnitOfWork>() ?? throw new Exception("Invalid injection...");
        }

        public static ITournamentRepository TournamentRepository(IServiceScope scope)
        {
            return scope.GetService<ITournamentRepository>() ?? throw new Exception("Invalid injection...");
        }

        public static ITeamRepository TeamRepository(IServiceScope scope)
        {
            return scope.GetService<ITeamRepository>() ?? throw new Exception("Invalid injection...");
        }

        public static ITeamPlayerRepository TeamPlayerRepository(IServiceScope scope)
        {
            return scope.GetService<ITeamPlayerRepository>() ?? throw new Exception("Invalid injection...");
        }

        public static IMatchRepository MatchRepository(IServiceScope scope)
        {
            return scope.GetService<IMatchRepository>() ?? throw new Exception("Invalid injection...");
        }

        public static IMatchSetScoreRepository MatchSetScoreRepository(IServiceScope scope)
        {
            return scope.GetService<IMatchSetScoreRepository>() ?? throw new Exception("Invalid injection...");
        }

        public static IPlayoffRoundCoupleRepository PlayoffRoundCoupleRepository(IServiceScope scope)
        {
            return scope.GetService<IPlayoffRoundCoupleRepository>() ?? throw new Exception("Invalid injection...");
        }

        public static AccountWebService AccountWebService(IServiceScope scope)
        {
            return scope.GetService<AccountWebService>() ?? throw new Exception("Invalid injection...");
        }

        public static MatchWebService MatchWebService(IServiceScope scope)
        {
            return scope.GetService<MatchWebService>() ?? throw new Exception("Invalid injection...");
        }

        public static PlayerWebService PlayerWebService(IServiceScope scope)
        {
            return scope.GetService<PlayerWebService>() ?? throw new Exception("Invalid injection...");
        }

        public static TeamWebService TeamWebService(IServiceScope scope)
        {
            return scope.GetService<TeamWebService>() ?? throw new Exception("Invalid injection...");
        }

        public static TournamentWebService TournamentWebService(IServiceScope scope)
        {
            return scope.GetService<TournamentWebService>() ?? throw new Exception("Invalid injection...");
        }

        public static void InjectAll(DatabaseType dbType)
        {
            lock (Locker)
            {
                if (Injected && DataInitializedForConnType == (dbType == DatabaseType.MySQL ? typeof(MySqlConnection) : dbType == DatabaseType.MSSQL ? typeof(SqlConnection) : typeof(SqliteConnection)))
                {
                    return;
                }

                Injected = true;

                var services = new ServiceCollection();
                //var settings = JsonConvert.DeserializeObject(File.ReadAllText("appSettings.json")) as JObject;
                //var connString = (settings?.Property("ConnectionStrings")?.Value as JObject)?.Property(dbType.ToString())?.Value.ToString();
                var connString = Resources.ResourceManager.GetString(string.Concat(dbType.ToString(), "ConnectionString"));

                if (connString == null)
                {
                    throw new Exception("Could not find Connection String");
                }

                switch (dbType)
                {

                    case DatabaseType.MSSQL:
                        services.AddScoped<IDbConnection, SqlConnection>(x => new SqlConnection(connString));
                        services.AddScoped<ID3ContextFactory, Infra.D3ORM.MSSQL.MSSQLD3ContextFactory>();
                        break;
                    case DatabaseType.SQLite:
                        services.AddScoped<IDbConnection, SqliteConnection>(x => new SqliteConnection(connString));
                        services.AddScoped<ID3ContextFactory, Infra.D3ORM.SQLite.SQLiteD3ContextFactory>();
                        break;
                    case DatabaseType.MySQL:
                        services.AddScoped<IDbConnection, MySqlConnection>(x => new MySqlConnection(connString));
                        services.AddScoped<ID3ContextFactory, Infra.D3ORM.MySQL.MySQLD3ContextFactory>();
                        break;
                    default:
                        throw BaseExtensions.UnexpectedDatabaseType(dbType.ToString());
                }

                services.AddScoped(x => x.GetService<ID3ContextFactory>()!.Create());

                services.AddScoped<IQueryContainer, QueryContainer>();
                services.AddScoped<IUnitOfWork, UnitOfWork>();

                services.AddScoped<ITournamentRepository, D3TournamentRepository>();
                services.AddScoped<ITournamentTeamRepository, D3TournamentTeamRepository>();
                services.AddScoped<ITeamRepository, D3TeamRepository>();
                services.AddScoped<IMatchRepository, D3MatchRepository>();
                services.AddScoped<IMatchSetScoreRepository, D3MatchSetScoreRepository>();
                services.AddScoped<ITourSerieRepository, D3TourSerieRepository>();
                services.AddScoped<ITeamPlayerRepository, D3TeamPlayerRepository>();
                services.AddScoped<IUserRepository, D3UserRepository>();
                services.AddScoped<IUserRoleRepository, D3UserRoleRepository>();
                services.AddScoped<ITournamentPlayerStatRepository, D3TournamentPlayerStatRepository>();
                services.AddScoped<ITournamentTeamStatRepository, D3TournamentTeamStatRepository>();
                services.AddScoped<IAddressRepository, D3AddressRepository>();
                services.AddScoped<IPlayoffRoundCoupleRepository, D3PlayoffRoundCoupleRepository>();

                services.AddScoped<IMatchDomainService, MatchDomainService>();
                services.AddScoped<ITeamDomainService, TeamDomainService>();
                services.AddScoped<ITournamentDomainService, TournamentDomainService>();
                services.AddScoped<ITournamentPlayerStatDomainService, TournamentPlayerStatDomainService>();
                services.AddScoped<IUserDomainService, UserDomainService>();

                services.AddScoped<AccountWebService>();
                services.AddScoped<MatchWebService>();
                services.AddScoped<PlayerWebService>();
                services.AddScoped<TeamWebService>();
                services.AddScoped<TournamentWebService>();

                ServiceProvider = services.BuildServiceProvider();
            }
        }

        public static IServiceScope CreateScope()
        {
            var ret = ServiceProvider.CreateScope();

            return ret;
        }

        [Obsolete]
        public static void InitServices(IServiceScope scope)
        {
            var qc = scope.GetService<IQueryContainer>();
            var unitOfWork = scope.GetService<IUnitOfWork>();

            var dbConnection = scope.GetService<IDbConnection>();
            var d3Context = scope.GetService<ID3Context>();

            var tournamentRepository = scope.GetService<ITournamentRepository>();
            var teamRepository = scope.GetService<ITeamRepository>();
            var matchRepository = scope.GetService<IMatchRepository>();
            var matchSetScoreRepository = scope.GetService<IMatchSetScoreRepository>();
            var playoffRoundCoupleRepository = scope.GetService<IPlayoffRoundCoupleRepository>();

            var matchDomainService = scope.GetService<IMatchDomainService>();
            var teamDomainService = scope.GetService<ITeamDomainService>();
            var tournamentDomainService = scope.GetService<ITournamentDomainService>();
            var tournamentPlayerStatDomainService = scope.GetService<ITournamentPlayerStatDomainService>();
            var userDomainService = scope.GetService<IUserDomainService>();

            var accountWebService = scope.GetService<AccountWebService>();
            var matchWebService = scope.GetService<MatchWebService>();
            var playerWebService = scope.GetService<PlayerWebService>();
            var teamWebService = scope.GetService<TeamWebService>();
            var tournamentWebService = scope.GetService<TournamentWebService>();



            if (qc == null || tournamentRepository == null || dbConnection == null || d3Context == null || teamDomainService == null || tournamentDomainService == null || tournamentPlayerStatDomainService == null || userDomainService == null || unitOfWork == null || teamRepository == null || matchRepository == null || matchDomainService == null || matchSetScoreRepository == null || playoffRoundCoupleRepository == null || accountWebService == null || matchWebService == null || playerWebService == null || teamWebService == null || tournamentWebService == null)
            {
                throw new Exception("Invalid injection...");
            }

            //QC = qc;
            //UnitOfWork = unitOfWork;

            //DbConnection = dbConnection;
            //D3Context = d3Context;

            //MatchDomainService = matchDomainService;
            //TeamDomainService = teamDomainService;
            //TournamentDomainService = tournamentDomainService;
            //TournamentPlayerStatDomainService = tournamentPlayerStatDomainService;
            //UserDomainService = userDomainService;

            //TournamentRepository = tournamentRepository;
            //TeamRepository = teamRepository;
            //MatchRepository = matchRepository;
            //MatchSetScoreRepository = matchSetScoreRepository;
            //PlayoffRoundCoupleRepository = playoffRoundCoupleRepository;

            //AccountWebService = accountWebService;
            //MatchWebService = matchWebService;
            //PlayerWebService = playerWebService;
            //TeamWebService = teamWebService;
            //TournamentWebService = tournamentWebService;
        }
    }
}
