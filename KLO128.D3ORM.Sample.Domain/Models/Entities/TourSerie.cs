
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class TourSerie
    {

        
        public int TourSerieId { get; set; }
        
        public string Name { get; set; } = null!;
        
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        public string? Category { get; set; }
        
        public string? Note { get; set; }
        
        public DateTime LastChange { get; set; } = DateTime.UtcNow;
        
        public int? ChangedBy { get; set; }
        private ICollection<Tournament>? tournaments;
        public ICollection<Tournament> Tournaments
        {
            get
            {
                if (tournaments == null)
                {
                    tournaments = new List<Tournament>();
                }

                return tournaments;
            }
            set
            {
                tournaments = value;
            }
        }

    }
}