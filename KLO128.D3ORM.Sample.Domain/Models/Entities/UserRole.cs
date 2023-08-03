
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class UserRole
    {

        
        public int UserRoleId { get; set; }
        
        public int UserId { get; set; }
        
        public int RoleId { get; set; }
        
        public bool IsActive { get; set; }
        
        public int TeamIdOrDefault { get; set; }
        
        public Role Role { get; set; } = null!;
    }
}