

namespace ContractorMgrt.Business
{
    using ContractorMgrt.Models;
    using Infrastructure.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class LookupDataService : IFriendLookupService
    {
        IDbContext dbContext;

        public LookupDataService(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<LookupItem> GetFriendLookupAsync()
        {
            return dbContext.EntitySet<Friend>("select Id, FirstName, LastName from Friend")
                .Select(
                    f=> new LookupItem
                            {
                                Id = f.Id,
                                DisplayMember = $"{f.FirstName} {f.LastName}"
                            }
                );
        }
    }
}
