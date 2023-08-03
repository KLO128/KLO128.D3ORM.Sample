

//
// generated file 16.05.2023 8:07:30
//

using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.SQLite
{
    public static class EntityPropMappings
    {
        public static Dictionary<Type, EntityMapping> Dict { get; } = new Dictionary<Type, EntityMapping>
        {

            {
                typeof(Address),
                new EntityMapping
                {
                    Entity = "Address",
                    Table = "[Address]",
                    PrimaryKeyPropName = "AddressId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "AddressId",
                            new PropertyMapping
                            {
                                Property = "AddressId",
                                DbColumn = "[AddressId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Address).GetProperty(nameof(Address.AddressId))!
                            }
                        },

                        { 
                            "Name",
                            new PropertyMapping
                            {
                                Property = "Name",
                                DbColumn = "[Name]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Address).GetProperty(nameof(Address.Name))!
                            }
                        },

                        { 
                            "State",
                            new PropertyMapping
                            {
                                Property = "State",
                                DbColumn = "[State]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Address).GetProperty(nameof(Address.State))!
                            }
                        },

                        { 
                            "Town",
                            new PropertyMapping
                            {
                                Property = "Town",
                                DbColumn = "[Town]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Address).GetProperty(nameof(Address.Town))!
                            }
                        },

                        { 
                            "Street",
                            new PropertyMapping
                            {
                                Property = "Street",
                                DbColumn = "[Street]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Address).GetProperty(nameof(Address.Street))!
                            }
                        },

                        { 
                            "HouseNumber",
                            new PropertyMapping
                            {
                                Property = "HouseNumber",
                                DbColumn = "[HouseNumber]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Address).GetProperty(nameof(Address.HouseNumber))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Address).GetProperty(nameof(Address.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Address).GetProperty(nameof(Address.ChangedBy))!
                            }
                        }
                    }
                }
            },
            {
                typeof(Match),
                new EntityMapping
                {
                    Entity = "Match",
                    Table = "[Match]",
                    PrimaryKeyPropName = "MatchId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "HomeTeamId", "Team, ->aggregated" },
                        { "AwayTeamId", "Team, ->aggregated" },
                        { "TournamentId", "Tournament, <->aggregated" },
                        { "WinnerId", "n.a., (No Aggregation)" },
                        { "RefereeId", "n.a., (No Aggregation)" },
                        { "PlayoffRoundCoupleId", "PlayoffRoundCouple, <->aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "MatchId",
                            new PropertyMapping
                            {
                                Property = "MatchId",
                                DbColumn = "[MatchId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.MatchId))!
                            }
                        },

                        { 
                            "HomeTeamId",
                            new PropertyMapping
                            {
                                Property = "HomeTeamId",
                                DbColumn = "[HomeTeamId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.HomeTeamId))!
                            }
                        },

                        { 
                            "AwayTeamId",
                            new PropertyMapping
                            {
                                Property = "AwayTeamId",
                                DbColumn = "[AwayTeamId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.AwayTeamId))!
                            }
                        },

                        { 
                            "TournamentId",
                            new PropertyMapping
                            {
                                Property = "TournamentId",
                                DbColumn = "[TournamentId]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.TournamentId))!
                            }
                        },

                        { 
                            "TournamentPhase",
                            new PropertyMapping
                            {
                                Property = "TournamentPhase",
                                DbColumn = "[TournamentPhase]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.TournamentPhase))!
                            }
                        },

                        { 
                            "WinnerId",
                            new PropertyMapping
                            {
                                Property = "WinnerId",
                                DbColumn = "[WinnerId]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.WinnerId))!
                            }
                        },

                        { 
                            "RefereeId",
                            new PropertyMapping
                            {
                                Property = "RefereeId",
                                DbColumn = "[RefereeId]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.RefereeId))!
                            }
                        },

                        { 
                            "MatchDate",
                            new PropertyMapping
                            {
                                Property = "MatchDate",
                                DbColumn = "[MatchDate]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.MatchDate))!
                            }
                        },

                        { 
                            "PlayoffRoundCoupleId",
                            new PropertyMapping
                            {
                                Property = "PlayoffRoundCoupleId",
                                DbColumn = "[PlayoffRoundCoupleId]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.PlayoffRoundCoupleId))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.ChangedBy))!
                            }
                        },

                        { 
                            "AwayTeam",
                            new PropertyMapping
                            {
                                Property = "AwayTeam",
                                DbColumn = "[AwayTeam]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.AwayTeam))!
                            }
                        },

                        { 
                            "HomeTeam",
                            new PropertyMapping
                            {
                                Property = "HomeTeam",
                                DbColumn = "[HomeTeam]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.HomeTeam))!
                            }
                        },

                        { 
                            "PlayoffRoundCouple",
                            new PropertyMapping
                            {
                                Property = "PlayoffRoundCouple",
                                DbColumn = "[PlayoffRoundCouple]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.PlayoffRoundCouple))!
                            }
                        },

                        { 
                            "Tournament",
                            new PropertyMapping
                            {
                                Property = "Tournament",
                                DbColumn = "[Tournament]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.Tournament))!
                            }
                        },

                        { 
                            "MatchSetScores",
                            new PropertyMapping
                            {
                                Property = "MatchSetScores",
                                DbColumn = "[MatchSetScores]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(Match).GetProperty(nameof(Match.MatchSetScores))!
                            }
                        }
                    }
                }
            },
            {
                typeof(MatchSetScore),
                new EntityMapping
                {
                    Entity = "MatchSetScore",
                    Table = "[MatchSetScore]",
                    PrimaryKeyPropName = "MatchSetScoreId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "MatchId", "Match, <-aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "MatchSetScoreId",
                            new PropertyMapping
                            {
                                Property = "MatchSetScoreId",
                                DbColumn = "[MatchSetScoreId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(MatchSetScore).GetProperty(nameof(MatchSetScore.MatchSetScoreId))!
                            }
                        },

                        { 
                            "MatchId",
                            new PropertyMapping
                            {
                                Property = "MatchId",
                                DbColumn = "[MatchId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(MatchSetScore).GetProperty(nameof(MatchSetScore.MatchId))!
                            }
                        },

                        { 
                            "HomeTeamScore",
                            new PropertyMapping
                            {
                                Property = "HomeTeamScore",
                                DbColumn = "[HomeTeamScore]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(MatchSetScore).GetProperty(nameof(MatchSetScore.HomeTeamScore))!
                            }
                        },

                        { 
                            "AwayTeamScore",
                            new PropertyMapping
                            {
                                Property = "AwayTeamScore",
                                DbColumn = "[AwayTeamScore]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(MatchSetScore).GetProperty(nameof(MatchSetScore.AwayTeamScore))!
                            }
                        },

                        { 
                            "SetOrder",
                            new PropertyMapping
                            {
                                Property = "SetOrder",
                                DbColumn = "[SetOrder]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(MatchSetScore).GetProperty(nameof(MatchSetScore.SetOrder))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(MatchSetScore).GetProperty(nameof(MatchSetScore.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(MatchSetScore).GetProperty(nameof(MatchSetScore.ChangedBy))!
                            }
                        }
                    }
                }
            },
            {
                typeof(PlayoffRoundCouple),
                new EntityMapping
                {
                    Entity = "PlayoffRoundCouple",
                    Table = "[PlayoffRoundCouple]",
                    PrimaryKeyPropName = "PlayoffRoundCoupleId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "TournamentTeam1Id", "TournamentTeam, ->aggregated" },
                        { "TournamentTeam2Id", "TournamentTeam, ->aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "PlayoffRoundCoupleId",
                            new PropertyMapping
                            {
                                Property = "PlayoffRoundCoupleId",
                                DbColumn = "[PlayoffRoundCoupleId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.PlayoffRoundCoupleId))!
                            }
                        },

                        { 
                            "TournamentTeam1Id",
                            new PropertyMapping
                            {
                                Property = "TournamentTeam1Id",
                                DbColumn = "[TournamentTeam1Id]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.TournamentTeam1Id))!
                            }
                        },

                        { 
                            "TournamentTeam2Id",
                            new PropertyMapping
                            {
                                Property = "TournamentTeam2Id",
                                DbColumn = "[TournamentTeam2Id]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.TournamentTeam2Id))!
                            }
                        },

                        { 
                            "PlayoffRound",
                            new PropertyMapping
                            {
                                Property = "PlayoffRound",
                                DbColumn = "[PlayoffRound]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.PlayoffRound))!
                            }
                        },

                        { 
                            "Team1Wins",
                            new PropertyMapping
                            {
                                Property = "Team1Wins",
                                DbColumn = "[Team1Wins]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.Team1Wins))!
                            }
                        },

                        { 
                            "Team2Wins",
                            new PropertyMapping
                            {
                                Property = "Team2Wins",
                                DbColumn = "[Team2Wins]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.Team2Wins))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.ChangedBy))!
                            }
                        },

                        { 
                            "TournamentTeam1",
                            new PropertyMapping
                            {
                                Property = "TournamentTeam1",
                                DbColumn = "[TournamentTeam1]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.TournamentTeam1))!
                            }
                        },

                        { 
                            "TournamentTeam2",
                            new PropertyMapping
                            {
                                Property = "TournamentTeam2",
                                DbColumn = "[TournamentTeam2]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.TournamentTeam2))!
                            }
                        },

                        { 
                            "Matches",
                            new PropertyMapping
                            {
                                Property = "Matches",
                                DbColumn = "[Matches]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(PlayoffRoundCouple).GetProperty(nameof(PlayoffRoundCouple.Matches))!
                            }
                        }
                    }
                }
            },
            {
                typeof(Role),
                new EntityMapping
                {
                    Entity = "Role",
                    Table = "[Role]",
                    PrimaryKeyPropName = "RoleId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "RoleId",
                            new PropertyMapping
                            {
                                Property = "RoleId",
                                DbColumn = "[RoleId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Role).GetProperty(nameof(Role.RoleId))!
                            }
                        },

                        { 
                            "Name",
                            new PropertyMapping
                            {
                                Property = "Name",
                                DbColumn = "[Name]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Role).GetProperty(nameof(Role.Name))!
                            }
                        }
                    }
                }
            },
            {
                typeof(Team),
                new EntityMapping
                {
                    Entity = "Team",
                    Table = "[Team]",
                    PrimaryKeyPropName = "TeamId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "TeamId",
                            new PropertyMapping
                            {
                                Property = "TeamId",
                                DbColumn = "[TeamId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Team).GetProperty(nameof(Team.TeamId))!
                            }
                        },

                        { 
                            "Name",
                            new PropertyMapping
                            {
                                Property = "Name",
                                DbColumn = "[Name]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Team).GetProperty(nameof(Team.Name))!
                            }
                        },

                        { 
                            "Logo",
                            new PropertyMapping
                            {
                                Property = "Logo",
                                DbColumn = "[Logo]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Team).GetProperty(nameof(Team.Logo))!
                            }
                        },

                        { 
                            "RegistrationDate",
                            new PropertyMapping
                            {
                                Property = "RegistrationDate",
                                DbColumn = "[RegistrationDate]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Team).GetProperty(nameof(Team.RegistrationDate))!
                            }
                        },

                        { 
                            "IsActive",
                            new PropertyMapping
                            {
                                Property = "IsActive",
                                DbColumn = "[IsActive]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Team).GetProperty(nameof(Team.IsActive))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Team).GetProperty(nameof(Team.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Team).GetProperty(nameof(Team.ChangedBy))!
                            }
                        },

                        { 
                            "TeamPlayers",
                            new PropertyMapping
                            {
                                Property = "TeamPlayers",
                                DbColumn = "[TeamPlayers]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(Team).GetProperty(nameof(Team.TeamPlayers))!
                            }
                        },

                        { 
                            "TournamentTeams",
                            new PropertyMapping
                            {
                                Property = "TournamentTeams",
                                DbColumn = "[TournamentTeams]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(Team).GetProperty(nameof(Team.TournamentTeams))!
                            }
                        }
                    }
                }
            },
            {
                typeof(TeamPlayer),
                new EntityMapping
                {
                    Entity = "TeamPlayer",
                    Table = "[TeamPlayer]",
                    PrimaryKeyPropName = "TeamPlayerId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "TeamId", "Team, <-aggregated" },
                        { "PlayerId", "User, ->aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "TeamPlayerId",
                            new PropertyMapping
                            {
                                Property = "TeamPlayerId",
                                DbColumn = "[TeamPlayerId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TeamPlayer).GetProperty(nameof(TeamPlayer.TeamPlayerId))!
                            }
                        },

                        { 
                            "TeamId",
                            new PropertyMapping
                            {
                                Property = "TeamId",
                                DbColumn = "[TeamId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TeamPlayer).GetProperty(nameof(TeamPlayer.TeamId))!
                            }
                        },

                        { 
                            "PlayerId",
                            new PropertyMapping
                            {
                                Property = "PlayerId",
                                DbColumn = "[PlayerId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TeamPlayer).GetProperty(nameof(TeamPlayer.PlayerId))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TeamPlayer).GetProperty(nameof(TeamPlayer.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TeamPlayer).GetProperty(nameof(TeamPlayer.ChangedBy))!
                            }
                        },

                        { 
                            "Player",
                            new PropertyMapping
                            {
                                Property = "Player",
                                DbColumn = "[Player]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(TeamPlayer).GetProperty(nameof(TeamPlayer.Player))!
                            }
                        }
                    }
                }
            },
            {
                typeof(Tournament),
                new EntityMapping
                {
                    Entity = "Tournament",
                    Table = "[Tournament]",
                    PrimaryKeyPropName = "TournamentId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "TourSerieId", "TourSerie, <->aggregated" },
                        { "AddressId", "Address, ->aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "TournamentId",
                            new PropertyMapping
                            {
                                Property = "TournamentId",
                                DbColumn = "[TournamentId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.TournamentId))!
                            }
                        },

                        { 
                            "TourSerieId",
                            new PropertyMapping
                            {
                                Property = "TourSerieId",
                                DbColumn = "[TourSerieId]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.TourSerieId))!
                            }
                        },

                        { 
                            "AddressId",
                            new PropertyMapping
                            {
                                Property = "AddressId",
                                DbColumn = "[AddressId]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.AddressId))!
                            }
                        },

                        { 
                            "Name",
                            new PropertyMapping
                            {
                                Property = "Name",
                                DbColumn = "[Name]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.Name))!
                            }
                        },

                        { 
                            "StartDate",
                            new PropertyMapping
                            {
                                Property = "StartDate",
                                DbColumn = "[StartDate]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.StartDate))!
                            }
                        },

                        { 
                            "EndDate",
                            new PropertyMapping
                            {
                                Property = "EndDate",
                                DbColumn = "[EndDate]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.EndDate))!
                            }
                        },

                        { 
                            "EntryFee",
                            new PropertyMapping
                            {
                                Property = "EntryFee",
                                DbColumn = "[EntryFee]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.EntryFee))!
                            }
                        },

                        { 
                            "MaxNumOfTeams",
                            new PropertyMapping
                            {
                                Property = "MaxNumOfTeams",
                                DbColumn = "[MaxNumOfTeams]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.MaxNumOfTeams))!
                            }
                        },

                        { 
                            "Note",
                            new PropertyMapping
                            {
                                Property = "Note",
                                DbColumn = "[Note]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.Note))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.ChangedBy))!
                            }
                        },

                        { 
                            "Address",
                            new PropertyMapping
                            {
                                Property = "Address",
                                DbColumn = "[Address]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.Address))!
                            }
                        },

                        { 
                            "TourSerie",
                            new PropertyMapping
                            {
                                Property = "TourSerie",
                                DbColumn = "[TourSerie]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.TourSerie))!
                            }
                        },

                        { 
                            "Matches",
                            new PropertyMapping
                            {
                                Property = "Matches",
                                DbColumn = "[Matches]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.Matches))!
                            }
                        },

                        { 
                            "TournamentTeams",
                            new PropertyMapping
                            {
                                Property = "TournamentTeams",
                                DbColumn = "[TournamentTeams]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(Tournament).GetProperty(nameof(Tournament.TournamentTeams))!
                            }
                        }
                    }
                }
            },
            {
                typeof(TournamentPlayerStat),
                new EntityMapping
                {
                    Entity = "TournamentPlayerStat",
                    Table = "[TournamentPlayerStat]",
                    PrimaryKeyPropName = "TournamentPlayerStatId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "TournamentId", "Tournament, <->aggregated" },
                        { "PlayerId", "User, ->aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "TournamentPlayerStatId",
                            new PropertyMapping
                            {
                                Property = "TournamentPlayerStatId",
                                DbColumn = "[TournamentPlayerStatId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.TournamentPlayerStatId))!
                            }
                        },

                        { 
                            "TournamentId",
                            new PropertyMapping
                            {
                                Property = "TournamentId",
                                DbColumn = "[TournamentId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.TournamentId))!
                            }
                        },

                        { 
                            "PlayerId",
                            new PropertyMapping
                            {
                                Property = "PlayerId",
                                DbColumn = "[PlayerId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.PlayerId))!
                            }
                        },

                        { 
                            "TourPoints",
                            new PropertyMapping
                            {
                                Property = "TourPoints",
                                DbColumn = "[TourPoints]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.TourPoints))!
                            }
                        },

                        { 
                            "AttackPoints",
                            new PropertyMapping
                            {
                                Property = "AttackPoints",
                                DbColumn = "[AttackPoints]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.AttackPoints))!
                            }
                        },

                        { 
                            "AttackPercentage",
                            new PropertyMapping
                            {
                                Property = "AttackPercentage",
                                DbColumn = "[AttackPercentage]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.AttackPercentage))!
                            }
                        },

                        { 
                            "ServicePoints",
                            new PropertyMapping
                            {
                                Property = "ServicePoints",
                                DbColumn = "[ServicePoints]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.ServicePoints))!
                            }
                        },

                        { 
                            "ServicePercentage",
                            new PropertyMapping
                            {
                                Property = "ServicePercentage",
                                DbColumn = "[ServicePercentage]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.ServicePercentage))!
                            }
                        },

                        { 
                            "UnforcedErrors",
                            new PropertyMapping
                            {
                                Property = "UnforcedErrors",
                                DbColumn = "[UnforcedErrors]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.UnforcedErrors))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.ChangedBy))!
                            }
                        },

                        { 
                            "Player",
                            new PropertyMapping
                            {
                                Property = "Player",
                                DbColumn = "[Player]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.Player))!
                            }
                        },

                        { 
                            "Tournament",
                            new PropertyMapping
                            {
                                Property = "Tournament",
                                DbColumn = "[Tournament]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(TournamentPlayerStat).GetProperty(nameof(TournamentPlayerStat.Tournament))!
                            }
                        }
                    }
                }
            },
            {
                typeof(TournamentTeam),
                new EntityMapping
                {
                    Entity = "TournamentTeam",
                    Table = "[TournamentTeam]",
                    PrimaryKeyPropName = "TournamentTeamId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "TournamentId", "Tournament, <->aggregated" },
                        { "TeamId", "Team, <->aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "TournamentTeamId",
                            new PropertyMapping
                            {
                                Property = "TournamentTeamId",
                                DbColumn = "[TournamentTeamId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.TournamentTeamId))!
                            }
                        },

                        { 
                            "TournamentId",
                            new PropertyMapping
                            {
                                Property = "TournamentId",
                                DbColumn = "[TournamentId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.TournamentId))!
                            }
                        },

                        { 
                            "TeamId",
                            new PropertyMapping
                            {
                                Property = "TeamId",
                                DbColumn = "[TeamId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.TeamId))!
                            }
                        },

                        { 
                            "BasicGroupName",
                            new PropertyMapping
                            {
                                Property = "BasicGroupName",
                                DbColumn = "[BasicGroupName]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.BasicGroupName))!
                            }
                        },

                        { 
                            "RegistrationDate",
                            new PropertyMapping
                            {
                                Property = "RegistrationDate",
                                DbColumn = "[RegistrationDate]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.RegistrationDate))!
                            }
                        },

                        { 
                            "EntryFeePaid",
                            new PropertyMapping
                            {
                                Property = "EntryFeePaid",
                                DbColumn = "[EntryFeePaid]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.EntryFeePaid))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.ChangedBy))!
                            }
                        },

                        { 
                            "Team",
                            new PropertyMapping
                            {
                                Property = "Team",
                                DbColumn = "[Team]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.Team))!
                            }
                        },

                        { 
                            "Tournament",
                            new PropertyMapping
                            {
                                Property = "Tournament",
                                DbColumn = "[Tournament]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.Tournament))!
                            }
                        },

                        { 
                            "TournamentTeamStats",
                            new PropertyMapping
                            {
                                Property = "TournamentTeamStats",
                                DbColumn = "[TournamentTeamStats]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(TournamentTeam).GetProperty(nameof(TournamentTeam.TournamentTeamStats))!
                            }
                        }
                    }
                }
            },
            {
                typeof(TournamentTeamStat),
                new EntityMapping
                {
                    Entity = "TournamentTeamStat",
                    Table = "[TournamentTeamStat]",
                    PrimaryKeyPropName = "TournamentTeamStatId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "TournamentTeamId", "TournamentTeam, <-aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "TournamentTeamStatId",
                            new PropertyMapping
                            {
                                Property = "TournamentTeamStatId",
                                DbColumn = "[TournamentTeamStatId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.TournamentTeamStatId))!
                            }
                        },

                        { 
                            "TournamentTeamId",
                            new PropertyMapping
                            {
                                Property = "TournamentTeamId",
                                DbColumn = "[TournamentTeamId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.TournamentTeamId))!
                            }
                        },

                        { 
                            "TournamentPhase",
                            new PropertyMapping
                            {
                                Property = "TournamentPhase",
                                DbColumn = "[TournamentPhase]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.TournamentPhase))!
                            }
                        },

                        { 
                            "PhasePoints",
                            new PropertyMapping
                            {
                                Property = "PhasePoints",
                                DbColumn = "[PhasePoints]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.PhasePoints))!
                            }
                        },

                        { 
                            "Wins",
                            new PropertyMapping
                            {
                                Property = "Wins",
                                DbColumn = "[Wins]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.Wins))!
                            }
                        },

                        { 
                            "Losts",
                            new PropertyMapping
                            {
                                Property = "Losts",
                                DbColumn = "[Losts]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.Losts))!
                            }
                        },

                        { 
                            "Ties",
                            new PropertyMapping
                            {
                                Property = "Ties",
                                DbColumn = "[Ties]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.Ties))!
                            }
                        },

                        { 
                            "SetsWon",
                            new PropertyMapping
                            {
                                Property = "SetsWon",
                                DbColumn = "[SetsWon]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.SetsWon))!
                            }
                        },

                        { 
                            "SetsLost",
                            new PropertyMapping
                            {
                                Property = "SetsLost",
                                DbColumn = "[SetsLost]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.SetsLost))!
                            }
                        },

                        { 
                            "ScorePlus",
                            new PropertyMapping
                            {
                                Property = "ScorePlus",
                                DbColumn = "[ScorePlus]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.ScorePlus))!
                            }
                        },

                        { 
                            "ScoreMinus",
                            new PropertyMapping
                            {
                                Property = "ScoreMinus",
                                DbColumn = "[ScoreMinus]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.ScoreMinus))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TournamentTeamStat).GetProperty(nameof(TournamentTeamStat.ChangedBy))!
                            }
                        }
                    }
                }
            },
            {
                typeof(TourSerie),
                new EntityMapping
                {
                    Entity = "TourSerie",
                    Table = "[TourSerie]",
                    PrimaryKeyPropName = "TourSerieId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "TourSerieId",
                            new PropertyMapping
                            {
                                Property = "TourSerieId",
                                DbColumn = "[TourSerieId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TourSerie).GetProperty(nameof(TourSerie.TourSerieId))!
                            }
                        },

                        { 
                            "Name",
                            new PropertyMapping
                            {
                                Property = "Name",
                                DbColumn = "[Name]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TourSerie).GetProperty(nameof(TourSerie.Name))!
                            }
                        },

                        { 
                            "StartDate",
                            new PropertyMapping
                            {
                                Property = "StartDate",
                                DbColumn = "[StartDate]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TourSerie).GetProperty(nameof(TourSerie.StartDate))!
                            }
                        },

                        { 
                            "EndDate",
                            new PropertyMapping
                            {
                                Property = "EndDate",
                                DbColumn = "[EndDate]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TourSerie).GetProperty(nameof(TourSerie.EndDate))!
                            }
                        },

                        { 
                            "Category",
                            new PropertyMapping
                            {
                                Property = "Category",
                                DbColumn = "[Category]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TourSerie).GetProperty(nameof(TourSerie.Category))!
                            }
                        },

                        { 
                            "Note",
                            new PropertyMapping
                            {
                                Property = "Note",
                                DbColumn = "[Note]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TourSerie).GetProperty(nameof(TourSerie.Note))!
                            }
                        },

                        { 
                            "LastChange",
                            new PropertyMapping
                            {
                                Property = "LastChange",
                                DbColumn = "[LastChange]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TourSerie).GetProperty(nameof(TourSerie.LastChange))!
                            }
                        },

                        { 
                            "ChangedBy",
                            new PropertyMapping
                            {
                                Property = "ChangedBy",
                                DbColumn = "[ChangedBy]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(TourSerie).GetProperty(nameof(TourSerie.ChangedBy))!
                            }
                        },

                        { 
                            "Tournaments",
                            new PropertyMapping
                            {
                                Property = "Tournaments",
                                DbColumn = "[Tournaments]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(TourSerie).GetProperty(nameof(TourSerie.Tournaments))!
                            }
                        }
                    }
                }
            },
            {
                typeof(User),
                new EntityMapping
                {
                    Entity = "User",
                    Table = "[User]",
                    PrimaryKeyPropName = "UserId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "UserId",
                            new PropertyMapping
                            {
                                Property = "UserId",
                                DbColumn = "[UserId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.UserId))!
                            }
                        },

                        { 
                            "Email",
                            new PropertyMapping
                            {
                                Property = "Email",
                                DbColumn = "[Email]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.Email))!
                            }
                        },

                        { 
                            "EmailConfirmed",
                            new PropertyMapping
                            {
                                Property = "EmailConfirmed",
                                DbColumn = "[EmailConfirmed]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.EmailConfirmed))!
                            }
                        },

                        { 
                            "PasswordHash",
                            new PropertyMapping
                            {
                                Property = "PasswordHash",
                                DbColumn = "[PasswordHash]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.PasswordHash))!
                            }
                        },

                        { 
                            "SecurityStamp",
                            new PropertyMapping
                            {
                                Property = "SecurityStamp",
                                DbColumn = "[SecurityStamp]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.SecurityStamp))!
                            }
                        },

                        { 
                            "PhoneNumber",
                            new PropertyMapping
                            {
                                Property = "PhoneNumber",
                                DbColumn = "[PhoneNumber]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.PhoneNumber))!
                            }
                        },

                        { 
                            "PhoneNumberConfirmed",
                            new PropertyMapping
                            {
                                Property = "PhoneNumberConfirmed",
                                DbColumn = "[PhoneNumberConfirmed]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.PhoneNumberConfirmed))!
                            }
                        },

                        { 
                            "TwoFactorEnabled",
                            new PropertyMapping
                            {
                                Property = "TwoFactorEnabled",
                                DbColumn = "[TwoFactorEnabled]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.TwoFactorEnabled))!
                            }
                        },

                        { 
                            "LockoutEndDateUtc",
                            new PropertyMapping
                            {
                                Property = "LockoutEndDateUtc",
                                DbColumn = "[LockoutEndDateUtc]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.LockoutEndDateUtc))!
                            }
                        },

                        { 
                            "LockoutEnabled",
                            new PropertyMapping
                            {
                                Property = "LockoutEnabled",
                                DbColumn = "[LockoutEnabled]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.LockoutEnabled))!
                            }
                        },

                        { 
                            "AccessFailedCount",
                            new PropertyMapping
                            {
                                Property = "AccessFailedCount",
                                DbColumn = "[AccessFailedCount]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.AccessFailedCount))!
                            }
                        },

                        { 
                            "UserName",
                            new PropertyMapping
                            {
                                Property = "UserName",
                                DbColumn = "[UserName]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.UserName))!
                            }
                        },

                        { 
                            "FirstName",
                            new PropertyMapping
                            {
                                Property = "FirstName",
                                DbColumn = "[FirstName]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.FirstName))!
                            }
                        },

                        { 
                            "LastName",
                            new PropertyMapping
                            {
                                Property = "LastName",
                                DbColumn = "[LastName]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.LastName))!
                            }
                        },

                        { 
                            "Gender",
                            new PropertyMapping
                            {
                                Property = "Gender",
                                DbColumn = "[Gender]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.Gender))!
                            }
                        },

                        { 
                            "DateOfBirth",
                            new PropertyMapping
                            {
                                Property = "DateOfBirth",
                                DbColumn = "[DateOfBirth]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.DateOfBirth))!
                            }
                        },

                        { 
                            "RegistrationDate",
                            new PropertyMapping
                            {
                                Property = "RegistrationDate",
                                DbColumn = "[RegistrationDate]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.RegistrationDate))!
                            }
                        },

                        { 
                            "ExternalLogin",
                            new PropertyMapping
                            {
                                Property = "ExternalLogin",
                                DbColumn = "[ExternalLogin]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.ExternalLogin))!
                            }
                        },

                        { 
                            "RegistrationGuid",
                            new PropertyMapping
                            {
                                Property = "RegistrationGuid",
                                DbColumn = "[RegistrationGuid]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.RegistrationGuid))!
                            }
                        },

                        { 
                            "GuidexpirationDate",
                            new PropertyMapping
                            {
                                Property = "GuidexpirationDate",
                                DbColumn = "[GuidexpirationDate]",
                                IsPrimaryKey = false,
                                IsNullable = true,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.GuidexpirationDate))!
                            }
                        },

                        { 
                            "TournamentPlayerStats",
                            new PropertyMapping
                            {
                                Property = "TournamentPlayerStats",
                                DbColumn = "[TournamentPlayerStats]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.TournamentPlayerStats))!
                            }
                        },

                        { 
                            "UserClaims",
                            new PropertyMapping
                            {
                                Property = "UserClaims",
                                DbColumn = "[UserClaims]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.UserClaims))!
                            }
                        },

                        { 
                            "UserLogins",
                            new PropertyMapping
                            {
                                Property = "UserLogins",
                                DbColumn = "[UserLogins]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.UserLogins))!
                            }
                        },

                        { 
                            "UserRoles",
                            new PropertyMapping
                            {
                                Property = "UserRoles",
                                DbColumn = "[UserRoles]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = true,
                                IsComplexType = true,
                                PropertyInfo = typeof(User).GetProperty(nameof(User.UserRoles))!
                            }
                        }
                    }
                }
            },
            {
                typeof(UserClaim),
                new EntityMapping
                {
                    Entity = "UserClaim",
                    Table = "[UserClaim]",
                    PrimaryKeyPropName = "UserClaimId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "UserId", "User, <-aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "UserClaimId",
                            new PropertyMapping
                            {
                                Property = "UserClaimId",
                                DbColumn = "[UserClaimId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserClaim).GetProperty(nameof(UserClaim.UserClaimId))!
                            }
                        },

                        { 
                            "UserId",
                            new PropertyMapping
                            {
                                Property = "UserId",
                                DbColumn = "[UserId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserClaim).GetProperty(nameof(UserClaim.UserId))!
                            }
                        },

                        { 
                            "ClaimType",
                            new PropertyMapping
                            {
                                Property = "ClaimType",
                                DbColumn = "[ClaimType]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserClaim).GetProperty(nameof(UserClaim.ClaimType))!
                            }
                        },

                        { 
                            "ClaimValue",
                            new PropertyMapping
                            {
                                Property = "ClaimValue",
                                DbColumn = "[ClaimValue]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserClaim).GetProperty(nameof(UserClaim.ClaimValue))!
                            }
                        }
                    }
                }
            },
            {
                typeof(UserLogin),
                new EntityMapping
                {
                    Entity = "UserLogin",
                    Table = "[UserLogin]",
                    PrimaryKeyPropName = "",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "UserId", "User, <-aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "LoginProvider",
                            new PropertyMapping
                            {
                                Property = "LoginProvider",
                                DbColumn = "[LoginProvider]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserLogin).GetProperty(nameof(UserLogin.LoginProvider))!
                            }
                        },

                        { 
                            "ProviderKey",
                            new PropertyMapping
                            {
                                Property = "ProviderKey",
                                DbColumn = "[ProviderKey]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserLogin).GetProperty(nameof(UserLogin.ProviderKey))!
                            }
                        },

                        { 
                            "UserId",
                            new PropertyMapping
                            {
                                Property = "UserId",
                                DbColumn = "[UserId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserLogin).GetProperty(nameof(UserLogin.UserId))!
                            }
                        }
                    }
                }
            },
            {
                typeof(UserRole),
                new EntityMapping
                {
                    Entity = "UserRole",
                    Table = "[UserRole]",
                    PrimaryKeyPropName = "UserRoleId",
                    ForeignKeys = new Dictionary<string, string> // Source Property ID -> Target Entity
                    {

                        { "UserId", "User, <-aggregated" },
                        { "RoleId", "Role, ->aggregated" }
                    },
                    Props = new Dictionary<string, PropertyMapping>
                    {


                        { 
                            "UserRoleId",
                            new PropertyMapping
                            {
                                Property = "UserRoleId",
                                DbColumn = "[UserRoleId]",
                                IsPrimaryKey = true,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserRole).GetProperty(nameof(UserRole.UserRoleId))!
                            }
                        },

                        { 
                            "UserId",
                            new PropertyMapping
                            {
                                Property = "UserId",
                                DbColumn = "[UserId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserRole).GetProperty(nameof(UserRole.UserId))!
                            }
                        },

                        { 
                            "RoleId",
                            new PropertyMapping
                            {
                                Property = "RoleId",
                                DbColumn = "[RoleId]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserRole).GetProperty(nameof(UserRole.RoleId))!
                            }
                        },

                        { 
                            "IsActive",
                            new PropertyMapping
                            {
                                Property = "IsActive",
                                DbColumn = "[IsActive]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserRole).GetProperty(nameof(UserRole.IsActive))!
                            }
                        },

                        { 
                            "TeamIdOrDefault",
                            new PropertyMapping
                            {
                                Property = "TeamIdOrDefault",
                                DbColumn = "[TeamIdOrDefault]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = false,
                                PropertyInfo = typeof(UserRole).GetProperty(nameof(UserRole.TeamIdOrDefault))!
                            }
                        },

                        { 
                            "Role",
                            new PropertyMapping
                            {
                                Property = "Role",
                                DbColumn = "[Role]",
                                IsPrimaryKey = false,
                                IsNullable = false,
                                IsEnumerable = false,
                                IsComplexType = true,
                                PropertyInfo = typeof(UserRole).GetProperty(nameof(UserRole.Role))!
                            }
                        }
                    }
                }
            }
        };
    }
}


