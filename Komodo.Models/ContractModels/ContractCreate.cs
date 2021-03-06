﻿using Komodo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Models.ContractModels
{
    public class ContractCreate
    {
        public int DeveloperId { get; set; }
        public int TeamId { get; set; }
        public int ContractId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Developer Developer { get; set; }
        public bool IsActive { get; set; }
    }
}
