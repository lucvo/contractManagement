/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Data.Query
{
    using Data;
    using Dapper;
    public class GetByIdQuery<TEntity> : SqlToEntityQuery<TEntity>
    {
        int id;
        public GetByIdQuery(string statement, int id)
            : base(statement)
        {
            this.id = id;
        }

        protected override void SetupParameters(DynamicParameters parameters)
        {
            parameters.Add("@id", id);
        }
    }
}
