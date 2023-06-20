﻿using Domain.Interfaces;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IADirectoryApplicationDBContext _ctx;
        public IRepository<ArtificialIntelligence> ArtificialIntelligenceRepository => new BaseRepository<ArtificialIntelligence>(_ctx);
        public IRepository<CategoriesAI> CategoriesAIRepository => new BaseRepository<CategoriesAI>(_ctx);
        public IRepository<Role> RoleRepository => new BaseRepository<Role>(_ctx);
        public IRepository<User> UserRepository => new BaseRepository<User>(_ctx);

        public UnitOfWork(IADirectoryApplicationDBContext ctx)
        {
            _ctx = ctx;

        }

        public string GetDbConnection()
        {
            return _ctx.Database.GetDbConnection().ConnectionString;
        }

        public void Dispose()
        {
            if (_ctx != null)
            {
                _ctx.Dispose();
            }
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
