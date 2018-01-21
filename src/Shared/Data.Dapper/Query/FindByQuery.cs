/// <summary>
/// 
/// </summary>
namespace Data.Query
{
    using Data;
    using Dapper;
    public class FindByQuery<TEntity>: SqlToEntityQuery<TEntity>
    {
        string columnName;
        object columnValue;
        public FindByQuery(string columnName, object columnValue, string statement)
            : base(statement)
        {
            this.columnName = columnName;
            this.columnValue = columnValue;
        }

        protected override void SetupParameters(DynamicParameters parameters)
        {
            parameters.AddDynamicParams(new{ columnName, columnValue});
        }
    }
}
