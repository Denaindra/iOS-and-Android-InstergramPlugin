using System;
using System.Threading.Tasks;
using XamarinKit.Models;
using XamarinKit.Utilityies;
using XamarinKit.Views;

namespace XamarinKit.ViewModels
{
    public class InstergramLoginViewModel : BaseViewModel
    {
        private string username;
        private string password;
        private LoadindIndicator indicator;
        private InstergramServices instergramServices;
        public InstergramLoginViewModel()
        {
            //Username = "pablofreitas.soares";
            //PassWord = "1679435m";
            indicator = new LoadindIndicator();
            instergramServices = new InstergramServices();
        }

        public string Username
        {

            get
            {
                return username;
            }
            set
            {

                username = value;
                NotifyPropertyChanged(nameof(Username));

            }
        }

        public string PassWord
        {

            get
            {
                return password;
            }
            set
            {

                password = value;
                NotifyPropertyChanged(nameof(PassWord));

            }
        }

        public bool FeildValidation()
        {
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(PassWord))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Authontication()
        {
            indicator.StartIndicator();
            var result = await instergramServices.UserLogin(Username, PassWord);
            if (result.Item3)
            {
                indicator.EndIndicator();

                if(result.Item4 == 0)
                {
                    await navigation.PushAsync(new CompletionPage());
                }
                else if  (result.Item4 ==  2)
                {
                    var insterUser = new InsterUserModel() { email = result.Item2, phone = result.Item1,pageRoot = result.Item4 };
                    await navigation.PushAsync(new SelecteChallengePage(insterUser));
                }
                else if(result.Item4 == 8)
                {
                    var insterUser = new InsterUserModel() { email = result.Item2, phone = result.Item1, pageRoot = result.Item4 };
                    await navigation.PushAsync(new SelecteChallengePage(insterUser));
                }
            }
            else
            {
                indicator.EndIndicator();
                return false;
            }

            return true;
        }
    }
}
