/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>

namespace Data
{
    using Infrastructure.Contracts;
    using Dapper;
    using System.Data;
    using System.Collections.Generic;

    public abstract class SqlToPagedListQuery<T>: BaseSqlQuery
    {
        public SqlToPagedListQuery(string statement, int index, int size):base(statement)
        {
            PageNo = index;
            PageSize = size;
            TotalRow = 0;
        }

        protected int PageNo { get; private set; }
        protected int PageSize { get; private set; }
        public int TotalRow { get; private set; }

        public IEnumerable<T> Handle(IDbContext dbContext)
        {
            var parameters = new DynamicParameters();

            SetupParameters(parameters);

            parameters.Add(@"pageNo", PageNo);
            parameters.Add(@"pageSize", PageSize);
            parameters.Add(@"out", 0, DbType.Int32, ParameterDirection.Output);

            var data = dbContext.EntitySet<T>(Sql, parameters, CommandType.StoredProcedure);

            TotalRow = parameters.Get<int>("out");

            return data;
        }
    }
}
