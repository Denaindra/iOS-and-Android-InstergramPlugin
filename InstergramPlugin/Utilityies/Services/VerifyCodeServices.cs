using System;
using System.Threading.Tasks;
using InstagramApiSharp.Classes;
using SocialgramLibraryApp.Instagram;

namespace XamarinKit.Utilityies.Services
{
    public class VerifyCodeServices
    {
        public VerifyCodeServices()
        {
        }

        public async Task<bool> GetVerifyCodeServices(string code)
        {
            var result = await Authentication.SubmitChallengeAsync(code);

            if (result.LoginResult == InstaLoginResult.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> GetVerifyCodeTwofactorAuthontication(string code)
        {
            var result = await Authentication.HandleInputTwoFactorAsync(code);
            if (result.LoginResult == InstaLoginResult.Success)
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
