
///
/// generated file
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Domain.Models.Entities
{
    public class UserLogin
    {

        
        public string LoginProvider { get; set; } = null!;
        
        public string ProviderKey { get; set; } = null!;
        
        public int UserId { get; set; }
    }
}