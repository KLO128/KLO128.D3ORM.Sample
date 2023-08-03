﻿using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace KLO128.D3ORM.Sample.Presentation.WebApi.Extensions
{
    public class MyLocalizationAdapter : IValidationAttributeAdapterProvider
    {
        private readonly ValidationAttributeAdapterProvider _originalProvider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter? GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer? stringLocalizer)
        {
            //attribute.ErrorMessage = attribute.GetType().Name.Replace("Attribute", string.Empty);
            //if (attribute is DataTypeAttribute dataTypeAttribute)
            //    attribute.ErrorMessage += "_" + dataTypeAttribute.DataType;

            return _originalProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
