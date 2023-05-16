using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class IADirectoryApplicationDBContext : DbContext
    {
        public IADirectoryApplicationDBContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<CategoriesAI> CategoriesAI { get; set; }
        public DbSet<ArtificialIntelligence> ArtificialIntelligences { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Load all assemblies from configurations folder in infra.data
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

        }
    }
}
