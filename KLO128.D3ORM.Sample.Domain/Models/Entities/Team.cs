
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class Team
    {

        
        public int TeamId { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string? Logo { get; set; }
        
        public DateTime RegistrationDate { get; set; }
        
        public bool IsActive { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
        private ICollection<TeamPlayer>? teamPlayers;
        public ICollection<TeamPlayer> TeamPlayers
        {
            get
            {
                if (teamPlayers == null)
                {
                    teamPlayers = new List<TeamPlayer>();
                }

                return teamPlayers;
            }
            set
            {
                teamPlayers = value;
            }
        }

        private ICollection<TournamentTeam>? tournamentTeams;
        public ICollection<TournamentTeam> TournamentTeams
        {
            get
            {
                if (tournamentTeams == null)
                {
                    tournamentTeams = new List<TournamentTeam>();
                }

                return tournamentTeams;
            }
            set
            {
                tournamentTeams = value;
            }
        }

    }
}