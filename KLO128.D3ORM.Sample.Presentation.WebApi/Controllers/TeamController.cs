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
    [Authorize(Roles.Host)]
    public class TeamController : ControllerBase
    {
        public IStringLocalizer StringLocalizer { get; set; }

        public ITeamService TeamService { get; set; }

        public IAccountService AccountService { get; set; }

        public TeamController(IStringLocalizer StringLocalizer, IAccountService AccountService, ITeamService TeamService)
        {
            this.StringLocalizer = StringLocalizer;
            this.AccountService = AccountService;
            this.TeamService = TeamService;
        }

        [Authorize(Roles.TeamAdmin)]
        [HttpPost(nameof(AddPlayer))]
        public IActionResult AddPlayer(AddPlayerArgs args)
        {
            return this.GetJsonResult(TeamService.AddPlayerTransact(args, this.GetSignedInUserId()));
        }

        [HttpPost(nameof(CreateTeam))]
        public IActionResult CreateTeam(CreateTeamArgs args)
        {
            return this.GetJsonResult(TeamService.CreateTeamTransact(args, this.GetSignedInUserId()));
        }

        [HttpGet(nameof(GetTeamData))]
        public IActionResult GetTeamData(int teamId, [FromHeader] string? requestToken)
        {
            return this.GetJsonResult(TeamService.GetTeamData(teamId));
        }

        [HttpGet(nameof(GetTeamDataAndStats))]
        public IActionResult GetTeamDataAndStats(int teamId, [FromHeader] string? requestToken)
        {
            return this.GetJsonResult(TeamService.GetTeamDataAndStats(teamId));
        }

        [HttpGet(nameof(GetTeamStats))]
        public IActionResult GetTeamStats(int? teamId, int? tournamentId, [FromHeader] string? requestToken)
        {
            return this.GetJsonResult(TeamService.GetTeamStats(teamId, tournamentId));
        }

        [Authorize(Roles.TeamAdmin)]
        [HttpPost(nameof(RemovePlayer))]
        public IActionResult RemovePlayer(RemovePlayerFromTeamArgs args)
        {
            return this.GetJsonResult(TeamService.RemovePlayerTransact(args, this.GetSignedInUserId()));
        }
    }
}
