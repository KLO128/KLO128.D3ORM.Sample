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
    public class D3TeamNameQuery : D3Specification<Team>
    {
        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?>();

        public override string? SortAppendix { get; protected set; }

        protected override string? BaseSQL { get; set; } = @"SELECT
	[team].[TeamId] AS '.TeamId'
	, [team].[Name] AS '.Name'
	, [team].[Logo] AS '.Logo'
	, [team].[RegistrationDate] AS '.RegistrationDate'
	, [team].[Active] AS '.Active'
	, [team].[LastChange] AS '.LastChange'
	, [team].[ChangedBy] AS '.ChangedBy'
 FROM [Team] [team]

";

        private string? localFilterExpression;

        public D3TeamNameQuery(ID3Context D3Context, string name) : base(D3Context, name)
        {
        }

        protected override string LocalFilterExpression
        {
            get
            {
                if (localFilterExpression == null)
                {
                    localFilterExpression = $"{GetDbName(nameof(Team)).LowerizeFirst()}.{GetDbName(nameof(Team.Name))} = {{0}}";
                }

                return localFilterExpression;
            }
        }

        public override Func<ID3Context, object?[], D3Specification<Team>> CloneNewFunc { get; } = (x, y) => new D3TeamNameQuery(x, y.FirstOrDefault()?.ToString() ?? string.Empty);
    }
}
