using KLO128.D3ORM.Sample.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args
{
    public class SignUpArgs : IArgs
    {
        [Display(Name = nameof(Translations.Email), ResourceType = typeof(Translations))]
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Display(Name = nameof(Translations.Password), ResourceType = typeof(Translations))]
        [Required]
        public string Password { get; set; } = null!;

        [Display(Name = nameof(Translations.ConfirmPassword), ResourceType = typeof(Translations))]
        [Required]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; } = null!;

        [Display(Name = nameof(Translations.PhoneNumber), ResourceType = typeof(Translations))]
        [Required]
        public string? PhoneNumber { get; set; }

        [Display(Name = nameof(Translations.FirstName), ResourceType = typeof(Translations))]
        [Required]
        public string FirstName { get; set; } = null!;

        [Display(Name = nameof(Translations.LastName), ResourceType = typeof(Translations))]
        [Required]
        public string LastName { get; set; } = null!;

        [Display(Name = nameof(Translations.Gender), ResourceType = typeof(Translations))]
        [RegularExpression("male|female")]
        [Required]
        public string Gender { get; set; } = null!;

        [Display(Name = nameof(Translations.DateOfBirth), ResourceType = typeof(Translations))]
        [Required]
        public DateTime DateOfBirth { get; set; }

        public string? RequestToken { get; set; }
    }
}
