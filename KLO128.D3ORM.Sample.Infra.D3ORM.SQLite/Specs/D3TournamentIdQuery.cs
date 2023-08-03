using KLO128.D3ORM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.SQLite.Specs
{
    public class D3TournamentIdQuery : D3TournamentIdFilterQuery
    {
        public D3TournamentIdQuery(ID3Context D3Context, int id) : base(D3Context, id)
        {

        }
    }
}
