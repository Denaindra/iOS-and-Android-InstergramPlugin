using System;
using System.Threading.Tasks;
using XamarinKit.Constant;
using XamarinKit.Utilityies;
using XamarinKit.Views;

namespace XamarinKit.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private PropertiesDictionary propertyContext;
        private UserLoginServices services;
        private InstergramServices instergramServices;
        private LoadindIndicator indicator;
        
        public LoginViewModel()
        {
            propertyContext = new PropertiesDictionary();
            services = new UserLoginServices();
            instergramServices = new InstergramServices();
            indicator = LoadindIndicator.Indicator;
            //Username = "marcos@mrladeia.com";
            //Password = "010203";
        }

      
        public string username;
        public string password;


        public string Username
        {

            get {
                return username;
            }

            set {

                username = value;
                NotifyPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                NotifyPropertyChanged(nameof(Password));
            }
        }

        public async Task<bool> AuthonticationAsync() 
        {
            indicator.StartIndicator();
            var result = await services.UserLogin(Username, Password);
            if (result.Item2)
            {
                indicator.EndIndicator();
               await navigation.PushAsync(new ItemPage(result.Item1));
            }
            else
            {
                indicator.EndIndicator();
                return false;
            }

            return true;
        }

        public bool FeildValidation()
        {
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password))
            {
                return true;
            }

            return false;
        }

    }
}
