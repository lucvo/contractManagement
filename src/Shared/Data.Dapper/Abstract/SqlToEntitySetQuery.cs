/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Data
{
    using Infrastructure.Contracts;
    using System.Collections.Generic;
    using Dapper;
    using System.Data;
    public abstract class SqlToEntitySetQuery<T> : BaseSqlQuery
    {
        protected SqlToEntitySetQuery(string statement) : base(statement)
        {
        }

        public IEnumerable<T> Handle(IDbContext dbContext)
        {
            var parameters = new DynamicParameters();
            SetupParameters(parameters);

            return dbContext.EntitySet<T>(Sql, parameters, CommandType.StoredProcedure);
        }
    }
}
