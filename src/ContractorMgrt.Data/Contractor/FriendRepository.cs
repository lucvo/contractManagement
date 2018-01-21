namespace ContractorMgrt.DataAccess
{
    using System.Data.SqlClient;
    using Infrastructure.Contracts;
    using ContractorMgrt.Models;
    public class FriendRepository :
        Data.GenericRepository<Friend, int>,
        IFriendRepository
    {
        public FriendRepository(IDbContext dbContext)
            : base(dbContext, "Contractor")
        {
        }

        public void InsertOrUpdate(Friend entity)
        {
            if(entity.Id != 0)
            {
                Update(
                    new SqlParameter("id", entity.Id), 
                    new SqlParameter("firstName", entity.FirstName), 
                    new SqlParameter("lastName", entity.LastName), 
                    new SqlParameter("email", entity.Email));
            }
            else
            {
                Insert(
                    new SqlParameter("firstName", entity.FirstName), 
                    new SqlParameter("lastName", entity.LastName), 
                    new SqlParameter("email", entity.Email));
            }
        }
    }
}
