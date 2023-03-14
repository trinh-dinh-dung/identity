using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        int Count(Expression<Func<TEntity, bool>> filter = null);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, int offset = 0, int limit = -1, bool asSplitQuery = false);

        IEnumerable<TEntity> Get(out int count, Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, int offset = 0, int limit = -1, bool asSplitQuery = false);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null,
                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                        bool enableTracking = true, bool asSplitQuery = false);

        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity> GetDataFromSqlRaw(string sqlQuery);

    }
}
