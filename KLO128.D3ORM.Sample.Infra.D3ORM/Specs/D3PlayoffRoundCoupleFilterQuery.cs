using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3PlayoffRoundCoupleFilterQuery
    {
        private static ISpecification<PlayoffRoundCouple>? that = null;

        public static ISpecification<PlayoffRoundCouple> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<PlayoffRoundCouple>(d3Context)
                    .And(D3Specification.Create<TournamentTeam>(d3Context).CompareFormat(x => x.TournamentId, ComparisonOp.EQUALS, 0, LogicalOp.AND)
                    .OrderBy(x => x.TournamentId, true, 1)) // sort order 1
                    .CompareFormat(x => x.PlayoffRound, ComparisonOp.EQUALS, 1, LogicalOp.AND)
                    .OrderBy(x => x.PlayoffRound); // sort order 0 + 10

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
