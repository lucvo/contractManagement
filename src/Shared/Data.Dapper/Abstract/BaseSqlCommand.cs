/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Data
{
    using Infrastructure.Contracts;
    using Dapper;
    using System.Data;
    public abstract class BaseSqlCommand 
    {
        protected string Sql { get; private set; }
        protected BaseSqlCommand(string sql)
        {
            this.Sql = sql;
        }
        protected abstract void SetupParameters(DynamicParameters parameters);

        public int Handle(IDbContext dbContext)
        {
            var parameters = new DynamicParameters();
            SetupParameters(parameters);
            return dbContext.Execute(Sql, parameters, CommandType.StoredProcedure);
        }
    }
}
