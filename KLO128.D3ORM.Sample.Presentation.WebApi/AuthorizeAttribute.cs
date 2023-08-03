using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.Services;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Presentation.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace KLO128.D3ORM.Sample.Presentation.WebApi
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter, IActionFilter
    {
        public Roles LowestRole { get; set; }

        public bool IgnoreRequestToken { get; set; }

        public AuthorizeAttribute(Roles role = Roles.Host)
        //: base(GetUpRoles(role))
        {
            LowestRole = role;
        }

        [Obsolete]
        private static string GetUpRoles(Roles role)
        {
            var sb = new StringBuilder(role.ToString());

            for (int i = (int)role + 1; i <= (int)Roles.Admin; i++)
            {
                sb.Append(',').Append(((Roles)i).ToString());
            }

            return sb.ToString();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (this.IsFilterOverriden(context))
            {
                return;
            }

            if (!IgnoreRequestToken)
            {
                if (context.ActionArguments.FirstOrDefault().Value is not IArgs args)
                {
                    args = new EmptyArgs
                    {
                        RequestToken = context.HttpContext.Request.Headers.ContainsKey(Constants.WebApi.requestToken) ? context.HttpContext.Request.Headers[Constants.WebApi.requestToken].FirstOrDefault() : null
                    };
                }

                if (context.Controller is not ControllerBase controller || args?.RequestToken != controller.GetRequestToken())
                {
                    context.Result = new StatusCodeResult(403);
                    return;
                }
            }

            if (!AllowAnonymous(context))
            {
                if (context.HttpContext.Session.GetSignedInUser() == null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (this.IsFilterOverriden(context))
            {
                return;
            }

            if (!AllowAnonymous(context))
            {
                if (!this.IsFilterOverriden(context))
                {
                    context.HttpContext.TryGetService(out IAccountService? service);
                    var principal = context.HttpContext.Session.GetSignedInUser();
                    if (service == null || principal == null || !service.IsInRole(principal.GetUserId(), LowestRole))
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                }
            }
        }

        private bool AllowAnonymous(FilterContext context)
        {
            return context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any() || LowestRole == Roles.Anonymous;
        }
    }
}
