
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class UserClaim
    {

        
        public int UserClaimId { get; set; }
        
        public int UserId { get; set; }
        
        public string ClaimType { get; set; } = null!;
        
        public string ClaimValue { get; set; } = null!;
    }
}