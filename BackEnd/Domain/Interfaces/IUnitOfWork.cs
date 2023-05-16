using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ArtificialIntelligence> ArtificialIntelligenceRepository { get; }
        IRepository<CategoriesAI> CategoriesAIRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<User> UserRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
        string GetDbConnection();
    }
}
