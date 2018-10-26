using Komodo.Models.DeveloperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Contracts
{
    public interface IDeveloperService
    {
        bool CreateDeveloper(DeveloperCreate model);

        IEnumerable<DeveloperListItem> GetDevelopers();

        DeveloperDetail GetDeveloperById(int id);


        bool UpdateDeveloper(DeveloperUpdate model);

        bool DeleteDeveloper(int Id);

        IEnumerable<DeveloperListItem> GetActiveDevelopers();

        IEnumerable<DeveloperListItem> GetInactiveDevelopers();
    }
}
