using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;



namespace Infrastructure.UnityOfWork.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All();
        Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null);
        IQueryable<T> All(bool tracking = true);
        IQueryable<T> Entity();
        IQueryable<T> Filter(Expression<Func<T,bool>> predicate,params string[] includes);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate=null, Func<IQueryable<T> ,IOrderedQueryable<T>> orderBy=null, params string[] includes);
        T Find(params object[] keys);
        Task<T> FindAsync(params object[] keys);
        T Find(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        T Insert(T t);
        void InsertAll(IEnumerable<T> entities);
        void Update(T t);
        void UpdateAll(IEnumerable<T> entities);
        void Delete(T t);
        void DeleteAll(IEnumerable<T> entities);
        void TruncateTable(string tableName);
        Task TruncateTableAsync(string tableName);
        IQueryable<T> ExecuteProcedure(string procedureName, params SqlParameter[] parameter);
        IQueryable<T> ExecuteProcedure(string procedureName);
        IEnumerable<T> ExecuteSqlRawQuery(string sqlStmt, params SqlParameter[] parameter);
    }
}
