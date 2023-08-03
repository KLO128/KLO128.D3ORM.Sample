using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Presentation.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KLO128.D3ORM.Sample.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Localization]
    [Authorize(Roles.Anonymous)]
    public class SessionController : ControllerBase
    {
        public IStringLocalizer StringLocalizer { get; set; }

        public SessionController(IStringLocalizer StringLocalizer)
        {
            this.StringLocalizer = StringLocalizer;
        }

        [HttpPost(nameof(SetLanguage))]
        public IActionResult SetLanguage(string lang, [FromHeader] string requestToken)
        {
            ControllerContext.HttpContext.Session.SetString(Constants.WebApi.LanguageSessionKey, lang);

            return this.GetJsonResult(new ServiceResult<string>("OK"));
        }

        [HttpGet]
        [Authorize(Roles.Anonymous, IgnoreRequestToken = true)]
        public IActionResult GetNewRequestToken()
        {
            this.SetRequestToken();
            return this.GetJsonResult(new ServiceResult<string>("New Request Token"));
        }
    }
}
