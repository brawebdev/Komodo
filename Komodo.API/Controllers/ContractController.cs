using Komodo.Models.ContractModels;
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
    public class ContractController : ApiController
    {
        private IContractService _contractService;

        public ContractController()
        {
            
        }

        public ContractController(IContractService mockService)
        {
            _contractService = mockService;
        }

        public IHttpActionResult GetAll()
        {
            CreateContractService();

            var contracts = _contractService.GetContracts();
            return Ok(contracts);
        }

        public IHttpActionResult Post(ContractCreate contract)
        {
            CreateContractService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_contractService.CreateContract(contract))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            CreateContractService();

            if (!_contractService.DeleteContract(id))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            CreateContractService();

            var contracts = _contractService.GetContractById(id);
            return Ok(contracts);
        }

        private void CreateContractService()
        {
            if (_contractService == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                _contractService = new ContractService(userId);
            }
        }
    }
}
