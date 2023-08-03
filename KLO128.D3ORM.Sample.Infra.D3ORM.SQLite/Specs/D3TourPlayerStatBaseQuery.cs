using KLO128.D3ORM.Common;
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
	[tournamentPlayerStat].[TournamentPlayerStatId] AS '.TournamentPlayerStatId'
	, [tournamentPlayerStat].[TournamentId] AS '.TournamentId'
	, [tournamentPlayerStat].[PlayerId] AS '.PlayerId'
	, [tournamentPlayerStat].[TourPoints] AS '.TourPoints'
	, [tournamentPlayerStat].[AttackPoints] AS '.AttackPoints'
	, [tournamentPlayerStat].[AttackPercentage] AS '.AttackPercentage'
	, [tournamentPlayerStat].[ServicePoints] AS '.ServicePoints'
	, [tournamentPlayerStat].[ServicePercentage] AS '.ServicePercentage'
	, [tournamentPlayerStat].[UnforcedErrors] AS '.UnforcedErrors'
	, [tournamentPlayerStat].[LastChange] AS '.LastChange'
	, [tournamentPlayerStat].[ChangedBy] AS '.ChangedBy'
	, [join1_user].[UserId] AS 'Player(User).UserId'
	, [join1_user].[Email] AS 'Player(User).Email'
	, [join1_user].[EmailConfirmed] AS 'Player(User).EmailConfirmed'
	, [join1_user].[PasswordHash] AS 'Player(User).PasswordHash'
	, [join1_user].[SecurityStamp] AS 'Player(User).SecurityStamp'
	, [join1_user].[PhoneNumber] AS 'Player(User).PhoneNumber'
	, [join1_user].[PhoneNumberConfirmed] AS 'Player(User).PhoneNumberConfirmed'
	, [join1_user].[TwoFactorEnabled] AS 'Player(User).TwoFactorEnabled'
	, [join1_user].[LockoutEndDateUtc] AS 'Player(User).LockoutEndDateUtc'
	, [join1_user].[LockoutEnabled] AS 'Player(User).LockoutEnabled'
	, [join1_user].[AccessFailedCount] AS 'Player(User).AccessFailedCount'
	, [join1_user].[UserName] AS 'Player(User).UserName'
	, [join1_user].[FirstName] AS 'Player(User).FirstName'
	, [join1_user].[LastName] AS 'Player(User).LastName'
	, [join1_user].[Gender] AS 'Player(User).Gender'
	, [join1_user].[ExternalLogin] AS 'Player(User).ExternalLogin'
	, [join1_user].[RegistrationGuid] AS 'Player(User).RegistrationGuid'
	, [join1_user].[GuidexpirationDate] AS 'Player(User).GuidexpirationDate'
	, [join1_tournament].[TournamentId] AS 'Tournament.TournamentId'
	, [join1_tournament].[TourSerieId] AS 'Tournament.TourSerieId'
	, [join1_tournament].[AddressId] AS 'Tournament.AddressId'
	, [join1_tournament].[Name] AS 'Tournament.Name'
	, [join1_tournament].[StartDate] AS 'Tournament.StartDate'
	, [join1_tournament].[EndDate] AS 'Tournament.EndDate'
	, [join1_tournament].[EntryFee] AS 'Tournament.EntryFee'
	, [join1_tournament].[MaxNumOfTeams] AS 'Tournament.MaxNumOfTeams'
	, [join1_tournament].[Note] AS 'Tournament.Note'
	, [join1_tournament].[LastChange] AS 'Tournament.LastChange'
	, [join1_tournament].[ChangedBy] AS 'Tournament.ChangedBy'
 FROM [TournamentPlayerStat] [tournamentPlayerStat]
LEFT JOIN [User] [join1_user] ON [tournamentPlayerStat].[PlayerId] = [join1_user].[UserId]
LEFT JOIN [Tournament] [join1_tournament] ON [tournamentPlayerStat].[TournamentId] = [join1_tournament].[TournamentId]

";

        protected override string LocalFilterExpression { get; } = string.Empty;
    }
}
