using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamChat.Core.Interfaces;
using XamChat.Core.Models;

namespace XamChat.Core.Services
{
    public class FriendService : IFriendService
    {
        #region private fields

        private IEnumerable<Friend> mFriends;

        #endregion

        public IEnumerable<Friend> GetFriends(bool useCache = false)
        {
            if (useCache && mFriends != null)
            {
                return mFriends;
            }

            using (var stream = typeof(FriendService).GetTypeInfo().Assembly.
                   GetManifestResourceStream("XamChat.Core.Resources.data.json"))
            using (var reader = new StreamReader(stream))
            {
                var content = reader.ReadToEnd();
                mFriends = JsonConvert.DeserializeObject<IEnumerable<Friend>>(content);
                return mFriends;
            }
        }

        public Friend Get(Guid friendId)
        {
            var friends = GetFriends(true);
            if (friends != null && friends.Any())
            {
                return friends.FirstOrDefault(friend => friend.Id == friendId);
            }
            throw  new Exception("Friends not existent!");
        }
    }
}
