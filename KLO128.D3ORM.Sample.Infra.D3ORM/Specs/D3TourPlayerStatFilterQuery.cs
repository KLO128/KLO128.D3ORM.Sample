using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3TourPlayerStatBaseFilterQuery
    {
        private static ISpecification<TournamentPlayerStat>? that = null;

        public static ISpecification<TournamentPlayerStat> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<TournamentPlayerStat>(d3Context)
                        .CompareFormat(x => x.TournamentId, ComparisonOp.EQUALS, 1)
                        .CompareFormat(x => x.PlayerId, ComparisonOp.EQUALS, 0)
                    .And(D3Specification.Create<User>(d3Context))
                    .And(D3Specification.Create<Tournament>(d3Context))
                    .ExcludeSelectPropMasks(QueryContainer.UserSensitiveData);

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
