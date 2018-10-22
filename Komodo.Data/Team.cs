using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public List<string> TeamMembers { get; set; }
        [Required]
        public string TeamName { get; set; }
    }
}
