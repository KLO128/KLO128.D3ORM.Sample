
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class TournamentPlayerStat
    {

        
        public int TournamentPlayerStatId { get; set; }
        
        public int TournamentId { get; set; }
        
        public int PlayerId { get; set; }
        
        public int? TourPoints { get; set; }
        
        public int? AttackPoints { get; set; }
        
        public float? AttackPercentage { get; set; }
        
        public int? ServicePoints { get; set; }
        
        public int? ServicePercentage { get; set; }
        
        public int? UnforcedErrors { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
        
        public User Player { get; set; } = null!;
        
        public Tournament Tournament { get; set; } = null!;
    }
}