﻿using KLO128.D3ORM.Common;
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
    public class D3TournamentNameQuery : D3Specification<Tournament>
    {
        public D3TournamentNameQuery(ID3Context D3Context, string name) : base(D3Context, name)
        {
        }

        public override Func<ID3Context, object?[], D3Specification<Tournament>> CloneNewFunc => (x, y) => new D3TournamentNameQuery(D3Context, y?.FirstOrDefault()?.ToString() ?? string.Empty);

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
                    localFilterExpression = $"{GetDbName(nameof(Tournament)).LowerizeFirst()}.{GetDbName(nameof(Tournament.Name))} = {{0}}";
                }

                return localFilterExpression;
            }
        }
    }
}
