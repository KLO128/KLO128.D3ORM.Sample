using KLO128.D3ORM.Sample.Domain.Models.Entities;
using System;

namespace KLO128.D3ORM.Sample.Tests.UnitTests.Mocks
{
    public static class MockData
    {
        public static Team NewTeam { get; } = new Team()
        {
            IsActive = true,
            ChangedBy = null,
            LastChange = new DateTime(2022, 4, 9, 12, 0, 0),
            Logo = null,
            Name = "Mock-Team1",
            RegistrationDate = new DateTime(2022, 4, 9, 11, 59, 55),
            TeamId = 0
        };

        public static User NewPlayer { get; set; } = new User
        {
            AccessFailedCount = 0,
            Email = "new.player@team.com",
            EmailConfirmed = false,
            ExternalLogin = false,
            FirstName = "New",
            Gender = "male",
            GuidexpirationDate = new DateTime(2022, 4, 8, 12, 0, 0),
            LastName = "Player",
            LockoutEnabled = true,
            LockoutEndDateUtc = null,
            PasswordHash = null,
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            RegistrationGuid = null,
            SecurityStamp = null,
            TwoFactorEnabled = false,
            UserId = 0,
            UserName = "new.player@team.com"
        };

        public static TeamPlayer NewTeamPlayer { get; set; } = new TeamPlayer
        {
            ChangedBy = null,
            LastChange = new DateTime(2022, 4, 18, 23, 5, 0),
            PlayerId = 1,
            TeamId = 4,
            TeamPlayerId = 0
        };

        public static Match NewMatch { get; set; } = new Match
        {
            AwayTeamId = 1,
            HomeTeamId = 4,
            ChangedBy = null,
            LastChange = new DateTime(2022, 11, 1, 0, 5, 25),
            MatchDate = new DateTime(2022, 10, 31, 20, 0, 0),
            MatchId = 0,
            PlayoffRoundCoupleId = null,
            RefereeId = 3,
            TournamentId = 2,
            TournamentPhase = 1,
            WinnerId = 4
        };

        public static MatchSetScore MatchSetScoreToEdit { get; set; } = new MatchSetScore
        {
            AwayTeamScore = 19,
            ChangedBy = null,
            HomeTeamScore = 25,
            LastChange = new DateTime(2022, 5, 31, 12, 0, 0),
            MatchId = 1,
            MatchSetScoreId = 2,
            SetOrder = 1
        };
    }
}
