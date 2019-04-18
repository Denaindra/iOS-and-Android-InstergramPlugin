using System;
using System.Threading.Tasks;
using InstagramApiSharp.Classes;
using XamarinKit.Constant;

namespace XamarinKit.Utilityies
{
    public class InstergramServices
    {
        public InstergramServices()
        {
        }

        public async Task<Tuple<string,string,bool,int>> UserLogin(string userName, String passwrod)
        {
            var result =await SocialgramLibraryApp.Instagram.Authentication.LoginAsync(userName,passwrod);

            if(result.LoginResult == InstaLoginResult.ChallengeRequired)
            {
                return new Tuple<string, string, bool,int>(result.phone, result.email, true, (int)AppConstant.InstaLoginResult.ChallengeRequired);
            }
            if (result.LoginResult == InstaLoginResult.Success)
            {
                return new Tuple<string, string, bool,int>(result.phone, result.email, true, (int)AppConstant.InstaLoginResult.Success);
            }
            if (result.LoginResult == InstaLoginResult.TwoFactorRequired)
            {
                return new Tuple<string, string, bool, int>(result.phone, result.email, true, (int)AppConstant.InstaLoginResult.TwoFactorRequired);
            }
            return new Tuple<string,string, bool,int>(string.Empty,string.Empty,false,(int)AppConstant.InstaLoginResult.Exception);
        }
    }
}
