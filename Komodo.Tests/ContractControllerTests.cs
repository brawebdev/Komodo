using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Komodo.API.Controllers;
using Komodo.Models.ContractModels;
using Komodo.Services.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo.Tests
{
    [TestClass]
    public class ContractControllerTests
    {
        private ContractController _controller;
        private MockContractService _mockService;
 
        [TestInitialize]
        public void Arrange()
        {
            _mockService = new MockContractService {ReturnValue = true};
            _controller = new ContractController(_mockService);
        }

        [TestMethod]
        public void ContractController_Post_ShouldReturnOk()
        {
            var contract = new ContractCreate { ContractId = 1 };

            var result = _controller.Post(contract);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ContractController_Delete_ShouldReturnCorrectInt()
        {
            _mockService.CallCount = 1;

            var result = _controller.Delete(1);

            Assert.AreEqual(0, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ContractController_GetAll_ShouldReturnCorrectInt()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<ContractListItem>>));
        }

        [TestMethod]
        public void ContractController_Get_ShouldBeCorrectInt()
        {
            var result = _controller.Get(1);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContractDetail>));
        }
    }
}
