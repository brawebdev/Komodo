using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Komodo.API.Controllers;
using Komodo.Models.DeveloperModels;
using Komodo.Services.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo.Tests
{
    [TestClass]
    public class DeveloperControllerTests
    {
        private DeveloperController _controller;
        private MockDeveloperService _mockService;

        [TestInitialize]
        public void Arrange()
        {
            _mockService = new MockDeveloperService {ReturnValue = true};
            _controller = new DeveloperController(_mockService);
        }

        [TestMethod]
        public void DeveloperController_Post_ShouldReturnOk()
        {
            var developer = new DeveloperCreate {DeveloperId = 1};

            var result = _controller.Post(developer);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DeveloperController_Delete_ShouldReturnCorrectInt()
        {
            _mockService.CallCount = 1;

            var result = _controller.Delete(1);

            Assert.AreEqual(0, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DeveloperController_GetAll_ShouldReturnCorrectInt()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<DeveloperListItem>>));
        }

        [TestMethod]
        public void DeveloperController_Get_ShouldBeCorrectInt()
        {
            var result = _controller.Get(1);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<DeveloperDetail>));
        }
    }
}

