using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Models.ContractModels
{
    public class ContractUpdate
    {
        public Guid DeveloperManagerId { get; set; }

        public int TeamId { get; set; }
        public int ContractId { get; set; }
    }
}
