using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Specs
{
    public static class D3UserPublicBaseQuery
    {
        private static ISpecification<User>? that = null;

        public static ISpecification<User> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<User>(d3Context).ExcludeSelectPropMasks(QueryContainer.UserSensitiveData);

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
