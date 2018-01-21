

namespace ContractorMgrt.Business
{
    using ContractorMgrt.Models;
    using System.Collections.Generic;
    public interface IFriendLookupService
    {
        IEnumerable<LookupItem> GetFriendLookupAsync();
    }
}
