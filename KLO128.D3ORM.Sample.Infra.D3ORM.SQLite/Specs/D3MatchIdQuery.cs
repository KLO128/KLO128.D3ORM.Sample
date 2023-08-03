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
    public class D3MatchIdQuery : D3Specification<Match>
    {
        public D3MatchIdQuery(ID3Context D3Context, int id) : base(D3Context, id)
        {
        }

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?>();

        public override string? SortAppendix { get; protected set; }

        protected override string? BaseSQL { get; set; } = @"SELECT
	[match].[MatchId] AS '.MatchId'
	, [match].[HomeTeamId] AS '.HomeTeamId'
	, [match].[AwayTeamId] AS '.AwayTeamId'
	, [match].[TournamentId] AS '.TournamentId'
	, [match].[TournamentPhase] AS '.TournamentPhase'
	, [match].[WinnerId] AS '.WinnerId'
	, [match].[RefereeId] AS '.RefereeId'
	, [match].[MatchDate] AS '.MatchDate'
	, [match].[LastChange] AS '.LastChange'
	, [match].[ChangedBy] AS '.ChangedBy'
 FROM [Match] [match]

";

        private string? localFilterExpression;

        protected override string LocalFilterExpression
        {
            get
            {
                if (localFilterExpression == null)
                {
                    localFilterExpression = $"{GetDbName(nameof(Match)).LowerizeFirst()}.{GetDbName(nameof(Match.MatchId))} = {{0}}";
                }

                return localFilterExpression;
            }
        }

        public override Func<ID3Context, object?[], D3Specification<Match>> CloneNewFunc { get; } = (x, y) => new D3MatchIdQuery(x, (int?)y.First() ?? 0);
    }
}
