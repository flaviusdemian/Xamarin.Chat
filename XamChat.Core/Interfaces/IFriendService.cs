using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamChat.Core.Models;

namespace XamChat.Core.Interfaces
{
    public interface IFriendService
    {
        Task<IEnumerable<Friend>> GetFriends(bool useCache);

        Task<Friend> Get(Guid friendId);
    }
}
