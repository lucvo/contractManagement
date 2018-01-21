/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-Jan-2018
/// </summary>
namespace Data.Query
{
    using Dapper;
    using Data;
    public class GetListQuery<TEntity> : SqlToEntitySetQuery<TEntity>
    {
        public GetListQuery(string statement)
            : base(statement)
        {
        }

        protected override void SetupParameters(DynamicParameters parameters)
        {
        }
    }
}
