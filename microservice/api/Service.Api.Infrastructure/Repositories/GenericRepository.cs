using Infrastructure.DataContext;
using Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal MaintenanceManagementContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(MaintenanceManagementContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet; query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);
            return query.Count();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, int offset = 0, int limit = -1, bool asSplitQuery = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (include != null) query = include(query);

            if (orderBy != null)
                return orderBy(query);

            //limit = -1: get all data
            if (limit != -1)
            {
                return query.Skip(offset).Take(limit);
            }
            if (asSplitQuery == true)
                query = query.AsSplitQuery();
            return query;
        }

        public virtual IEnumerable<TEntity> Get(out int count, Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, int offset = 0, int limit = -1, bool asSplitQuery = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (include != null) query = include(query);

            count = query.Count();

            if (orderBy != null)
                query = orderBy(query);

            //limit = -1: get all data
            if (limit != -1)
            {
                return query.Skip(offset).Take(limit);
            }
            if (asSplitQuery == true)
                query = query.AsSplitQuery();

            return query;
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, bool asSplitQuery = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (include != null) query = include(query);

            if (orderBy != null)
                query = orderBy(query);

            if (asSplitQuery == true)
                query = query.AsSplitQuery();

            return query.FirstOrDefault();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
        }
        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> GetDataFromSqlRaw(string sqlQuery)
        {
            return _dbSet.FromSqlRaw(sqlQuery);
        }
        public List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map, object[] parameter = null)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.Parameters.AddRange(parameter);
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();

                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }

                    return entities;
                }
            }
        }

    }
}
