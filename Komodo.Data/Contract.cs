﻿using System;
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
        public int ContractId { get; set; }

        [Required]
        public Guid DeveloperManagerId { get; set; }

        [Required]
        public int DeveloperId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Developer Developer { get; set; }
    }
}
