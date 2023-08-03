using KLO128.D3ORM.Sample.Domain.Shared.Models;

namespace KLO128.D3ORM.Sample.Domain.Shared
{
    public static class Errors
    {
        public static Error GetUnauthorizedAccess
        {
            get
            {
                return new Error
                {
                    ErrArgs = new string[] { },
                    ErrCode = nameof(Translations.err401)
                };
            }
        }

        public static Error GetPlayerAlreadyInTeam(string playerIdef, string teamName)
        {
            return new Error
            {
                ErrArgs = new string[] { playerIdef, teamName },
                ErrCode = nameof(Translations.warn001)
            };
        }

        public static Error GetPlayerNotExists(string playerIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { playerIdef },
                ErrCode = nameof(Translations.err002)
            };
        }

        public static Error GetTeamAlreadyExists(string teamName)
        {
            return new Error
            {
                ErrArgs = new string[] { teamName },
                ErrCode = nameof(Translations.err003)
            };
        }

        public static Error GetTeamNotFound(string teamName)
        {
            return new Error
            {
                ErrArgs = new string[] { teamName },
                ErrCode = nameof(Translations.err004)
            };
        }

        public static Error GetPlayerNotFoundInTeam(string playerIdef, string teamName)
        {
            return new Error
            {
                ErrArgs = new string[] { playerIdef, teamName },
                ErrCode = nameof(Translations.err005)
            };
        }

        public static Error GetAddressNotFound(string addressIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { addressIdef },
                ErrCode = nameof(Translations.err019)
            };
        }

        public static Error GetPlayerAlreadyExists(string playerIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { playerIdef },
                ErrCode = nameof(Translations.err006)
            };
        }

        public static Error GetTournamentNotFound(string tournamentIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { tournamentIdef },
                ErrCode = nameof(Translations.err007)
            };
        }

        public static Error GetTeamNotRegisteredToTournament(string teamIdef, string tournamentIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { teamIdef, tournamentIdef },
                ErrCode = nameof(Translations.err011)
            };
        }

        public static Error GetMatchNotFound(string matchIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { matchIdef },
                ErrCode = nameof(Translations.err008)
            };
        }

        public static Error GetMatchSetNotFound(int setOrder)
        {
            return new Error
            {
                ErrArgs = new string[] { setOrder.ToString() },
                ErrCode = nameof(Translations.err010)
            };
        }

        public static Error EmptyFilter()
        {
            return new Error
            {
                ErrArgs = new string[] { },
                ErrCode = nameof(Translations.err009)
            };
        }

        public static Error GetTeamAlreadyRegisteredToTournament(string teamIdef, string tournamentIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { teamIdef, tournamentIdef },
                ErrCode = nameof(Translations.err012)
            };
        }

        public static Error GetTournamentTeamStatsNotFound(string teamIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { teamIdef },
                ErrCode = nameof(Translations.err020)
            };
        }

        public static Error SomethingWentWrong()
        {
            return new Error
            {
                ErrArgs = new string[] { },
                ErrCode = nameof(Translations.err013)
            };
        }

        public static Error InvalidUserNameOrPassword()
        {
            return new Error
            {
                ErrArgs = new string[0],
                ErrCode = nameof(Translations.err014)
            };
        }

        public static Error InvalidNumberOfBasicGroups()
        {
            return new Error
            {
                ErrArgs = new string[0],
                ErrCode = nameof(Translations.err015)
            };
        }

        public static Error PlayoffCouplesAlreadyAdded(string tournamentIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { tournamentIdef },
                ErrCode = nameof(Translations.err016)
            };
        }

        public static Error GroupsAlreadyDrawn(string tournamentIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { tournamentIdef },
                ErrCode = nameof(Translations.err017)
            };
        }

        public static Error MatchesAlreadyDrawn(string tournamentIdef)
        {
            return new Error
            {
                ErrArgs = new string[] { tournamentIdef },
                ErrCode = nameof(Translations.err018)
            };
        }
    }
}
