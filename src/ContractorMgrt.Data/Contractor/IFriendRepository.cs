namespace ContractorMgrt.DataAccess
{
    using Infrastructure.Contracts.Repositories;
    using ContractorMgrt.Models;
    public interface IFriendRepository: 
        IReadRepository<Friend, int>,
        IRepository<Friend, int>
    {
    }
}
