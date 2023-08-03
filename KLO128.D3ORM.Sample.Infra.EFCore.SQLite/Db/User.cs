using System;
using System.Collections.Generic;

namespace KLO128.D3ORM.Sample.Infra.EFCore.SQLite.Db
{
    public partial class User
    {
        public User()
        {
            TournamentPlayerStats = new HashSet<TournamentPlayerStat>();
            UserClaims = new HashSet<UserClaim>();
            UserLogins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
        }

        public long UserId { get; set; }
        public string Email { get; set; } = null!;
        public byte[] EmailConfirmed { get; set; } = null!;
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[] PhoneNumberConfirmed { get; set; } = null!;
        public byte[] TwoFactorEnabled { get; set; } = null!;
        public string? LockoutEndDateUtc { get; set; }
        public byte[] LockoutEnabled { get; set; } = null!;
        public long AccessFailedCount { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string RegistrationDate { get; set; } = null!;
        public byte[] ExternalLogin { get; set; } = null!;
        public string? RegistrationGuid { get; set; }
        public string? GuidexpirationDate { get; set; }

        public virtual ICollection<TournamentPlayerStat> TournamentPlayerStats { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
