using System.Collections.Generic;
using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrginizer.UI.Data.Lookups
{
    public interface IFriendLookUpDataService
    {
        Task<IEnumerable<LookUpItem>> GetFriendLookUpAsync();
    }
}