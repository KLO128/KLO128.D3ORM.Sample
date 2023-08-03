using KLO128.D3ORM.Sample.Application.Contracts.DTOs;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results;
using KLO128.D3ORM.Sample.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Application.Contracts.Services
{
    public interface IPlayerService
    {
        ServiceResult<PlayerStatsResult> GetPlayerStats(int? tournamentId, int? playerId);
    }
}
