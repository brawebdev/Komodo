using Komodo.Data;
using Komodo.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Services
{
    public class TeamService
    {
        private readonly Guid _userId;

        public TeamService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                new Team()
                {
                   TeamManagerId = _userId,
                   TeamMembers = model.TeamMembers,
                   TeamName = model.TeamName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Where(e => e.TeamManagerId == _userId)
                        .Select(
                            e =>
                                new TeamListItem()
                                {
                                    TeamManagerId = e.TeamManagerId,
                                    TeamMembers = e.TeamMembers,
                                    TeamId = e.TeamId,
                                    TeamName = e.TeamName
                                }
                        );

                return query.ToArray();
            }
        }

        public TeamDetail GetTeamById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == id && e.TeamManagerId == _userId);
                return
                    new TeamDetail
                    {
                        TeamManagerId = entity.TeamManagerId,
                        TeamId = entity.TeamId,
                        TeamName = entity.TeamName,
                        TeamMembers = entity.TeamMembers
                    };
            }
        }

        public bool UpdateTeam(TeamUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == model.TeamId && e.TeamManagerId == _userId);

                entity.TeamMembers = model.TeamMembers;
                entity.TeamName = model.TeamName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.TeamId == Id && e.TeamManagerId == _userId);

                ctx.Teams.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
