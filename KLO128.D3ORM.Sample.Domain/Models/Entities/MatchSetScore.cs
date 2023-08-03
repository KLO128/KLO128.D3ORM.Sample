
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class MatchSetScore
    {

        
        public int MatchSetScoreId { get; set; }
        
        public int MatchId { get; set; }
        
        public int HomeTeamScore { get; set; }
        
        public int AwayTeamScore { get; set; }
        
        public int SetOrder { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
    }
}