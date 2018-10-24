using Komodo.Models.ContractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Services
{
    public interface IContractService
    {
        bool CreateContract(ContractCreate model);

        IEnumerable<ContractListItem> GetContracts();

        IEnumerable<ContractListItem> GetAllDevelopersOnTeam(int id);

        ContractDetail GetContractById(int id);

        bool DeleteContract(int Id);
    }
}
