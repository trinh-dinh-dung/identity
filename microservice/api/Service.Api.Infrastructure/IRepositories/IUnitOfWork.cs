using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Dispose();
        GenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
