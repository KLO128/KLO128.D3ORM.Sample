using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.Sample.Domain.Shared.Models.Entities;
using KLO128.D3ORM.Sample.Infra.D3ORM.SQLite.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.SQLite
{
    public class QueryContainer : IQueryContainer
    {
        private ID3Context D3Context { get; set; }

        public QueryContainer(ID3Context D3Context)
        {
            this.D3Context = D3Context;
        }

        private D3Specification<Team>? teamBaseQuery;

        public ISpecification<Team> TeamBaseQuery
        {
            get
            {
                if (teamBaseQuery == null)
                {
                    teamBaseQuery = new D3TeamBaseQuery(D3Context);
                }

                return teamBaseQuery;
            }
        }

        private D3Specification<TournamentPlayerStat>? tourPlayerStatBaseQuery;

        public ISpecification<TournamentPlayerStat> TourPlayerStatBaseQuery
        {
            get
            {
                if (tourPlayerStatBaseQuery == null)
                {
                    tourPlayerStatBaseQuery = new D3TourPlayerStatBaseQuery(D3Context);
                }

                return tourPlayerStatBaseQuery;
            }
        }

        private D3Specification<Match>? matchBaseQuery;

        public ISpecification<Match> MatchBaseQuery
        {
            get
            {
                if (matchBaseQuery == null)
                {
                    matchBaseQuery = new D3MatchBaseQuery(D3Context);
                }

                return matchBaseQuery;
            }
        }

        private D3Specification<Tournament>? tournamentBaseQuery;

        public ISpecification<Tournament> TournamentBaseQuery
        {
            get
            {
                if (tournamentBaseQuery == null)
                {
                    tournamentBaseQuery = new D3TournamentBaseQuery(D3Context);
                }

                return tournamentBaseQuery;
            }
        }

        public ISpecification<Team> TeamIdQuery(int teamId)
        {
            return new D3TeamIdQuery(D3Context, teamId);
        }
        public ISpecification<Team> TeamIdFilterQuery(int? teamId)
        {
            return new D3TeamIdFilterQuery(D3Context, teamId);
        }


        public ISpecification<Team> TeamNameQuery(string teamName)
        {
            return new D3TeamNameQuery(D3Context, teamName);
        }

        public ISpecification<Tournament> TournamentIdFilterQuery(int? tournamentId)
        {
            return new D3TournamentIdFilterQuery(D3Context, tournamentId);
        }

        public ISpecification<Tournament> TournamentIdQuery(int tournamentId)
        {
            return new D3TournamentIdQuery(D3Context, tournamentId);
        }

        public ISpecification<User> UserEmailQuery(string email)
        {
            return new D3UserEmailQuery(D3Context, email);
        }

        public ISpecification<User> UserIdFilterQuery(int? userId)
        {
            return new D3UserIdFilterQuery(D3Context, userId);
        }

        public ISpecification<User> UserIdQuery(int userId)
        {
            return new D3UserIdQuery(D3Context, userId);
        }

        public ISpecification<Tournament> TournamentNameQuery(string tournamentName)
        {
            return new D3TournamentNameQuery(D3Context, tournamentName);
        }

        public ISpecification<Match> MatchIdQuery(int matchId)
        {
            return new D3MatchIdQuery(D3Context, matchId);
        }
    }
}
