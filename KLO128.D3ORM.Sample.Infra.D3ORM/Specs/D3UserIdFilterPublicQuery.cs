using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Extensions;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3UserIdFilterPublicQuery
    {
        private static ISpecification<User>? that = null;

        public static ISpecification<User> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<User>(d3Context).CompareFormat(x => x.UserId, ComparisonOp.EQUALS, 0, LogicalOp.NONE).ExcludeSelectPropMasks(QueryContainer.UserSensitiveData);

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
