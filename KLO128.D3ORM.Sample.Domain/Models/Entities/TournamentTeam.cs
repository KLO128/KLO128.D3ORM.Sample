
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class TournamentTeam
    {

        
        public int TournamentTeamId { get; set; }
        
        public int TournamentId { get; set; }
        
        public int TeamId { get; set; }
        
        public string? BasicGroupName { get; set; }
        
        public DateTime RegistrationDate { get; set; }
        
        public bool EntryFeePaid { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
        
        public Team Team { get; set; } = null!;
        
        public Tournament Tournament { get; set; } = null!;
        private ICollection<TournamentTeamStat>? tournamentTeamStats;
        public ICollection<TournamentTeamStat> TournamentTeamStats
        {
            get
            {
                if (tournamentTeamStats == null)
                {
                    tournamentTeamStats = new List<TournamentTeamStat>();
                }

                return tournamentTeamStats;
            }
            set
            {
                tournamentTeamStats = value;
            }
        }

    }
}