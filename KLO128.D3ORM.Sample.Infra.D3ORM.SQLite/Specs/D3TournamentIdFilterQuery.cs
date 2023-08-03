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
    public class D3TournamentIdFilterQuery : D3Specification<Tournament>
    {
        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?>();

        public override string? SortAppendix { get; protected set; }

        protected override string? BaseSQL { get; set; } = @"SELECT
	[tournament].[TournamentId] AS '.TournamentId'
	, [tournament].[TourSerieId] AS '.TourSerieId'
	, [tournament].[AddressId] AS '.AddressId'
	, [tournament].[Name] AS '.Name'
	, [tournament].[StartDate] AS '.StartDate'
	, [tournament].[EndDate] AS '.EndDate'
	, [tournament].[EntryFee] AS '.EntryFee'
	, [tournament].[MaxNumOfTeams] AS '.MaxNumOfTeams'
	, [tournament].[Note] AS '.Note'
	, [tournament].[LastChange] AS '.LastChange'
	, [tournament].[ChangedBy] AS '.ChangedBy'
 FROM [Tournament] [tournament]

";

        private string? localFilterExpression;

        protected override string LocalFilterExpression
        {
            get
            {
                if (localFilterExpression == null)
                {
                    localFilterExpression = $"{GetDbName(nameof(Tournament)).LowerizeFirst()}.{GetDbName(nameof(Tournament.TournamentId))} = {{0}}";
                }

                return localFilterExpression;
            }
        }

        public override Func<ID3Context, object?[], D3Specification<Tournament>> CloneNewFunc { get; } = (x, y) => new D3TournamentIdFilterQuery(x, (int?)y.First());

        public D3TournamentIdFilterQuery(ID3Context D3Context, int? id) : base(D3Context, id)
        {
        }
    }
}
