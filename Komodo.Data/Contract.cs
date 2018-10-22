using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Data
{
    public class Contract
    {
        [Key]
        public Guid ContractId { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        public int? TeamId { get; set; }
    }
}
