using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3UserIdAndTeamRoleFilterQuery
    {
        private static ISpecification<User>? that = null;

        public static ISpecification<User> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<User>(d3Context)
                    .CompareFormat(x => x.UserId, ComparisonOp.EQUALS, 0)
                    .And(D3Specification.Create<UserRole>(d3Context)
                        .CompareFormat(x => x.TeamIdOrDefault, ComparisonOp.EQUALS, 1, LogicalOp.OR)
                        .CompareFormat(x => x.RoleId, ComparisonOp.EQUALS, 2, LogicalOp.OR)
                        .OrderBy(x => x.TeamIdOrDefault, sortOrder: 2));

                // sort order: 1) UserRole.TeamIdOrDefault

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
