/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Data
{
    using System.Collections.Generic;
    using System.Data.Common;
    using Infrastructure.Contracts;
    using Data.Query;
    using Data.Command;

    public class GenericRepository<TEntity, TId>
    {
        protected IDbContext DbContext { get; private set; }
        protected string EntityName { get; private set; }
        protected GenericRepository(IDbContext dbContext, string entityName)
        {
            this.DbContext = dbContext;
            this.EntityName = entityName;
        }
        public TEntity GetById(int id)
        {
            var query = new GetByIdQuery<TEntity>($"sp{EntityName}GetById", id);
            return query.Handle(DbContext);
        }
        public IEnumerable<TEntity> GetAll()
        {
            var query = new GetListQuery<TEntity>($"sp{EntityName}GetList");
            return query.Handle(DbContext);
        }
        public void Delete(TId id)
        {
            var command = new DeleteCommand($"sp{EntityName}Delete", id);
            command.Handle(DbContext);
        }
        protected IEnumerable<TEntity> FindBy(string whereClause, int index, int size, out int total)
        {
            total = 0;
            var query = new GetPagedListQuery<TEntity>($"sp{EntityName}GetPage", whereClause, index, size);
            var result = query.Handle(DbContext);
            total = query.TotalRow;
            return result;
        }
        protected int Insert(params DbParameter[] parameters)
        {
            var command = new SaveOrUpdateCommand($"sp{EntityName}Insert", parameters);
            return command.Handle(DbContext);
        }
        protected int Update(params DbParameter[] parameters)
        {
            var command = new SaveOrUpdateCommand($"sp{EntityName}Update", parameters);
            return command.Handle(DbContext);
        }
    }
}
