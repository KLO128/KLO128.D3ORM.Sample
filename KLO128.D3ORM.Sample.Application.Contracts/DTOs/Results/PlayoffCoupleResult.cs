using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results
{
    public class PlayoffCoupleResult
    {
        public TeamDTO Team1 { get; set; } = null!;

        public TeamDTO Team2 { get; set; } = null!;

        public List<MatchDTO> Matches { get; set; } = new List<MatchDTO>();

        public int? WinnerId { get; set; }
    }
}
