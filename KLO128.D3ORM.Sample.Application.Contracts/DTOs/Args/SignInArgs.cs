using KLO128.D3ORM.Sample.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class SignInArgs : IArgs
    {
        [Display(Name = nameof(Translations.UserName), ResourceType = typeof(Translations))]
        [Required]
        public string UserName { get; set; } = null!;

        [Display(Name = nameof(Translations.Password), ResourceType = typeof(Translations))]
        [Required]
        public string Password { get; set; } = null!;

        public string? RequestToken { get; set; }
    }
}
