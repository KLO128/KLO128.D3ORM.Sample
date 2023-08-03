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
    [Authorize(Roles.Host)]
    public class PlayerController : ControllerBase
    {
        public IStringLocalizer StringLocalizer { get; set; }

        public IPlayerService PlayerService { get; set; }

        public IAccountService AccountService { get; set; }

        public PlayerController(IStringLocalizer StringLocalizer, IAccountService AccountService, IPlayerService PlayerService)
        {
            this.StringLocalizer = StringLocalizer;
            this.AccountService = AccountService;
            this.PlayerService = PlayerService;
        }

        [HttpGet(nameof(GetPlayerStats))]
        public IActionResult GetPlayerStats(int? tournamentId, int? playerId, [FromHeader] string? requestToken)
        {
            return this.GetJsonResult(PlayerService.GetPlayerStats(tournamentId, playerId));
        }
    }
}
