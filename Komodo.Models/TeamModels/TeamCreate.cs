﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Models.TeamModels
{
    public class TeamCreate
    {
        public List<string> TeamMembers { get; set; }
        public string TeamName { get; set; }
    }
}