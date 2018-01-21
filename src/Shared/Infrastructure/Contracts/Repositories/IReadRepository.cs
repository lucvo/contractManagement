/// <summary>
/// Created by: Luc.Vo
/// Created date: 01-April-2015
/// </summary>
namespace Infrastructure.Contracts.Repositories
{
    using System.Collections.Generic;
    public interface IReadRepository<TEntity, TId> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TId id);
    }
}
