using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.Sample.Domain.Models;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Infra.D3ORM.Specs;
using System.Reflection;

namespace KLO128.D3ORM.Sample.Infra.D3ORM
{
    public class QueryContainer : IQueryContainer
    {
        public ISpecification<Team> TeamBaseQuery => D3TeamBaseQuery.GetSingleton(D3Context);

        public ISpecification<Team> TeamEmptyQuery => D3TeamEmptyQuery.GetSingleton(D3Context);

        public ISpecification<Match> MatchBaseQuery => D3MatchBaseQuery.GetSingleton(D3Context);

        public ISpecification<Tournament> TournamentBaseQuery => D3TournamentBaseQuery.GetSingleton(D3Context);

        public ISpecification<User> UserPublicBaseQuery => D3UserPublicBaseQuery.GetSingleton(D3Context);

        /// <summary>
        /// Gets prop name patterns for excluding user sensitive data.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="that"></param>
        /// <returns></returns>
        public static string[] UserSensitiveData { get; } =
            new string[]
            {
                "Email*",
                "Password*",
                "PhoneNumber*",
                nameof(User.AccessFailedCount),
                nameof(User.ExternalLogin),
                nameof(User.GuidexpirationDate),
                nameof(User.LockoutEnabled),
                nameof(User.LockoutEndDateUtc),
                nameof(User.RegistrationGuid),
                nameof(User.SecurityStamp),
                nameof(User.TwoFactorEnabled),
                nameof(User.UserName)
            };

        private ID3Context D3Context { get; set; }

        public ISpecification<TournamentTeam> TournamentTeamSortedByGroupQuery => D3TournamentTeamsSortedByGroupQuery.GetSingleton(D3Context);

        internal static Type? D3ContextType = null;

        public QueryContainer(ID3Context D3Context)
        {
            this.D3Context = D3Context;

            if (D3ContextType != D3Context.GetType())
            {
                InitAllSpecs();

                D3ContextType = D3Context.GetType();
            }
        }

        public void InitAllSpecs()
        {
            var types = GetType().Assembly.GetExportedTypes();

            foreach (var type in types)
            {
                if (type == null || (!type.FullName?.Contains("Specs") ?? false))
                {
                    continue;
                }

                if (type.GetMethod(nameof(D3MatchBaseQuery.GetSingleton), BindingFlags.Static | BindingFlags.Public) is MethodInfo method)
                {
                    method.Invoke(null, new object[] { D3Context });
                }
            }
        }

        public ISpecificationWithParams<TEntity> CreateQueryParamized<TEntity>(ISpecification<TEntity> baseQuery, ISpecificationWithParams filterQuery) where TEntity : class
        {
            var spec = baseQuery.And(filterQuery);

            return new D3SpecificationWithParams<TEntity>(spec)
            {
                Parameters = filterQuery.Parameters
            };
        }

        private IDictionary<int, object?> GetFilterParamsGeneral(params object?[] filterParams)
        {
            var ret = new Dictionary<int, object?>();

            for (int i = 0; i < filterParams.Length; i++)
            {
                ret.Add(i, filterParams[i]);
            }

            return ret;
        }

        public ISpecificationWithParams<Team> GetTeamIdFilterQuery(int? teamId)
        {
            return new D3SpecificationWithParams<Team>(D3TeamIdFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(teamId)
            };
        }

        public ISpecificationWithParams<TournamentTeam> GetTournamentTeamFilterQuery(int? tournamentId, int? teamId)
        {
            return new D3SpecificationWithParams<TournamentTeam>(D3TournamentTeamFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(tournamentId, teamId)
            };
        }

        public ISpecificationWithParams<TournamentTeam> GetTournamentTeamAndStatsFilterQuery(int? tournamentId, int? teamId, int? tournamentPhase)
        {
            return new D3SpecificationWithParams<TournamentTeam>(D3TournamentTeamAndStatsFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(tournamentId, teamId, tournamentPhase)
            };
        }

        public ISpecificationWithParams<TournamentTeamRank> GetTournamentTeamsSortedByStatsQuery(int tournamentId, int? tournamentPhase)
        {
            return new D3SpecificationWithParams<TournamentTeamRank>(D3TournamentTeamRankSortedByStatsQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(tournamentId, tournamentPhase)
            };
        }

        public ISpecificationWithParams<TournamentPlayerStat> GetTourPlayerStatBaseFilterQuery(int? playerId, int? tournamentId)
        {
            return new D3SpecificationWithParams<TournamentPlayerStat>(D3TourPlayerStatBaseFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(playerId, tournamentId)
            };
        }

        public ISpecificationWithParams<Team> GetTeamNameFilterQuery(string teamName)
        {
            return new D3SpecificationWithParams<Team>(D3TeamNameFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(teamName)
            };
        }

        public ISpecificationWithParams<User> GetUserEmailFilterQuery(string email)
        {
            return new D3SpecificationWithParams<User>(D3UserEmailFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(email)
            };
        }

        public ISpecificationWithParams<User> GetUserAndRolesByEmailFilterQuery(string email)
        {
            return new D3SpecificationWithParams<User>(D3UserAndRolesByEmailQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(email)
            };
        }

        public ISpecificationWithParams<User> GetUserAndRolesByIdFilterQuery(int userId)
        {
            return new D3SpecificationWithParams<User>(D3UserAndRolesByIdQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(userId)
            };
        }

        public ISpecificationWithParams<User> GetUserIdFilterQuery(int? userId, int? teamId)
        {
            return new D3SpecificationWithParams<User>(D3UserIdAndTeamRoleFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(userId, teamId)
            };
        }

        public ISpecificationWithParams<User> GetUserIdFilterQuery(int? userId)
        {
            return new D3SpecificationWithParams<User>(D3UserIdAndTeamRoleFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(userId)
            };
        }

        public ISpecificationWithParams<User> GetUserIdPublicFilterQuery(int userId)
        {
            return new D3SpecificationWithParams<User>(D3UserIdFilterPublicQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(userId)
            };
        }

        public ISpecificationWithParams<Tournament> GetTournamentNameFilterQuery(string tournamentName)
        {
            return new D3SpecificationWithParams<Tournament>(D3TournamentNameFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(tournamentName)
            };
        }

        public ISpecificationWithParams<Tournament> GetTournamentIdFilterQuery(int tournamentId)
        {
            return new D3SpecificationWithParams<Tournament>(D3TournamentIdFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(tournamentId)
            };
        }

        public ISpecificationWithParams<Match> GetMatchBaseTournamentPhaseAndTeamIdFilterQuery(int? tournamentId, int? teamId, int? tournamentPhase)
        {
            return new D3SpecificationWithParams<Match>(D3MatchBaseTournamentPhaseAndTeamIdFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(tournamentId, teamId, tournamentPhase)
            };
        }

        public ISpecificationWithParams<Match> GetMatchIdBaseFilterQuery(int? matchId)
        {
            return new D3SpecificationWithParams<Match>(D3MatchBaseQuery.GetSingleton(D3Context).CompareFormat(x => x.MatchId, ComparisonOp.EQUALS, 0))
            {
                Parameters = GetFilterParamsGeneral(matchId)
            };
        }

        public ISpecificationWithParams<PlayoffRoundCouple> GetPlayoffRoundCoupleBaseFilterQuery(int? tournamentId, int? playoffRound)
        {
            return new D3SpecificationWithParams<PlayoffRoundCouple>(D3PlayoffRoundCoupleBaseFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(tournamentId, playoffRound)
            };
        }

        public ISpecificationWithParams<PlayoffRoundCouple> GetPlayoffRoundCoupleFilterQuery(int? tournamentId, int? playoffRound)
        {
            return new D3SpecificationWithParams<PlayoffRoundCouple>(D3PlayoffRoundCoupleFilterQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(tournamentId, playoffRound)
            };
        }

        public ISpecificationWithParams<Team> GetTeamIdBaseFilterQuery(int? teamId)
        {
            return CreateQueryParamized(TeamBaseQuery, GetTeamIdFilterQuery(teamId));
        }

        public ISpecificationWithParams<Team> GetTeamBaseTournamentTeamStatsFilterQuery(int? tournamentId, int? teamId, int? tournamentPhase)
        {
            return CreateQueryParamized(TeamBaseQuery, GetTournamentTeamAndStatsFilterQuery(tournamentId, teamId, tournamentPhase));
        }

        public ISpecificationWithParams<Tournament> GetTournamenIdBaseFilterQuery(int tournamentId)
        {
            return CreateQueryParamized(TournamentBaseQuery, GetTournamentIdFilterQuery(tournamentId));
        }
    }
}
