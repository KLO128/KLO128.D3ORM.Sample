using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using System.Security.Cryptography;
using System.Text;

namespace KLO128.D3ORM.Sample.Presentation.WebApi.Extensions
{
    public static class BaseControllerExt
    {
        public static string GetRequestToken(this ControllerBase controller)
        {
            var ret = controller.HttpContext.Session.GetString(Constants.WebApi.requestToken);

            if (ret == null)
            {
                return SetRequestToken(controller);
            }

            return ret;
        }

        public static string SetRequestToken(this ControllerBase controller)
        {
            var ret = Convert.ToBase64String(MD5.HashData(Encoding.UTF8.GetBytes(controller.HttpContext.Session.Id)));

            controller.HttpContext.Session.SetString(Constants.WebApi.requestToken, ret);

            return ret;
        }

        public static int GetSignedInUserId(this ControllerBase controller)
        {
            return controller.HttpContext.Session.GetSignedInUser()?.GetUserId() ?? 0;
        }

        public static IActionResult GetJsonResult<TResult>(this ControllerBase controller, ServiceResult<TResult> serviceResult)
        {
            serviceResult.RequestToken = GetRequestToken(controller);

            TryGetService(controller.HttpContext, out IStringLocalizer? localizer);

            if (localizer == null)
            {
                localizer = new MyLocalizer(Translations.ResourceManager);
            }

            if (serviceResult.Error == null)
            {
                return controller.Ok(serviceResult);
            }
            else if (serviceResult.Error.Status == System.Net.HttpStatusCode.Unauthorized)
            {
                return controller.Unauthorized(serviceResult);
            }
            else if (serviceResult.Error.Status == System.Net.HttpStatusCode.Forbidden)
            {
                return new StatusCodeResult(403);
            }
            else if (serviceResult.Error.Status == System.Net.HttpStatusCode.NotFound)
            {
                return controller.NotFound();
            }
            else if (serviceResult.Error.Status == System.Net.HttpStatusCode.BadRequest)
            {
                var failureModel = new ModelStateDictionary();
                failureModel.AddModelError(serviceResult.Error.ErrCode, localizer.GetString(serviceResult.Error.ErrCode, serviceResult.Error.ErrArgs));
                return controller.BadRequest(serviceResult.Result as ModelStateDictionary ?? failureModel);
            }
            else
            {
                return controller.Problem(localizer.GetString(serviceResult.Error.ErrCode));
            }
        }

        public static bool TryGetService<TService>(this HttpContext httpContext, out TService? service) where TService : class
        {
            if (httpContext.RequestServices.GetService(typeof(TService)) is TService service0)
            {
                service = service0;

                return true;
            }

            service = null;

            return false;
        }

        public static bool IsFilterOverriden<TAttribute>(this TAttribute that, FilterContext context) where TAttribute : IFilterMetadata
        {
            var attrs = context.Filters.OfType<TAttribute>().ToArray();

            if (attrs.Length <= 1)
            {
                return false;
            }

            var i = 0;

            for (; i < attrs.Length; i++)
            {
                var attr = attrs[i];

                if (attr.Equals(that))
                {
                    break;
                }
            }

            return i < attrs.Length - 1;
        }
    }
}
