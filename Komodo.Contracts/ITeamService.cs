using Komodo.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Contracts
{
    public interface ITeamService
    {
        bool CreateTeam(TeamCreate model);

        IEnumerable<TeamListItem> GetTeams();

        TeamDetail GetTeamById(int id);


        bool UpdateTeam(TeamUpdate model);

        bool DeleteTeam(int Id);
    }
}
