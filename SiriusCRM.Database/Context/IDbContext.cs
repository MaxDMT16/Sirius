using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SiriusCRM.Database.Context
{
    public interface IDbContext
    {
        IDbConnection Connection { get; }

        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        void Dispose();
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}