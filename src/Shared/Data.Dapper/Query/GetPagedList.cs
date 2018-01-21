/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Data.Query
{
    using Dapper;

    public class GetPagedListQuery<TEntity> : SqlToPagedListQuery<TEntity>
    {
        string whereClause;
        public GetPagedListQuery(string statement, string whereClause, int index, int size) : base(statement, index, size)
        {
            this.whereClause = whereClause;
        }

        protected override void SetupParameters(DynamicParameters parameters)
        {
            parameters.Add("whereClause", whereClause );
        }
    }
}
