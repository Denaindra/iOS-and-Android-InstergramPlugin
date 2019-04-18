using System;
using System.Threading.Tasks;
using SocialgramLibraryApp.mgp25;

namespace XamarinKit.Utilityies.Services
{
    public class UserDetailSerivces
    {
        public UserDetailSerivces()
        {
        }

        public async Task<string> GetFriendsList(string token)
        {
            return await iPost.GetServicesAsync(token);
        }

    }
}
