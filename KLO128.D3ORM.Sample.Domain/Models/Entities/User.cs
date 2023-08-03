
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class User
    {

        
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
        private ICollection<TournamentPlayerStat>? tournamentPlayerStats;
        public ICollection<TournamentPlayerStat> TournamentPlayerStats
        {
            get
            {
                if (tournamentPlayerStats == null)
                {
                    tournamentPlayerStats = new List<TournamentPlayerStat>();
                }

                return tournamentPlayerStats;
            }
            set
            {
                tournamentPlayerStats = value;
            }
        }

        private ICollection<UserClaim>? userClaims;
        public ICollection<UserClaim> UserClaims
        {
            get
            {
                if (userClaims == null)
                {
                    userClaims = new List<UserClaim>();
                }

                return userClaims;
            }
            set
            {
                userClaims = value;
            }
        }

        private ICollection<UserLogin>? userLogins;
        public ICollection<UserLogin> UserLogins
        {
            get
            {
                if (userLogins == null)
                {
                    userLogins = new List<UserLogin>();
                }

                return userLogins;
            }
            set
            {
                userLogins = value;
            }
        }

        private ICollection<UserRole>? userRoles;
        public ICollection<UserRole> UserRoles
        {
            get
            {
                if (userRoles == null)
                {
                    userRoles = new List<UserRole>();
                }

                return userRoles;
            }
            set
            {
                userRoles = value;
            }
        }

    }
}