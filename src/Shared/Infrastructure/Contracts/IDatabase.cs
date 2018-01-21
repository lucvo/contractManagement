/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Infrastructure.Contracts
{
    using System;
    using System.Data;
    public interface IDatabase : IDisposable
    {
        IDbConnection Connection { get; }
        T Transaction<T>(Func<IDbTransaction, T> query);
        IDbTransaction BeginTransaction();
        void Commit();
        void Rollback();
    }
}
