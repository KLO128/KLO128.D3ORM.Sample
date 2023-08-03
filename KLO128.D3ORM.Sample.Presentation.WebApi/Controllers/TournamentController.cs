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
    public class TournamentController : ControllerBase
    {
        public IStringLocalizer StringLocalizer { get; set; }

        public ITournamentService TournamentService { get; set; }

        public IAccountService AccountService { get; set; }

        public TournamentController(IStringLocalizer StringLocalizer, IAccountService AccountService, ITournamentService TournamentService)
        {
            this.StringLocalizer = StringLocalizer;
            this.AccountService = AccountService;
            this.TournamentService = TournamentService;
        }

        [Authorize(Roles.Admin)]
        [HttpPost(nameof(CreatePlayoffFirstRoundCouples))]
        public IActionResult CreatePlayoffFirstRoundCouples(CreatePlayoffRoundArgs args)
        {
            return this.GetJsonResult(TournamentService.CreatePlayoffFirstRoundCouplesTransact(args, this.GetSignedInUserId(), false));
        }

        [Authorize(Roles.Admin)]
        [HttpPost(nameof(DrawGroups))]
        public IActionResult DrawGroups(DrawGroupsArgs args)
        {
            return this.GetJsonResult(TournamentService.DrawGroupsTransact(args, this.GetSignedInUserId(), false));
        }

        [Authorize(Roles.Admin)]
        [HttpPost(nameof(DrawMatches))]
        public IActionResult DrawMatches(DrawMatchesArgs args)
        {
            return this.GetJsonResult(TournamentService.DrawMatchesTransact(args, this.GetSignedInUserId(), false));
        }

        [HttpGet(nameof(GetPlayoffRoundCouples))]
        public IActionResult GetPlayoffRoundCouples(int tournamentId, int playoffRound, [FromHeader] string? requestToken)
        {
            return this.GetJsonResult(TournamentService.GetPlayoffCouples(tournamentId, playoffRound));
        }

        [Authorize(Roles.TeamAdmin)]
        [HttpPost(nameof(SignUpTeam))]
        public IActionResult SignUpTeam(SignUpTeamArgs args)
        {
            return this.GetJsonResult(TournamentService.SignUpTeamTransact(args, this.GetSignedInUserId()));
        }

        [Authorize(Roles.Admin)]
        [HttpPost(nameof(Create))]
        public IActionResult Create(CreateTournamentArgs args)
        {
            return this.GetJsonResult(TournamentService.CreateTournament(args, this.GetSignedInUserId(), false));
        }
    }
}
