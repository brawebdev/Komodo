using Komodo.Contracts;
using Komodo.Models.TeamModels;
using Komodo.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Komodo.API.Controllers
{
    [Authorize]
    public class TeamController : ApiController
    {
        private ITeamService _teamService;

        public TeamController()
        {

        }

        public TeamController(ITeamService mock)
        {
            _teamService = mock;
        }

        public IHttpActionResult GetAll()
        {
            CreateTeamService();

            var teams = _teamService.GetTeams();
            return Ok(teams);
        }

        public IHttpActionResult Post(TeamCreate team)
        {
            CreateTeamService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teamService.CreateTeam(team))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(TeamUpdate team)
        {
            CreateTeamService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teamService.UpdateTeam(team))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            CreateTeamService();

            if (!_teamService.DeleteTeam(id))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            CreateTeamService();

            var teams = _teamService.GetTeamById(id);
            return Ok(teams);
        }

        private void CreateTeamService()
        {
            if (_teamService == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                _teamService = new TeamService(userId);
            }
        }
    }
}
