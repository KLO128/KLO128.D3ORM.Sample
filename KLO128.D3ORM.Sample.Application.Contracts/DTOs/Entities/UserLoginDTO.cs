
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class UserLoginDTO
    {

        public string LoginProvider { get; set; } = null!;
        public string ProviderKey { get; set; } = null!;
        public int UserId { get; set; }
    }
}
