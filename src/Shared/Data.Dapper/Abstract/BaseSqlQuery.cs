/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Data
{
    using Dapper;

    public abstract class BaseSqlQuery{
        protected string Sql { get; private set; }
        protected BaseSqlQuery(string sql)
        {
            this.Sql = sql;
        }
        protected abstract void SetupParameters(DynamicParameters parameters);
    }
}
