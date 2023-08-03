
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class TeamPlayerDTO
    {

        public int TeamPlayerId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public DateTime LastChange { get; set; }
        public int? ChangedBy { get; set; }
        public UserDTO Player { get; set; } = null!;
    }
}
