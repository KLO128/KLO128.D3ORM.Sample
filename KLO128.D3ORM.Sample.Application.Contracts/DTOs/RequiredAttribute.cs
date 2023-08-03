using KLO128.D3ORM.Sample.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs
{
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredAttribute() : base()
        {
            ErrorMessageResourceName = nameof(Translations.msgRequired);
            ErrorMessageResourceType = typeof(Translations);
        }

        public override bool IsValid(object? value)
        {
            return !string.IsNullOrEmpty(value?.ToString());
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return IsValid(value) ? ValidationResult.Success : new ValidationResult(FormatErrorMessage(validationContext.DisplayName ?? validationContext.MemberName ?? string.Empty));
        }
    }
}
