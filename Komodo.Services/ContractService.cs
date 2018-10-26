using Komodo.Contracts;
using Komodo.Data;
using Komodo.Models.ContractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Services
{
    public class ContractService : IContractService
    {
        private readonly Guid _userId;

        public ContractService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateContract(ContractCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                CheckIfDeveloperExists(ctx, model);
                CheckIfTeamExists(ctx, model);
                CheckIfContractExists(ctx, model);

                var entity =
                    new Contract()
                    {
                        DeveloperManagerId = _userId,
                        DeveloperId = model.DeveloperId,
                        TeamId = model.TeamId,
                        IsActive = true
                    };

                ctx.Contracts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        private void CheckIfDeveloperExists(ApplicationDbContext ctx, ContractCreate model)
        {
            var entity =
                ctx
                    .Developers
                    .SingleOrDefault(e => e.DeveloperId == model.DeveloperId);

            if (entity == null)
                throw new ArgumentNullException("The developer you entered does not exist in the system.");
        }


        private void CheckIfTeamExists(ApplicationDbContext ctx, ContractCreate model)
        {
            var entity =
                ctx
                    .Teams
                    .SingleOrDefault(e => e.TeamId == model.TeamId);

            if (entity == null)
                throw new ArgumentNullException("The team you entered does not exist in the system.");
        }

        private void CheckIfContractExists(ApplicationDbContext ctx, ContractCreate model)
        {
            var entity =
                ctx
                    .Contracts
                    .Single(e => e.DeveloperId == model.DeveloperId && e.IsActive == true);

            if (entity != null)
                throw new Exception("The developer you entered already has an existing contract");
        }

        public IEnumerable<ContractListItem> GetContracts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Contracts
                        .Where(e => e.DeveloperManagerId == _userId)
                        .Select(
                            e =>
                                new ContractListItem()
                                {
                                    DeveloperManagerId = e.DeveloperManagerId,
                                    ContractId = e.ContractId,
                                    DeveloperId = e.DeveloperId,
                                    TeamId = e.TeamId,
                                    Team = e.Team,
                                    Developer = e.Developer,
                                    IsActive = e.IsActive
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<ContractListItem> GetActiveContracts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Contracts
                        .Where(e => e.DeveloperManagerId == _userId && e.IsActive == true)
                        .Select(
                            e =>
                                new ContractListItem()
                                {
                                    DeveloperManagerId = e.DeveloperManagerId,
                                    ContractId = e.ContractId,
                                    DeveloperId = e.DeveloperId,
                                    TeamId = e.TeamId,
                                    Team = e.Team,
                                    Developer = e.Developer,
                                    IsActive = e.IsActive
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<ContractListItem> GetInactiveContracts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Contracts
                        .Where(e => e.DeveloperManagerId == _userId && e.IsActive == false)
                        .Select(
                            e =>
                                new ContractListItem()
                                {
                                    DeveloperManagerId = e.DeveloperManagerId,
                                    ContractId = e.ContractId,
                                    DeveloperId = e.DeveloperId,
                                    TeamId = e.TeamId,
                                    Team = e.Team,
                                    Developer = e.Developer,
                                    IsActive = e.IsActive
                                }
                        );

                return query.ToArray();
            }
        }

        public ContractDetail GetContractById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractId == id && e.DeveloperManagerId == _userId);
                return
                    new ContractDetail
                    {
                        DeveloperManagerId = entity.DeveloperManagerId,
                        DeveloperId = entity.DeveloperId,
                        ContractId = entity.ContractId,
                        TeamId = entity.TeamId,
                        IsActive = entity.IsActive
                    };
            }
        }

        public IEnumerable<ContractListItem> GetAllDevelopersOnTeam(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Contracts
                        .Where(e => e.DeveloperManagerId == _userId && e.TeamId == id)
                        .Select(
                            e =>
                                new ContractListItem()
                                {
                                    DeveloperManagerId = e.DeveloperManagerId,
                                    ContractId = e.ContractId,
                                    DeveloperId = e.DeveloperId,
                                    TeamId = e.TeamId,
                                    Team = e.Team,
                                    Developer = e.Developer,
                                    IsActive = e.IsActive
                                }
                        );

                return query.ToArray();
            }
        }

        public bool DeleteContract(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .SingleOrDefault(e => e.ContractId == Id && e.DeveloperManagerId == _userId);

                ctx.Contracts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

