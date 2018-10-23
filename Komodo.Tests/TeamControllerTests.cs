using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Komodo.API.Controllers;
using Komodo.Models.TeamModels;
using Komodo.Services.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo.Tests
{
    [TestClass]
    public class TeamControllerTests
    {
        private TeamController _controller;
        private MockTeamService _mockService;

        [TestInitialize]
        public void Arrange()
        {
            _mockService = new MockTeamService { ReturnValue = true };
            _controller = new TeamController(_mockService);
        }

        [TestMethod]
        public void TeamController_Post_ShouldReturnOk()
        {
            var team = new TeamCreate { TeamId = 1 };

            var result = _controller.Post(team);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void TeamController_Delete_ShouldReturnCorrectInt()
        {
            _mockService.CallCount = 1;

            var result = _controller.Delete(1);

            Assert.AreEqual(0, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void TeamController_GetAll_ShouldReturnCorrectInt()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<TeamListItem>>));
        }

        [TestMethod]
        public void TeamController_Get_ShouldBeCorrectInt()
        {
            var result = _controller.Get(1);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<TeamDetail>));
        }
    }
}
