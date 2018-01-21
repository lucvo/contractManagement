/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Infrastructure.Contracts
{
    using System.Collections.Generic;
    using System.Data;
    public interface IDbContext
    {
        IEnumerable<T> EntitySet<T>(string query, object param = null, CommandType commandType = CommandType.Text);
        int Execute(string sql, object param = null, CommandType commandType = CommandType.Text);
    }
}
