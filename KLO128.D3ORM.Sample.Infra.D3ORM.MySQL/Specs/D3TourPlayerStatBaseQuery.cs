using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Impl;
using KLO128.D3ORM.Sample.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.MySQL.Specs
{
    public class D3TourPlayerStatBaseQuery : D3Specification<TournamentPlayerStat>
    {
        public D3TourPlayerStatBaseQuery(ID3Context D3Context) : base(D3Context)
        {
        }

        public override bool ForceInnerJoin => false;

        public override List<PropertyInfo?> Aggs { get; } = new List<PropertyInfo?> { typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.Player)), typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.Tournament)) };

        public override string? SortAppendix { get; protected set; }

        public override Func<ID3Context, object?[], D3Specification<TournamentPlayerStat>> CloneNewFunc { get; } = (x, y) => new D3TourPlayerStatBaseQuery(x);

		protected override string? BaseSQL { get; set; } = @"SELECT
	`tournament_player_stat`.`tournament_player_stat_id` AS '.TournamentPlayerStatId'
	, `tournament_player_stat`.`tournament_id` AS '.TournamentId'
	, `tournament_player_stat`.`player_id` AS '.PlayerId'
	, `tournament_player_stat`.`tour_points` AS '.TourPoints'
	, `tournament_player_stat`.`attack_points` AS '.AttackPoints'
	, `tournament_player_stat`.`attack_percentage` AS '.AttackPercentage'
	, `tournament_player_stat`.`service_points` AS '.ServicePoints'
	, `tournament_player_stat`.`service_percentage` AS '.ServicePercentage'
	, `tournament_player_stat`.`unforced_errors` AS '.UnforcedErrors'
	, `tournament_player_stat`.`last_change` AS '.LastChange'
	, `tournament_player_stat`.`changed_by` AS '.ChangedBy'
	, `join1_user`.`user_id` AS 'Player(User).UserId'
	, `join1_user`.`email` AS 'Player(User).Email'
	, `join1_user`.`email_confirmed` AS 'Player(User).EmailConfirmed'
	, `join1_user`.`password_hash` AS 'Player(User).PasswordHash'
	, `join1_user`.`security_stamp` AS 'Player(User).SecurityStamp'
	, `join1_user`.`phone_number` AS 'Player(User).PhoneNumber'
	, `join1_user`.`phone_number_confirmed` AS 'Player(User).PhoneNumberConfirmed'
	, `join1_user`.`two_factor_enabled` AS 'Player(User).TwoFactorEnabled'
	, `join1_user`.`lockout_end_date_utc` AS 'Player(User).LockoutEndDateUtc'
	, `join1_user`.`lockout_enabled` AS 'Player(User).LockoutEnabled'
	, `join1_user`.`access_failed_count` AS 'Player(User).AccessFailedCount'
	, `join1_user`.`user_name` AS 'Player(User).UserName'
	, `join1_user`.`first_name` AS 'Player(User).FirstName'
	, `join1_user`.`last_name` AS 'Player(User).LastName'
	, `join1_user`.`gender` AS 'Player(User).Gender'
	, `join1_user`.`external_login` AS 'Player(User).ExternalLogin'
	, `join1_user`.`registration_guid` AS 'Player(User).RegistrationGuid'
	, `join1_user`.`guidexpiration_date` AS 'Player(User).GuidexpirationDate'
	, `join1_tournament`.`tournament_id` AS 'Tournament.TournamentId'
	, `join1_tournament`.`tour_serie_id` AS 'Tournament.TourSerieId'
	, `join1_tournament`.`address_id` AS 'Tournament.AddressId'
	, `join1_tournament`.`name` AS 'Tournament.Name'
	, `join1_tournament`.`start_date` AS 'Tournament.StartDate'
	, `join1_tournament`.`end_date` AS 'Tournament.EndDate'
	, `join1_tournament`.`entry_fee` AS 'Tournament.EntryFee'
	, `join1_tournament`.`max_num_of_teams` AS 'Tournament.MaxNumOfTeams'
	, `join1_tournament`.`note` AS 'Tournament.Note'
	, `join1_tournament`.`last_change` AS 'Tournament.LastChange'
	, `join1_tournament`.`changed_by` AS 'Tournament.ChangedBy'
 FROM `tournament_player_stat` `tournament_player_stat`
LEFT JOIN `user` `join1_user` ON `tournament_player_stat`.`player_id` = `join1_user`.`user_id`
LEFT JOIN `tournament` `join1_tournament` ON `tournament_player_stat`.`tournament_id` = `join1_tournament`.`tournament_id`

";

        protected override string LocalFilterExpression { get; } = string.Empty;
    }
}
