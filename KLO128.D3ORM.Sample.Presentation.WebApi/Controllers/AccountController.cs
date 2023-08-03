using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.Services;
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
    public class AccountController : ControllerBase
    {
        public IStringLocalizer StringLocalizer { get; set; }

        public IAccountService AccountService { get; set; }

        public AccountController(IStringLocalizer StringLocalizer, IAccountService AccountService)
        {
            this.StringLocalizer = StringLocalizer;
            this.AccountService = AccountService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index([FromHeader] string? requestToken)
        {
            return this.GetJsonResult(AccountService.GetDetail(ControllerContext.HttpContext.Session.GetSignedInUser()?.GetUserId() ?? 0));
        }

        [HttpPost(nameof(SignIn))]
        public IActionResult SignIn([FromBody] SignInArgs args)
        {
            var ret = AccountService.SignIn(args);
            ControllerContext.HttpContext.Session.SetSignedInUser(ret.Result);

            return this.GetJsonResult(ret);
        }

        [HttpPost(nameof(SignOut))]
        public IActionResult SignOut([FromHeader] string? requestToken)
        {
            ControllerContext.HttpContext.Session.SetSignedInUser(null);

            return Ok();
        }

        [HttpPost(nameof(SignUp))]
        public IActionResult SignUp([FromBody] SignUpArgs args)
        {
            return this.GetJsonResult(AccountService.SignUpTransact(args));
        }
    }
}
