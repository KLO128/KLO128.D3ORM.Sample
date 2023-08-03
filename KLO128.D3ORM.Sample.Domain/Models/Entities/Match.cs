
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class Match
    {

        
        public int MatchId { get; set; }
        
        public int HomeTeamId { get; set; }
        
        public int AwayTeamId { get; set; }
        
        public int? TournamentId { get; set; }
        
        public int TournamentPhase { get; set; }
        
        public int? WinnerId { get; set; }
        
        public int? RefereeId { get; set; }
        
        public DateTime? MatchDate { get; set; }
        
        public int? PlayoffRoundCoupleId { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
        
        public Team AwayTeam { get; set; } = null!;
        
        public Team HomeTeam { get; set; } = null!;
        
        public PlayoffRoundCouple? PlayoffRoundCouple { get; set; }
        
        public Tournament? Tournament { get; set; }
        private ICollection<MatchSetScore>? matchSetScores;
        public ICollection<MatchSetScore> MatchSetScores
        {
            get
            {
                if (matchSetScores == null)
                {
                    matchSetScores = new List<MatchSetScore>();
                }

                return matchSetScores;
            }
            set
            {
                matchSetScores = value;
            }
        }

    }
}