/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>

namespace Data
{
    using Infrastructure.Contracts;
    using System.Linq;
    using Dapper;
    using System.Data;
    public abstract class SqlToEntityQuery<T> :  BaseSqlQuery
    {
        public SqlToEntityQuery(string statement):base(statement)
        {
        }

        public T Handle(IDbContext context)
        {
            var parameters = new DynamicParameters();
            SetupParameters(parameters);

            T data = context.EntitySet<T>(Sql, parameters, CommandType.StoredProcedure).FirstOrDefault();
            return data;
        }
    }
}
