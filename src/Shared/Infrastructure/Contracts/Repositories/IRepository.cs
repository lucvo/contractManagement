/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Infrastructure.Contracts.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity:class
    {
        void Delete(TId id);
        void InsertOrUpdate(TEntity entity);
    }
}
