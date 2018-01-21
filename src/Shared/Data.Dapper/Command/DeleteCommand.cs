/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-Jan-2018
/// </summary>
namespace Data.Command
{
    using Data;
    using Dapper;
    public class DeleteCommand : BaseSqlCommand
    {
        object id;
        public DeleteCommand(string statement, object id) 
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
