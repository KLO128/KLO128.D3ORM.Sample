
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class TourSerieDTO
    {

        public int TourSerieId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Category { get; set; }
        public string? Note { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        private ICollection<TournamentDTO>? tournaments;
        public ICollection<TournamentDTO> Tournaments
        {
            get
            {
                if (tournaments == null)
                {
                    tournaments = new List<TournamentDTO>();
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
