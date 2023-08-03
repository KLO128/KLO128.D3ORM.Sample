
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class TeamPlayer
    {

        
        public int TeamPlayerId { get; set; }
        
        public int TeamId { get; set; }
        
        public int PlayerId { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
        
        public User Player { get; set; } = null!;
    }
}