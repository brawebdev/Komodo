using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Data
{
    public class Team
    {
        [Key, ForeignKey("Contract")]
        public int TeamId { get; set; }

        [Required]
        public Guid TeamManagerId { get; set; }

        [Required]
        public string TeamName { get; set; }

        public bool IsActive { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
