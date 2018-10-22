using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Models.ContractModels
{
    public class ContractDetail
    {
        public Guid DeveloperManagerId { get; set; }

        public int ContractId { get; set; }
        public int DeveloperId { get; set; }
        public int TeamId { get; set; }
    }
}
