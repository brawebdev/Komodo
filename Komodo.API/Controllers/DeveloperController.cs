using Komodo.Contracts;
using Komodo.Models.DeveloperModels;
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
    public class DeveloperController : ApiController
    {
        IDeveloperService _developerService;

        public DeveloperController()
        {
        }

        public DeveloperController(IDeveloperService mockService)
        {
            _developerService = mockService;
        }

        public IHttpActionResult GetAll()
        {
            CreateDeveloperService();

            var developers = _developerService.GetDevelopers();
            return Ok(developers);
        }

        [Route("developer/active")]
        public IHttpActionResult GetActive()
        {
            CreateDeveloperService();

            var developers = _developerService.GetActiveDevelopers();
            return Ok(developers);
        }

        [Route("developer/inactive")]
        public IHttpActionResult GetInactive()
        {
            CreateDeveloperService();

            var developers = _developerService.GetInactiveDevelopers();
            return Ok(developers);
        }

        public IHttpActionResult Post(DeveloperCreate developer)
        {
            CreateDeveloperService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_developerService.CreateDeveloper(developer))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(DeveloperUpdate developer)
        {
            CreateDeveloperService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_developerService.UpdateDeveloper(developer))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            CreateDeveloperService();

            if (!_developerService.DeleteDeveloper(id))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            CreateDeveloperService();

            var developers = _developerService.GetDeveloperById(id);
            return Ok(developers);
        }

        private void CreateDeveloperService()
        {
            if (_developerService == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                _developerService = new DeveloperService(userId);
            }
        }
    }
}
