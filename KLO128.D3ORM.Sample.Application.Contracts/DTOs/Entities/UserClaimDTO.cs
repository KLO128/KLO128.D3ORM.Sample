
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class UserClaimDTO
    {

        public int UserClaimId { get; set; }
        public int UserId { get; set; }
        public string ClaimType { get; set; } = null!;
        public string ClaimValue { get; set; } = null!;
    }
}
