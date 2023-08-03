
///
/// generated file 16.05.2023 8:07:44
///

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities
{
    public class ZUserDTO
    {

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public bool EmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool ExternalLogin { get; set; }
        private ICollection<UserClaimDTO>? userClaims;
        public ICollection<UserClaimDTO> UserClaims
        {
            get
            {
                if (userClaims == null)
                {
                    userClaims = new List<UserClaimDTO>();
                }

                return userClaims;
            }
            set
            {
                userClaims = value;
            }
        }

        private ICollection<UserRoleDTO>? userRoles;
        public ICollection<UserRoleDTO> UserRoles
        {
            get
            {
                if (userRoles == null)
                {
                    userRoles = new List<UserRoleDTO>();
                }

                return userRoles;
            }
            set
            {
                userRoles = value;
            }
        }

    }
}
