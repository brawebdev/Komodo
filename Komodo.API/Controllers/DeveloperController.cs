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
        public IHttpActionResult GetAll()
        {
            DeveloperService developerService = CreateDeveloperService();
            var developers = developerService.GetDevelopers();
            return Ok(developers);
        }

        public IHttpActionResult Post(DeveloperCreate developer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDeveloperService();

            if (!service.CreateDeveloper(developer))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(DeveloperUpdate developer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDeveloperService();

            if (!service.UpdateDeveloper(developer))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateDeveloperService();

            if (!service.DeleteDeveloper(id))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            DeveloperService developerService = CreateDeveloperService();
            var developers = developerService.GetDeveloperById(id);
            return Ok(developers);
        }

        private DeveloperService CreateDeveloperService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var developerService = new DeveloperService(userId);
            return developerService;
        }
    }
}
