using Komodo.Contracts;
using Komodo.Data;
using Komodo.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Services.MockServices
{
    public class MockTeamService : ITeamService
    {
        public bool ReturnValue { get; set; }
        public int CallCount { get; set; }

        public bool CreateTeam(TeamCreate model)
        {
            CallCount++;
            return ReturnValue;
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            CallCount++;
            var @return = new List<TeamListItem> { new TeamListItem { TeamId = 1 } };
            return @return;
        }

        public TeamDetail GetTeamById(int id)
        {
            CallCount++;
            return new TeamDetail { TeamId = id };
        }

        public bool UpdateTeam(TeamUpdate model)
        {
            return ReturnValue;
        }

        public bool DeleteTeam(int Id)
        {
            CallCount--;
            return ReturnValue;
        }

        public IEnumerable<TeamListItem> GetActiveTeams()
        {
            CallCount++;
            var @return = new List<TeamListItem> { new TeamListItem { TeamId = 1, IsActive = true } };
            return @return;
        }

        public IEnumerable<TeamListItem> GetInactiveTeams()
        {
            CallCount++;
            var @return = new List<TeamListItem> { new TeamListItem { TeamId = 1, IsActive = false } };
            return @return;
        }
    }
}
