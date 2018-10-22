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
        public IHttpActionResult GetAll()
        {
            ContractService contractService = CreateContractService();
            var contracts = contractService.GetContracts();
            return Ok(contracts);
        }

        public IHttpActionResult Post(ContractCreate contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateContractService();

            if (!service.CreateContract(contract))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ContractUpdate contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateContractService();

            if (!service.UpdateContract(contract))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateContractService();

            if (!service.DeleteContract(id))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            ContractService contractService = CreateContractService();
            var contracts = contractService.GetContracts();
            return Ok(contracts);
        }

        private ContractService CreateContractService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var contractService = new ContractService(userId);
            return contractService;
        }
    }
}
