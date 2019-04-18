using System;
using System.Threading.Tasks;
using SocialgramConector.Model;
using SocialgramLibraryApp.mgp25;
namespace XamarinKit.Utilityies
{
    public class UserLoginServices
    {
     
        public UserLoginServices()
        {
        }

        public async Task<Tuple<string, bool>> UserLogin(string userName,String passwrod)
        {
            ValidateUser result = await iPost.ValidateLoginAsync(userName, passwrod);
            
            if(result.status.Equals("ok"))
            {
                return new Tuple<string, bool>(result.key, true);
            }
            return new Tuple<string, bool>(string.Empty,false);
        }
    }

}
