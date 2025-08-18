
using Infrastructure.EF;
using Infrastructure.UnityOfWork.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection.Metadata;
using System;
using Microsoft.Identity.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.UnityOfWork.Repository
{

    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DbFactory _dbFactory;
        public DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }
        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public IEnumerable<T> All()
        {
            return DbSet.AsEnumerable();
        }
        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {

            IQueryable<T> query = _dbSet;
            if (expression is not null) query = query.Where(expression);
            if (includes is not null) query = includes(query);
            if (orderBy is not null) query = orderBy(query);
            return await query.AsNoTracking().ToListAsync();

        }
        public IQueryable<T> All(bool tracking = true)
        {
            return tracking ? DbSet.AsQueryable() : DbSet.AsNoTracking().AsQueryable();

        }
        public IQueryable<T> Entity()
        {
            return DbSet;
        }
        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var dbset = DbSet.Where(predicate).AsQueryable().AsNoTracking();
            if (includes != null && includes.Any()) return dbset;
                return includes.Aggregate(dbset, (current, includes) => current.Include(includes));

        }
        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params string[] includes)
        {
            IQueryable<T> dbset = DbSet.AsQueryable();
            if (predicate != null)
            {
                dbset = dbset.Where(predicate);

            }
            if (includes != null && includes.Any())
            {
                dbset = includes.Aggregate(dbset, (current, includes) => current.Include(includes));

            }
            if (orderBy != null)
            {
                return orderBy != null ? orderBy(dbset) : dbset;
            }
            else
            {

                return dbset;
            }
        }
        public T Find(params object[] keys)
        {
            return DbSet?.Find(keys)!;
        }
        public async Task<T?> FindAsync(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }
        public T? Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).FirstOrDefault();
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }
        public T Insert(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public void InsertAll(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }
        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
        public void UpdateAll(IEnumerable<T> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            DbSet.Update(entity);
        }

        public void DeleteAll(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
        public void TruncateTable(string tableName)
        {
            _dbFactory.DbContext.Database.ExecuteSqlRaw($"TRUNCATE TABLE {tableName}");
        }
        public async Task TruncateTableAsync(string tableName)
        {
            _dbFactory.DbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {tableName}");
        }
        public IQueryable<T> ExecuteProcedure(string procedureName, params SqlParameter[] parameter)
        {
            return DbSet.FromSqlRaw(procedureName, parameter);
        }
        public IQueryable<T> ExecuteProcedure(string procedureName)
        {
            return DbSet.FromSqlRaw(procedureName);
        }
        public IEnumerable<T> ExecuteSqlRawQuery(string sqlStmt, params SqlParameter[] parameter)
        {
            return DbSet.FromSqlRaw<T>(sqlStmt, parameter);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }
        public IQueryable<T> List()
        {
            return DbSet;
        }
      

    }
}
