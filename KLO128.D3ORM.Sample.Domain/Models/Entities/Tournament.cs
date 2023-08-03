
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class Tournament
    {

        
        public int TournamentId { get; set; }
        
        public int? TourSerieId { get; set; }
        
        public int? AddressId { get; set; }
        
        public string Name { get; set; } = null!;
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public float? EntryFee { get; set; }
        
        public int? MaxNumOfTeams { get; set; }
        
        public string? Note { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
        
        public Address? Address { get; set; }
        
        public TourSerie? TourSerie { get; set; }
        private ICollection<Match>? matches;
        public ICollection<Match> Matches
        {
            get
            {
                if (matches == null)
                {
                    matches = new List<Match>();
                }

                return matches;
            }
            set
            {
                matches = value;
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