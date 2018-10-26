using Komodo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Models.ContractModels
{
    public class ContractListItem
    {
        public Guid DeveloperManagerId { get; set; }
        public int ContractId { get; set; }
        public int DeveloperId { get; set; }
        public int TeamId { get; set; }
        public bool IsActive { get; set; }
        public Team Team { get; set; }
        public Developer Developer { get; set; }
    }
}
