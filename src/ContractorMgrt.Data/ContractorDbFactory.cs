

namespace ContractorMgrt.DataAccess
{
    using Infrastructure;
    using Infrastructure.Contracts;
    using System.Data;

    public class ContractorDbFactory : DataBase, IDatabase
    {
        public ContractorDbFactory(string connectionString) : base(connectionString)
        {
        }
    }
}
