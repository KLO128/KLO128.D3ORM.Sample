using KLO128.D3ORM.Sample.Application.Contracts.Services;
using KLO128.D3ORM.Sample.Application.Web;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.Sample.Domain.Repositories;
using KLO128.D3ORM.Sample.Domain.Services;
using KLO128.D3ORM.Sample.Domain.Services.Impl;
using KLO128.D3ORM.Sample.Domain.Shared;
using KLO128.D3ORM.Sample.Infra.D3ORM;
using KLO128.D3ORM.Sample.Infra.D3ORM.MySQL;
using KLO128.D3ORM.Sample.Infra.D3ORM.Repositories;
using KLO128.D3ORM.Sample.Presentation.WebApi.Extensions;
using Microsoft.Extensions.Localization;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDbConnection, MySqlConnection>(x => new MySqlConnection(builder.Configuration.GetConnectionString(Constants.AppSettingKeys.DefaultConnectionString)));
builder.Services.AddScoped<ID3ContextFactory, MySQLD3ContextFactory>();
builder.Services.AddScoped(x => x.GetService<ID3ContextFactory>()!.Create());

builder.Services.AddScoped<IQueryContainer, QueryContainer>();
builder.Services.AddScoped<ITournamentRepository, D3TournamentRepository>();
builder.Services.AddScoped<ITournamentTeamRepository, D3TournamentTeamRepository>();
builder.Services.AddScoped<ITeamRepository, D3TeamRepository>();
builder.Services.AddScoped<IMatchRepository, D3MatchRepository>();
builder.Services.AddScoped<IMatchSetScoreRepository, D3MatchSetScoreRepository>();
builder.Services.AddScoped<ITourSerieRepository, D3TourSerieRepository>();
builder.Services.AddScoped<ITeamPlayerRepository, D3TeamPlayerRepository>();
builder.Services.AddScoped<IUserRepository, D3UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, D3UserRoleRepository>();
builder.Services.AddScoped<ITournamentPlayerStatRepository, D3TournamentPlayerStatRepository>();
builder.Services.AddScoped<ITournamentTeamStatRepository, D3TournamentTeamStatRepository>();
builder.Services.AddScoped<IAddressRepository, D3AddressRepository>();
builder.Services.AddScoped<IPlayoffRoundCoupleRepository, D3PlayoffRoundCoupleRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IMatchDomainService, MatchDomainService>();
builder.Services.AddScoped<ITeamDomainService, TeamDomainService>();
builder.Services.AddScoped<ITournamentDomainService, TournamentDomainService>();
builder.Services.AddScoped<ITournamentPlayerStatDomainService, TournamentPlayerStatDomainService>();
builder.Services.AddScoped<IUserDomainService, UserDomainService>();

builder.Services.AddScoped<IAccountService, AccountWebService>();
builder.Services.AddScoped<IMatchService, MatchWebService>();
builder.Services.AddScoped<ITeamService, TeamWebService>();
builder.Services.AddScoped<ITournamentService, TournamentWebService>();
builder.Services.AddScoped<IPlayerService, PlayerWebService>();

builder.Services.AddScoped<IStringLocalizer, MyLocalizer>(x => new MyLocalizer(Translations.ResourceManager));

//

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();