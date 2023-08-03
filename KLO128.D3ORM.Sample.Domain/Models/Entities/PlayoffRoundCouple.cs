
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class PlayoffRoundCouple
    {

        
        public int PlayoffRoundCoupleId { get; set; }
        
        public int TournamentTeam1Id { get; set; }
        
        public int TournamentTeam2Id { get; set; }
        
        public int PlayoffRound { get; set; }
        
        public int Team1Wins { get; set; }
        
        public int Team2Wins { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
        
        public TournamentTeam TournamentTeam1 { get; set; } = null!;
        
        public TournamentTeam TournamentTeam2 { get; set; } = null!;
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

    }
}