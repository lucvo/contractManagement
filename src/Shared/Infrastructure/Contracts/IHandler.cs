/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Infrastructure.Contracts
{
    using System.Data;
    public interface IHandler
    {
        T Execute<T>(string sql, object param = null, CommandType commandType = CommandType.Text);
    }
}
