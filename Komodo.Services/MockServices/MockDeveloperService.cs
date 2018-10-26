using Komodo.Contracts;
using Komodo.Data;
using Komodo.Models.DeveloperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Services.MockServices
{
    public class MockDeveloperService : IDeveloperService
    {
        public bool ReturnValue { get; set; }
        public int CallCount { get; set; }

        public bool CreateDeveloper(DeveloperCreate model)
        {
            CallCount++;
            return ReturnValue;
        }

        public IEnumerable<DeveloperListItem> GetDevelopers()
        {
            CallCount++;
            var @return = new List<DeveloperListItem> {new DeveloperListItem {DeveloperId = 1}};
            return @return;
        }

        public DeveloperDetail GetDeveloperById(int id)
        {
            CallCount++;
            return new DeveloperDetail {DeveloperId = id};
        }

        public bool UpdateDeveloper(DeveloperUpdate model)
        {
            return ReturnValue;
        }

        public bool DeleteDeveloper(int Id)
        {
            CallCount--;
            return ReturnValue;
        }

        public IEnumerable<DeveloperListItem> GetActiveDevelopers()
        {
            CallCount++;
            var @return = new List<DeveloperListItem> { new DeveloperListItem { DeveloperId = 1, IsActive = true } };
            return @return;
        }

        public IEnumerable<DeveloperListItem> GetInactiveDevelopers()
        {
            CallCount++;
            var @return = new List<DeveloperListItem> { new DeveloperListItem { DeveloperId = 1, IsActive = false } };
            return @return;
        }
    }
}
