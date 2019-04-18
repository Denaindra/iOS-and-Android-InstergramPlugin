using System;
using System.Threading.Tasks;
using InstagramApiSharp.Classes;

namespace XamarinKit.Utilityies.Services
{
    public class ChallengeServices
    {
        public ChallengeServices()
        {
        }

        public async Task<bool> GetChallange(int formChallange)
        {
            var result = await  SocialgramLibraryApp.Instagram.Authentication.HandleSelectChallengeAsync(formChallange);

            if(result.LoginResult == InstaLoginResult.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
