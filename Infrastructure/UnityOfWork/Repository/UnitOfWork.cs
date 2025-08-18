
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

    public class UnitOfWork : IUnitOfWork
    {
        public DbFactory _dbFactory;

        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public void Commit()
        {
            _dbFactory.DbContext.SaveChanges();
        }
        public async Task<int> CommitAsync()
        {
            int result = await _dbFactory.DbContext.SaveChangesAsync();
            return result;
        }
        public void Rollback()
        {
            foreach (var dbEntityEntry in _dbFactory.DbContext.ChangeTracker.Entries())
            {
                switch (dbEntityEntry.State)
                {
                    case EntityState.Modified:
                        dbEntityEntry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        dbEntityEntry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        dbEntityEntry.State = EntityState.Unchanged;
                        break;


                }


            }
        }
        public void RollbackAsync()
        {
            foreach (var dbEntityEntry in _dbFactory.DbContext.ChangeTracker.Entries())
            {
                switch (dbEntityEntry.State)
                {
                    case EntityState.Modified:
                        dbEntityEntry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        dbEntityEntry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        dbEntityEntry.State = EntityState.Unchanged;
                        break;
                }


            }

        }

    }
}
