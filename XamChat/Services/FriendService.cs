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
        private IEnumerable<Friend> _friends = null;

        public async Task<IEnumerable<Friend>> GetFriends(bool useCache = false)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1));
            if (useCache && _friends != null)
            {
                return _friends;
            }

            var serializer = new JsonSerializer();
            using (var stream = typeof(FriendService).GetTypeInfo().Assembly.GetManifestResourceStream("XamChat.Core.Resources.data.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var jsonTextReader = new JsonTextReader(reader))
                    {
                        IEnumerable<Friend> friends = serializer.Deserialize<IEnumerable<Friend>>(jsonTextReader);
                        return friends;
                    }
                }
            }
        }

        public async Task<Friend> Get(Guid friendId)
        {
            IEnumerable<Friend> friends = await GetFriends(true);
            if (friends != null)
            {
                return friends.FirstOrDefault(x => x.Id == friendId);
            }
            else
            {
                throw  new Exception("Friends not existent!");
            }
        }
    }
}
