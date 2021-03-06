﻿using Komodo.Contracts;
using Komodo.Data;
using Komodo.Models.DeveloperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly Guid _userId;

        public DeveloperService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDeveloper(DeveloperCreate model)
        {
            var entity =
                new Developer()
                {
                    DeveloperManagerId = _userId,
                    DeveloperName = model.DeveloperName,
                    HireDate = model.HireDate,
                    IsActive = true
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Developers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DeveloperListItem> GetDevelopers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Developers
                        .Where(e => e.DeveloperManagerId == _userId)
                        .Select(
                            e =>
                                new DeveloperListItem()
                                {
                                    DeveloperManagerId = e.DeveloperManagerId,
                                    DeveloperId = e.DeveloperId, 
                                    DeveloperName = e.DeveloperName,
                                    HireDate = e.HireDate,
                                    IsActive = e.IsActive
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<DeveloperListItem> GetActiveDevelopers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Developers
                        .Where(e => e.DeveloperManagerId == _userId && e.IsActive == true)
                        .Select(
                            e =>
                                new DeveloperListItem()
                                {
                                    DeveloperManagerId = e.DeveloperManagerId,
                                    DeveloperId = e.DeveloperId,
                                    DeveloperName = e.DeveloperName,
                                    HireDate = e.HireDate,
                                    IsActive = e.IsActive
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<DeveloperListItem> GetInactiveDevelopers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Developers
                        .Where(e => e.DeveloperManagerId == _userId && e.IsActive == false)
                        .Select(
                            e =>
                                new DeveloperListItem()
                                {
                                    DeveloperManagerId = e.DeveloperManagerId,
                                    DeveloperId = e.DeveloperId,
                                    DeveloperName = e.DeveloperName,
                                    HireDate = e.HireDate,
                                    IsActive = e.IsActive
                                }
                        );

                return query.ToArray();
            }
        }

        public DeveloperDetail GetDeveloperById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Developers
                        .Single(e => e.DeveloperId == id && e.DeveloperManagerId == _userId);
                return
                    new DeveloperDetail
                    {
                        DeveloperManagerId = entity.DeveloperManagerId,
                        DeveloperId = entity.DeveloperId,
                        DeveloperName = entity.DeveloperName,
                        HireDate = entity.HireDate,
                        IsActive = entity.IsActive
                    };
            }
        }

        public bool UpdateDeveloper(DeveloperUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Developers
                        .Single(e => e.DeveloperId == model.DeveloperId && e.DeveloperManagerId == _userId);

                entity.DeveloperName = model.DeveloperName;
                entity.HireDate = model.HireDate;
                entity.IsActive = model.IsActive;
                entity.Contract.IsActive = model.IsActive;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDeveloper(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Developers
                        .Single(e => e.DeveloperId == Id && e.DeveloperManagerId == _userId);

                var matchingContracts =
                    ctx
                        .Contracts
                        .Where(e => e.TeamId == Id);

                ctx.Contracts.RemoveRange(matchingContracts);
                ctx.Developers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
