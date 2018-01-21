/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-Jan-2018
/// </summary>
namespace Data.Command
{
    using Data;
    using Dapper;
    using System.Data.Common;

    public class SaveOrUpdateCommand : BaseSqlCommand
    {
        DbParameter[] dbParameters;
        public SaveOrUpdateCommand(string statement, params DbParameter[] parameters) : base(statement)
        {
            this.dbParameters = parameters;
        }

        protected override void SetupParameters(DynamicParameters parameters)
        {
            foreach(DbParameter parameter in dbParameters)
            {
                parameters.Add(parameter.ParameterName, parameter.Value);
            }
        }
    }
}
