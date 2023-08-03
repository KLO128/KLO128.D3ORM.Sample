
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class MatchSetScoreDTO
    {

        public int MatchSetScoreId { get; set; }
        public int MatchId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int SetOrder { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
    }
}
