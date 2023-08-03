
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class TournamentTeamStat
    {

        
        public int TournamentTeamStatId { get; set; }
        
        public int TournamentTeamId { get; set; }
        
        public int TournamentPhase { get; set; }
        
        public int PhasePoints { get; set; }
        
        public int Wins { get; set; }
        
        public int Losts { get; set; }
        
        public int Ties { get; set; }
        
        public int SetsWon { get; set; }
        
        public int SetsLost { get; set; }
        
        public int ScorePlus { get; set; }
        
        public int ScoreMinus { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
    }
}