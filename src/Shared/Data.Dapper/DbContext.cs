/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Data
{
    using Infrastructure.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Dapper;
    public class DbContext : IDbContext
    {
        IDatabase database;

        public DbContext(IDatabase database)
        {
            this.database = database;
        }

        public int Execute(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            return database.Transaction(
                transaction => database
                    .Connection
                    .Execute(sql, param, transaction, commandType: commandType));
        }

        public IEnumerable<T> EntitySet<T>(string sql, object param = null, CommandType commandType = CommandType.Text)
        {
            return database.Transaction(
                transaction => database
                    .Connection
                    .Query<T>(sql, param, transaction, commandType: commandType));
        }
    }
}
