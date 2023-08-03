using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Presentation.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;

namespace KLO128.D3ORM.Sample.Presentation.WebApi
{
    public class LocalizationAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.TryGetService(out IStringLocalizer? service) && service is MyLocalizer localizer)
            {
                localizer.CultureString = context.HttpContext.Session.GetString(Constants.WebApi.LanguageSessionKey) ?? context.HttpContext.Request.Headers[Constants.WebApi.AcceptLanguage];
            }
            else
            {
                throw new InvalidProgramException($"The controller {context.Controller.GetType()} does not have {nameof(MyLocalizer)} injected.");
            }
        }
    }
}
