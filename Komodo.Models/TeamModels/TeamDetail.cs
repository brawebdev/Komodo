using Komodo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Models.TeamModels
{
    public class TeamDetail
    {
        public Guid TeamManagerId { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public bool IsActive { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
