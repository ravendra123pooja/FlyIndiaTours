using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;



namespace Infrastructure.UnityOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        Task<int> CommitAsync();
        void Rollback();
        //Task RollbackAsync();

    }
}
