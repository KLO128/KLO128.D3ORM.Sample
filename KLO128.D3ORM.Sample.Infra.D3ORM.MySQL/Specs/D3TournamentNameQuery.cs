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

namespace KLO128.D3ORM.Sample.Infra.D3ORM.MySQL.Specs
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
	`tournament`.`tournament_id` AS '.TournamentId'
	, `tournament`.`tour_serie_id` AS '.TourSerieId'
	, `tournament`.`address_id` AS '.AddressId'
	, `tournament`.`name` AS '.Name'
	, `tournament`.`start_date` AS '.StartDate'
	, `tournament`.`end_date` AS '.EndDate'
	, `tournament`.`entry_fee` AS '.EntryFee'
	, `tournament`.`max_num_of_teams` AS '.MaxNumOfTeams'
	, `tournament`.`note` AS '.Note'
	, `tournament`.`last_change` AS '.LastChange'
	, `tournament`.`changed_by` AS '.ChangedBy'
 FROM `tournament` `tournament`

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
