

//
// generated file 16.05.2023 8:07:34
//

using KLO128.D3ORM.Common.Models;
using KLO128.D3ORM.Sample.Domain.Models.Entities;

namespace KLO128.D3ORM.Sample.Infra.D3ORM.MySQL
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
                    Table = "`address`",
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
                                DbColumn = "`address_id`",
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
                                DbColumn = "`name`",
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
                                DbColumn = "`state`",
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
                                DbColumn = "`town`",
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
                                DbColumn = "`street`",
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
                                DbColumn = "`house_number`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                    Table = "`match`",
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
                                DbColumn = "`match_id`",
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
                                DbColumn = "`home_team_id`",
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
                                DbColumn = "`away_team_id`",
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
                                DbColumn = "`tournament_id`",
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
                                DbColumn = "`tournament_phase`",
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
                                DbColumn = "`winner_id`",
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
                                DbColumn = "`referee_id`",
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
                                DbColumn = "`match_date`",
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
                                DbColumn = "`playoff_round_couple_id`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                                DbColumn = "`away_team`",
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
                                DbColumn = "`home_team`",
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
                                DbColumn = "`playoff_round_couple`",
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
                                DbColumn = "`tournament`",
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
                                DbColumn = "`match_set_scores`",
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
                    Table = "`match_set_score`",
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
                                DbColumn = "`match_set_score_id`",
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
                                DbColumn = "`match_id`",
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
                                DbColumn = "`home_team_score`",
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
                                DbColumn = "`away_team_score`",
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
                                DbColumn = "`set_order`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                    Table = "`playoff_round_couple`",
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
                                DbColumn = "`playoff_round_couple_id`",
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
                                DbColumn = "`tournament_team1_id`",
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
                                DbColumn = "`tournament_team2_id`",
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
                                DbColumn = "`playoff_round`",
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
                                DbColumn = "`team1_wins`",
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
                                DbColumn = "`team2_wins`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                                DbColumn = "`tournament_team1`",
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
                                DbColumn = "`tournament_team2`",
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
                                DbColumn = "`matches`",
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
                    Table = "`role`",
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
                                DbColumn = "`role_id`",
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
                                DbColumn = "`name`",
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
                    Table = "`team`",
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
                                DbColumn = "`team_id`",
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
                                DbColumn = "`name`",
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
                                DbColumn = "`logo`",
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
                                DbColumn = "`registration_date`",
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
                                DbColumn = "`is_active`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                                DbColumn = "`team_players`",
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
                                DbColumn = "`tournament_teams`",
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
                    Table = "`team_player`",
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
                                DbColumn = "`team_player_id`",
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
                                DbColumn = "`team_id`",
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
                                DbColumn = "`player_id`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                                DbColumn = "`player`",
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
                    Table = "`tournament`",
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
                                DbColumn = "`tournament_id`",
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
                                DbColumn = "`tour_serie_id`",
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
                                DbColumn = "`address_id`",
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
                                DbColumn = "`name`",
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
                                DbColumn = "`start_date`",
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
                                DbColumn = "`end_date`",
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
                                DbColumn = "`entry_fee`",
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
                                DbColumn = "`max_num_of_teams`",
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
                                DbColumn = "`note`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                                DbColumn = "`address`",
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
                                DbColumn = "`tour_serie`",
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
                                DbColumn = "`matches`",
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
                                DbColumn = "`tournament_teams`",
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
                    Table = "`tournament_player_stat`",
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
                                DbColumn = "`tournament_player_stat_id`",
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
                                DbColumn = "`tournament_id`",
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
                                DbColumn = "`player_id`",
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
                                DbColumn = "`tour_points`",
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
                                DbColumn = "`attack_points`",
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
                                DbColumn = "`attack_percentage`",
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
                                DbColumn = "`service_points`",
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
                                DbColumn = "`service_percentage`",
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
                                DbColumn = "`unforced_errors`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                                DbColumn = "`player`",
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
                                DbColumn = "`tournament`",
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
                    Table = "`tournament_team`",
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
                                DbColumn = "`tournament_team_id`",
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
                                DbColumn = "`tournament_id`",
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
                                DbColumn = "`team_id`",
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
                                DbColumn = "`basic_group_name`",
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
                                DbColumn = "`registration_date`",
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
                                DbColumn = "`entry_fee_paid`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                                DbColumn = "`team`",
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
                                DbColumn = "`tournament`",
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
                                DbColumn = "`tournament_team_stats`",
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
                    Table = "`tournament_team_stat`",
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
                                DbColumn = "`tournament_team_stat_id`",
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
                                DbColumn = "`tournament_team_id`",
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
                                DbColumn = "`tournament_phase`",
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
                                DbColumn = "`phase_points`",
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
                                DbColumn = "`wins`",
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
                                DbColumn = "`losts`",
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
                                DbColumn = "`ties`",
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
                                DbColumn = "`sets_won`",
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
                                DbColumn = "`sets_lost`",
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
                                DbColumn = "`score_plus`",
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
                                DbColumn = "`score_minus`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                    Table = "`tour_serie`",
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
                                DbColumn = "`tour_serie_id`",
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
                                DbColumn = "`name`",
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
                                DbColumn = "`start_date`",
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
                                DbColumn = "`end_date`",
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
                                DbColumn = "`category`",
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
                                DbColumn = "`note`",
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
                                DbColumn = "`last_change`",
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
                                DbColumn = "`changed_by`",
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
                                DbColumn = "`tournaments`",
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
                    Table = "`user`",
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
                                DbColumn = "`user_id`",
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
                                DbColumn = "`email`",
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
                                DbColumn = "`email_confirmed`",
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
                                DbColumn = "`password_hash`",
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
                                DbColumn = "`security_stamp`",
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
                                DbColumn = "`phone_number`",
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
                                DbColumn = "`phone_number_confirmed`",
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
                                DbColumn = "`two_factor_enabled`",
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
                                DbColumn = "`lockout_end_date_utc`",
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
                                DbColumn = "`lockout_enabled`",
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
                                DbColumn = "`access_failed_count`",
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
                                DbColumn = "`user_name`",
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
                                DbColumn = "`first_name`",
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
                                DbColumn = "`last_name`",
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
                                DbColumn = "`gender`",
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
                                DbColumn = "`date_of_birth`",
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
                                DbColumn = "`registration_date`",
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
                                DbColumn = "`external_login`",
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
                                DbColumn = "`registration_guid`",
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
                                DbColumn = "`guidexpiration_date`",
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
                                DbColumn = "`tournament_player_stats`",
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
                                DbColumn = "`user_claims`",
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
                                DbColumn = "`user_logins`",
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
                                DbColumn = "`user_roles`",
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
                    Table = "`user_claim`",
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
                                DbColumn = "`user_claim_id`",
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
                                DbColumn = "`user_id`",
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
                                DbColumn = "`claim_type`",
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
                                DbColumn = "`claim_value`",
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
                    Table = "`user_login`",
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
                                DbColumn = "`login_provider`",
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
                                DbColumn = "`provider_key`",
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
                                DbColumn = "`user_id`",
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
                    Table = "`user_role`",
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
                                DbColumn = "`user_role_id`",
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
                                DbColumn = "`user_id`",
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
                                DbColumn = "`role_id`",
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
                                DbColumn = "`is_active`",
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
                                DbColumn = "`team_id_or_default`",
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
                                DbColumn = "`role`",
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


