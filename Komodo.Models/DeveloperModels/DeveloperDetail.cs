using Komodo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Models.DeveloperModels
{
    public class DeveloperDetail
    {
        public Guid DeveloperManagerId { get; set; }
        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public DateTimeOffset HireDate { get; set; }
        public bool IsActive { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
