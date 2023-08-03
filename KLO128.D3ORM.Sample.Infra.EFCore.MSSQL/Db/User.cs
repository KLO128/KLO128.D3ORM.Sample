using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.MSSQL.Db
{
    public partial class User
    {
        public User()
        {
            TeamPlayers = new HashSet<TeamPlayer>();
            TournamentPlayerStats = new HashSet<TournamentPlayerStat>();
            UserClaims = new HashSet<UserClaim>();
            UserLogins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool ExternalLogin { get; set; }
        public string? RegistrationGuid { get; set; }
        public DateTime? GuidexpirationDate { get; set; }

        public virtual ICollection<TeamPlayer> TeamPlayers { get; set; }
        public virtual ICollection<TournamentPlayerStat> TournamentPlayerStats { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
