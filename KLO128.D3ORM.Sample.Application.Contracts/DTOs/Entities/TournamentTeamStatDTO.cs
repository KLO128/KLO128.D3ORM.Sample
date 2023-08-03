
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class TournamentTeamStatDTO
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
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
    }
}
