using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Data
{
    public class Developer
    {
        [Key, ForeignKey("Contract")]
        public int DeveloperId { get; set; }

        [Required]
        public Guid DeveloperManagerId { get; set; }

        [Required]
        public string DeveloperName { get; set; }

        [Required]
        public DateTimeOffset HireDate { get; set; }

        public bool IsActive { get; set; }

        public virtual Contract Contract { get; set; }
    }
}
