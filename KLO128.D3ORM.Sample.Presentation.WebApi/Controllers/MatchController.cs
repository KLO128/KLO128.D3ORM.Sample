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
    [Authorize(Roles.Player)]
    public class MatchController : ControllerBase
    {
        public IStringLocalizer StringLocalizer { get; set; }

        public IMatchService MatchService { get; set; }

        public IAccountService AccountService { get; set; }

        public MatchController(IStringLocalizer StringLocalizer, IAccountService AccountService, IMatchService MatchService)
        {
            this.StringLocalizer = StringLocalizer;
            this.AccountService = AccountService;
            this.MatchService = MatchService;
        }

        [Authorize(Roles.Admin)]
        [HttpPost(nameof(AddMatch))]
        public IActionResult AddMatch([FromBody] AddMatchArgs args)
        {
            return this.GetJsonResult(MatchService.AddMatch(args, this.GetSignedInUserId(), false));
        }

        [Authorize(Roles.Admin)]
        [HttpPost(nameof(AddMatchSetScore))]
        public IActionResult AddMatchSetScore([FromBody] AddMatchSetScoreArgs args)
        {
            return this.GetJsonResult(MatchService.AddMatchSetScore(args, this.GetSignedInUserId(), false));
        }

        [HttpGet]
        public IActionResult GetMatches(int? tournamentId, int? teamId, int? tournamentPhase, [FromHeader] string? requestToken)
        {
            return this.GetJsonResult(MatchService.GetMatches(tournamentId, teamId, tournamentPhase));
        }

        [Authorize(Roles.Admin)]
        [HttpPost(nameof(UpdateMatchSetScore))]
        public IActionResult UpdateMatchSetScore([FromBody] UpdateMatchSetScoreArgs args)
        {
            return this.GetJsonResult(MatchService.UpdateMatchSetScoreTransact(args, this.GetSignedInUserId(), false));
        }
    }
}
