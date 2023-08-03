using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3TeamBaseQuery
    {
        private static ISpecification<Team>? that = null;

        public static ISpecification<Team> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<Team>(d3Context)
                    .And(D3Specification.Create<TeamPlayer>(d3Context)
                        .And(D3Specification.Create<User>(d3Context)))
                    .And(D3Specification.Create<TournamentTeam>(d3Context)
                        .And(D3Specification.Create<TournamentTeamStat>(d3Context)))
                    .OrderBy(x => x.Name)
                    .ExcludeSelectPropMasks(QueryContainer.UserSensitiveData);

                D3Specification.PreBuild(that);
            }
            //D3TournamentTeamAndStatsFilterQuery
            return that;
        }
    }
}
