
///
/// generated file 20.04.2023 8:50:44
///

using System;
using System.Data;
using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Repositories;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.Repositories
{
    public class D3RoleRepository : D3CommonRepository<Role>, IRoleRepository
    {
        public D3RoleRepository(IDbConnection Connection, ID3Context D3Context) : base(Connection, D3Context)
        {
        }
    }
}
