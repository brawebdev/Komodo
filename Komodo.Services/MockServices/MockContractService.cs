using Komodo.Contracts;
using Komodo.Data;
using Komodo.Models.ContractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Services.MockServices
{
    public class MockContractService : IContractService
    {
        public bool ReturnValue { get; set; }
        public int CallCount { get; set; }

        public bool CreateContract(ContractCreate model)
        {
            CallCount++;
            return ReturnValue;
        }

        public IEnumerable<ContractListItem> GetContracts()
        {
            CallCount++;
            var @return = new List<ContractListItem> { new ContractListItem { ContractId = 1 } };
            return @return;
        }

        public ContractDetail GetContractById(int id)
        {
            CallCount++;
            return new ContractDetail { ContractId = id };
        }

        public bool DeleteContract(int Id)
        {
            CallCount--;
            return ReturnValue;
        }

        public IEnumerable<ContractListItem> GetAllDevelopersOnTeam(int id)
        {
            throw new NotImplementedException();
        }
    }
}

