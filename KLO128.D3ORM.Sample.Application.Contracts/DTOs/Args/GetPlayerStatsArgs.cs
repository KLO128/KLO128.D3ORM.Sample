﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    [Obsolete]
    public class GetPlayerStatsArgs : IArgs
    {
        public int? TournamentId { get; set; }

        public int? PlayerId { get; set; }

        public string? RequestToken { get; set; }
    }
}
