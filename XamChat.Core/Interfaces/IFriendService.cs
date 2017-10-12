using System;
using System.Collections.Generic;
using XamChat.Core.Models;

namespace XamChat.Core.Interfaces
{
    public interface IFriendService
    {
        IEnumerable<Friend> GetFriends(bool useCache);

        Friend Get(Guid friendId);
    }
}
