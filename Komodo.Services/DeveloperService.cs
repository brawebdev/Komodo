﻿using Komodo.Data;
using Komodo.Models.DeveloperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo.Services
{
    public class DeveloperService
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
                    DeveloperName = model.DeveloperName,
                    HireDate = model.HireDate,
                    TeamId = model.TeamId
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
                        .Select(
                            e =>
                                new DeveloperListItem()
                                {
                                    DeveloperId = e.DeveloperId, 
                                    DeveloperName = e.DeveloperName,
                                    HireDate = e.HireDate,
                                    TeamId = e.TeamId
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
                        .Single(e => e.DeveloperId == id);
                return
                    new DeveloperDetail
                    {
                        DeveloperId = entity.DeveloperId,
                        DeveloperName = entity.DeveloperName,
                        HireDate = entity.HireDate,
                        TeamId = entity.TeamId
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
                        .Single(e => e.DeveloperId == model.DeveloperId);

                entity.DeveloperName = model.DeveloperName;
                entity.HireDate = model.HireDate;
                entity.TeamId = model.TeamId;

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
                        .Single(e => e.DeveloperId == Id);

                ctx.Developers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
