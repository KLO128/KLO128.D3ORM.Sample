using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Extensions;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.SQLite.Specs
{
    public class D3UserIdQuery : D3UserIdFilterQuery
    {
        public D3UserIdQuery(ID3Context D3Context, int id) : base(D3Context, id)
        {
        }
    }
}
