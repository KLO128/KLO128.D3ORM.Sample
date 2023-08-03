using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Application.Contracts;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Args;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Entities;
using KLO128.D3ORM.Sample.Application.Contracts.DTOs.Results;
using KLO128.D3ORM.Sample.Application.Contracts.Services;
using KLO128.D3ORM.Sample.Application.Web.Extensions;
using KLO128.D3ORM.Sample.Domain;
using KLO128.D3ORM.Sample.Domain.Models;
using KLO128.D3ORM.Sample.Domain.Models.Entities;
using KLO128.D3ORM.Sample.Domain.Repositories;
using KLO128.D3ORM.Sample.Domain.Services;
using KLO128.D3ORM.Sample.Domain.Shared;

namespace KLO128.D3ORM.Sample.Application.Web
{
    public class TournamentWebService : ITournamentService
    {
        private IQueryContainer QC { get; set; }

        private IUnitOfWork UnitOfWork { get; set; }

        private IUserDomainService UserDomainService { get; set; }

        private ITournamentDomainService TournamentDomainService { get; set; }

        private IMatchDomainService MatchDomainService { get; set; }

        private IMatchRepository MatchRepository { get; set; }

        private ITournamentRepository TournamentRepository { get; set; }

        private ITeamRepository TeamRepository { get; set; }

        private ITournamentTeamRepository TournamentTeamRepository { get; set; }

        private IPlayoffRoundCoupleRepository PlayoffRoundCoupleRepository { get; set; }

        private Random Random { get; set; } = new Random();

        public TournamentWebService(IUnitOfWork UnitOfWork, IQueryContainer QC, IUserDomainService UserDomainService, ITournamentDomainService TournamentDomainService, IMatchDomainService MatchDomainService, IMatchRepository MatchRepository, ITournamentRepository TournamentRepository, ITeamRepository TeamRepository, ITournamentTeamRepository TournamentTeamRepository, IPlayoffRoundCoupleRepository PlayoffRoundCoupleRepository)
        {
            this.UnitOfWork = UnitOfWork;
            this.QC = QC;
            this.UserDomainService = UserDomainService;
            this.TournamentDomainService = TournamentDomainService;
            this.MatchDomainService = MatchDomainService;
            this.MatchRepository = MatchRepository;
            this.TournamentRepository = TournamentRepository;
            this.TeamRepository = TeamRepository;
            this.TournamentTeamRepository = TournamentTeamRepository;
            this.PlayoffRoundCoupleRepository = PlayoffRoundCoupleRepository;
        }

        public ServiceResult<List<PlayoffRoundCoupleDTO>> CreatePlayoffFirstRoundCouplesTransact(CreatePlayoffRoundArgs args, int signedInUserId, bool authorize)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => CreatePlayoffFirstRoundCouplesUnsafe(args, signedInUserId, authorize)));
        }

        public List<PlayoffRoundCoupleDTO> CreatePlayoffFirstRoundCouplesUnsafe(CreatePlayoffRoundArgs args, int signedInUserId, bool authorize)
        {
            Helpers.Authorize<List<PlayoffRoundCoupleDTO>>(UserDomainService, signedInUserId, Roles.Admin, authorize);

            var teamRankings = TournamentTeamRepository.FindManyBy(QC.GetTournamentTeamsSortedByStatsQuery(args.TournamentId, 0));

            if (teamRankings == null)
            {
                throw Errors.GetTournamentNotFound(args.TournamentId.ToString());
            }
            else if (PlayoffRoundCoupleRepository.CountRows(QC.GetPlayoffRoundCoupleFilterQuery(args.TournamentId, null)) > 0)
            {
                throw Errors.PlayoffCouplesAlreadyAdded(args.TournamentId.ToString());
            }

            if (teamRankings.Count == 0)
            {
                return new List<PlayoffRoundCoupleDTO>();
            }

            var groupsCount = teamRankings.Select(x => x.BasicGroupName).Distinct().Count();
            var pairModulo = groupsCount.IsPowerOfTwo();

            SortedList<string, List<TournamentTeamRank>> groups;

            if (pairModulo)
            {
                var groupsTmp = teamRankings.GroupBy(x => x.BasicGroupName);
                groups = new SortedList<string, List<TournamentTeamRank>>();

                foreach (var group in groupsTmp)
                {
                    var key = group.Key ?? string.Empty;
                    if (groups.ContainsKey(key))
                    {
                        throw new Exception("Internal Exception: Not empty group list");
                    }
                    else
                    {
                        groups.Add(key, group.Select(x => x).ToList());
                    }
                }
            }
            else
            {
                groups = new SortedList<string, List<TournamentTeamRank>>
                {
                    {
                        teamRankings.First().BasicGroupName ?? string.Empty,
                        teamRankings.Select(x => x).ToList()
                    }
                };
            }

            var result = new List<PlayoffRoundCoupleDTO>();

            //if (groups.Count % 2 != 0)
            //{
            //    throw Errors.InvalidNumberOfBasicGroups();
            //}

            var playoffPass = args.PlayoffPass ?? (int)Math.Pow(2, (int)Math.Floor(Math.Log2(teamRankings.Count)));

            if (groups.Count == 1)
            {
                var group = groups.First();
                AddPlayoffCouple(result, playoffPass, 1, group.Value, group.Value, signedInUserId);
            }
            else
            {
                for (int i = 0, j = groups.Count - 1; i < j; i++, j--)
                {
                    AddPlayoffCouple(result, playoffPass, groups.Count, groups.ElementAt(i).Value, groups.ElementAt(j).Value, signedInUserId);
                }
            }

            return result;
        }

        private void AddPlayoffCouple(List<PlayoffRoundCoupleDTO> ret, int playoffPass, int groupsCount, List<TournamentTeamRank> group1, List<TournamentTeamRank> group2, int changedBy)
        {
            var groupTeamsCount = group1.Count > group2.Count ? group2.Count : group1.Count;

            var groupPass = playoffPass / groupsCount;

            for (int i = 0, j = groupPass - 1; group1 == group2 ? i < j : i < groupPass; i++, j--)
            {
                var team1 = group1[i].ToDTO<TournamentTeam>();
                var team2 = group2[j].ToDTO<TournamentTeam>();

                var couple = new PlayoffRoundCouple
                {
                    ChangedBy = changedBy,
                    LastChange = DateTime.UtcNow,
                    PlayoffRound = 1,
                    TournamentTeam1Id = team1.TournamentTeamId,
                    TournamentTeam2Id = team2.TournamentTeamId,
                    TournamentTeam1 = team1,
                    TournamentTeam2 = team2
                };
                PlayoffRoundCoupleRepository.AddRoot(couple);
                TournamentDomainService.CreateEmptyStats(team1, 1, changedBy);
                TournamentDomainService.CreateEmptyStats(team2, 1, changedBy);

                ret.Add(couple.ToDTO<PlayoffRoundCoupleDTO>());
            }
        }

        public ServiceResult<List<GroupTeamsResult>> DrawGroupsTransact(DrawGroupsArgs args, int signedInUserId, bool authorize)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => DrawGroupsUnsafe(Random, args, signedInUserId, authorize)));
        }

        public List<GroupTeamsResult> DrawGroupsUnsafe(Random rand, DrawGroupsArgs args, int signedInUserId, bool authorize)
        {
            Helpers.Authorize<List<GroupTeamsResult>>(UserDomainService, signedInUserId, Roles.Admin, authorize);

            var tournament = TournamentRepository.FindBy(QC.GetTournamenIdBaseFilterQuery(args.TournamentId));

            if (tournament == null)
            {
                throw Errors.GetTournamentNotFound(args.TournamentId.ToString());
            }
            else if (tournament.TournamentTeams.FirstOrDefault()?.BasicGroupName != null)
            {
                throw Errors.GroupsAlreadyDrawn(args.TournamentId.ToString());
            }

            int groupCount;
            int teamsPerGroupCount;
            var tournamentTeamsCount = tournament.TournamentTeams.Count;
            var groupTeamsMinCount = args.MinNumberOfTeamsPerGroup ?? 4;
            var groupTeamsMaxCount = args.MaxNumberOfTeamsPerGroup ?? args.MinNumberOfTeamsPerGroup * 2 - 1;

            if (args.GroupNames != null)
            {
                //if (args.GroupNames.Count % 2 != 0)
                //{
                //    throw Errors.InvalidNumberOfBasicGroups();
                //}

                groupCount = args.GroupNames.Count;
                teamsPerGroupCount = tournamentTeamsCount / groupCount;
            }
            else
            {
                var restTeamsCount = tournamentTeamsCount;
                var multiples = new Queue<int>();

                while (restTeamsCount > 0)
                {
                    int multiple;

                    if (restTeamsCount % 2 == 0)
                    {
                        multiple = 2;
                    }
                    else if (restTeamsCount % 3 == 0)
                    {
                        multiple = 3;
                    }
                    else if (restTeamsCount % 5 == 0)
                    {
                        multiple = 5;
                    }
                    else
                    {
                        multiple = 0;
                        restTeamsCount -= 1;
                    }

                    if (multiple > 0)
                    {
                        if (multiples.Count == 0 && multiple > 2 && multiple > groupTeamsMaxCount)
                        {
                            restTeamsCount -= 1;
                        }
                        else
                        {
                            restTeamsCount /= multiple;
                            multiples.Enqueue(multiple);
                        }
                    }
                }

                teamsPerGroupCount = 1;
                var lastCount = teamsPerGroupCount;

                while (multiples.Count > 0)
                {
                    if (teamsPerGroupCount == groupTeamsMaxCount)
                    {
                        break;
                    }

                    var multiple = multiples.Dequeue();
                    teamsPerGroupCount *= multiple;

                    if (teamsPerGroupCount > groupTeamsMaxCount)
                    {
                        teamsPerGroupCount = lastCount;
                        groupCount = tournamentTeamsCount / teamsPerGroupCount;

                        while (groupCount > teamsPerGroupCount || teamsPerGroupCount < groupTeamsMinCount)
                        {
                            groupCount--;
                            teamsPerGroupCount++;

                            if (groupCount * teamsPerGroupCount > tournamentTeamsCount)
                            {
                                if (tournamentTeamsCount > groupTeamsMaxCount)
                                {
                                    tournamentTeamsCount--;
                                }
                                else
                                {
                                    groupCount--;
                                }

                                break;
                            }
                            else if (groupCount.IsPowerOfTwo() && teamsPerGroupCount >= groupTeamsMinCount)
                            {
                                break;
                            }
                        }

                        while (teamsPerGroupCount > groupTeamsMaxCount)
                        {
                            teamsPerGroupCount--;
                        }

                        var remainingTeams = tournamentTeamsCount - groupCount * teamsPerGroupCount;

                        while (remainingTeams > 0 && remainingTeams > teamsPerGroupCount)
                        {// redistribution of remaining teams

                            if (teamsPerGroupCount >= groupTeamsMaxCount)
                            {
                                groupCount++;
                                remainingTeams -= teamsPerGroupCount;
                            }
                            else
                            {
                                teamsPerGroupCount++;
                                remainingTeams = tournamentTeamsCount - groupCount * teamsPerGroupCount;
                            }
                        };

                        break;
                    }

                    lastCount = teamsPerGroupCount;
                }

                groupCount = tournamentTeamsCount / teamsPerGroupCount;
            }

            var extraTeamsAllowed = tournamentTeamsCount % groupCount;

            var result = new List<GroupTeamsResult>(groupCount);

            for (int i = 0; i < groupCount; i++)
            {
                result.Add(new GroupTeamsResult
                {
                    GroupName = args.GroupNames?.ElementAtOrDefault(i) ?? $"Group {i + 1}",
                    TournamentId = args.TournamentId,
                    TournamentName = tournament.Name
                });
            }

            var fullGroups = false;

            foreach (var item in tournament.TournamentTeams)
            {
                var groupIndex = rand.Next(0, groupCount);
                var i = groupIndex;
                var stopAt = groupCount;
                var found = false;

            FindEmpty:
                for (; i < stopAt; i++)
                {
                    var groupTmp = result[i];

                    if (fullGroups && groupTmp.Teams.Count >= teamsPerGroupCount + extraTeamsAllowed || !fullGroups && groupTmp.Teams.Count >= teamsPerGroupCount)
                    {
                        continue;
                    }

                    found = true;
                    break;
                }

                if (!found)
                {
                    if (i == groupCount)
                    {
                        i = 0;
                        stopAt = groupIndex;
                        goto FindEmpty;
                    }
                    else if (!fullGroups)
                    {
                        fullGroups = true;
                        i = groupIndex;
                        stopAt = groupCount;
                        goto FindEmpty;
                    }
                }
                else
                {
                    groupIndex = i;
                }

                var group = result[groupIndex];

                TournamentTeamRepository.UpdateProperties(item, x => x.BasicGroupName, group.GroupName);

                group.Teams.Add(item.Team.ToDTO<TeamDTO>());
            }

            return result;
        }

        public ServiceResult<List<MatchDTO>> DrawMatchesTransact(DrawMatchesArgs args, int signedInUserId, bool authorize)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => DrawMatchesUnsafe(Random, args, signedInUserId, authorize)));
        }

        public List<MatchDTO> DrawMatchesUnsafe(Random rand, DrawMatchesArgs args, int signedInUserId, bool authorize)
        {
            Helpers.Authorize<List<MatchDTO>>(UserDomainService, signedInUserId, Roles.Admin, authorize);

            var tournament = TournamentRepository.FindBy(QC.CreateQueryParamized(QC.TournamentBaseQuery.And(QC.TournamentTeamSortedByGroupQuery), QC.GetTournamentTeamFilterQuery(args.TournamentId, null)));

            if (tournament == null)
            {
                throw Errors.GetTournamentNotFound(args.TournamentId.ToString());
            }
            else if (MatchRepository.CountRows(QC.CreateQueryParamized(QC.MatchBaseQuery.Compare(x => x.WinnerId, ComparisonOp.GREATER_THAN_OR_EQUAL, 0, LogicalOp.AND), QC.GetTournamentIdFilterQuery(args.TournamentId))) > 0)
            {
                throw Errors.MatchesAlreadyDrawn(args.TournamentId.ToString());
            }

            var groups = tournament.TournamentTeams.GroupBy(x => x.BasicGroupName).ToList();
            var matches = new List<MatchDTO>();

            foreach (var group in groups)
            {
                for (int i = 0; i < group.Count(); i++)
                {
                    for (int j = i + 1; j < group.Count(); j++)
                    {
                        var match = MatchDomainService.AddMatch(group.ElementAt(i).TeamId, group.ElementAt(j).TeamId, args.TournamentId, 0, signedInUserId);

                        matches.Add(match.ToDTO<MatchDTO>());
                    }
                }
            }

            matches.ForEach(x => x.Tournament = null);

            return matches;
        }

        public ServiceResult<List<PlayoffRoundCoupleDTO>> GetPlayoffCouples(int tournamentId, int? playoffRound)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                var couples = PlayoffRoundCoupleRepository.FindManyBy(QC.GetPlayoffRoundCoupleBaseFilterQuery(tournamentId, playoffRound));

                if (couples == null)
                {
                    throw Errors.GetTournamentNotFound(tournamentId.ToString());
                }

                return couples.Select(x => x.ToDTO<PlayoffRoundCoupleDTO>()).ToList();
            });

        }

        public TournamentTeamDTO SignUpTeamUnsafe(SignUpTeamArgs args, int signedInUserId, bool authorize)
        {
            Helpers.Authorize<TournamentTeamDTO>(UserDomainService, signedInUserId, Roles.Admin, authorize, args.TeamId);

            var result = TournamentDomainService.CreateTournamentTeam(args.TeamId, args.TournamentId, signedInUserId);
            TournamentDomainService.CreateEmptyStats(result, 0, signedInUserId);

            return result.ToDTO<TournamentTeamDTO>();
        }

        public ServiceResult<TournamentTeamDTO> SignUpTeamTransact(SignUpTeamArgs args, int signedInUserId)
        {
            return ServiceResult.GetServiceResult(() => UnitOfWork.Transaction(() => SignUpTeamUnsafe(args, signedInUserId, true)));
        }

        public ServiceResult<TournamentDTO> CreateTournament(CreateTournamentArgs args, int signedInUsedId, bool authorize)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                var ret = new Tournament
                {
                    AddressId = args.AddressId,
                    ChangedBy = signedInUsedId,
                    EndDate = args.EndDate,
                    EntryFee = args.EntryFee,
                    LastChange = DateTime.UtcNow,
                    MaxNumOfTeams = args.MaxNumOfTeams,
                    Name = args.Name,
                    StartDate = args.StartDate,
                    TourSerieId = args.TourSerieId
                };

                TournamentRepository.AddRoot(ret);

                return ret.ToDTO<TournamentDTO>();
            });
        }
    }
}
