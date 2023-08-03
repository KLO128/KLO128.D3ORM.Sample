using KLO128.D3ORM.Sample.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KLO128.D3ORM.Sample.Application.Contracts.DTOs
{
    public class RegularExpressionAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute //System.ComponentModel.DataAnnotations.RegularExpressionAttribute
    {
        private Regex Regex { get; set; }

        public override bool RequiresValidationContext => true;

        public RegularExpressionAttribute(string pattern) : base()
        {
            Regex = new Regex(pattern);
            ErrorMessageResourceName = nameof(Translations.msgRegexFailed);
            ErrorMessageResourceType = typeof(Translations);
        }

        public override bool IsValid(object? value)
        {
            if (value?.ToString() is not string str)
            {
                return false;
            }

            return Regex.IsMatch(str);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return IsValid(value) ? ValidationResult.Success : new ValidationResult(FormatErrorMessage(validationContext.DisplayName ?? validationContext.MemberName ?? string.Empty));
        }
    }
}
