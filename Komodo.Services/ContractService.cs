﻿using Komodo.Data;
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
            var entity =
                new Contract()
                {
                    DeveloperManagerId = _userId,
                    DeveloperId = model.DeveloperId,
                    TeamId = model.TeamId   
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contracts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
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
                                    TeamId = e.TeamId
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
                        TeamId = entity.TeamId
                    };
            }
        }

        public bool UpdateContract(ContractUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractId == model.ContractId && e.DeveloperManagerId == _userId);

                entity.TeamId = model.TeamId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteContract(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Contracts
                        .Single(e => e.ContractId == Id && e.DeveloperManagerId == _userId);

                ctx.Contracts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

