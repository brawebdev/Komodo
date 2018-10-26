using Komodo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Models.TeamModels
{
    public class TeamCreate
    {
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public bool IsActive { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
