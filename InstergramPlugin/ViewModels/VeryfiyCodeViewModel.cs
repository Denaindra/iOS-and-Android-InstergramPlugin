using System;
using System.Threading.Tasks;
using XamarinKit.Utilityies;
using XamarinKit.Utilityies.Services;
using XamarinKit.Views;

namespace XamarinKit.ViewModels
{
    public class VeryfiyCodeViewModel : BaseViewModel
    {
        private VerifyCodeServices verifyService;
        private LoadindIndicator indicator;
        private int rootPage { get; set; }
        public string verifyCode { get; set; }

        public VeryfiyCodeViewModel()
        {
            verifyService = new VerifyCodeServices();
            indicator = new LoadindIndicator();
        }

        public int RootPage
        {
            get
            {
                return rootPage;
            }
            set
            {
                rootPage = value;
                NotifyPropertyChanged(nameof(RootPage));

            }
        }

        public string VerifyCode
        {
            get
            {
                return verifyCode;
            }
            set
            {
                verifyCode = value;
                NotifyPropertyChanged(nameof(VerifyCode));
            }
        }

        public async Task<bool> VerfyCode()
        {
            bool verifyStatus = false;
            indicator.StartIndicator();
            if (RootPage == 2)
            {
                verifyStatus = await verifyService.GetVerifyCodeServices(VerifyCode);
            }
            else if (RootPage == 8)
            {
                verifyStatus = await verifyService.GetVerifyCodeTwofactorAuthontication(VerifyCode);
            }

            if (!verifyStatus)
            {
                indicator.EndIndicator();
                return false;
            }
            indicator.EndIndicator();
            await navigation.PushAsync(new CompletionPage());
            return true;
        }

        public bool FeildValidation()
        {
            if (string.IsNullOrEmpty(VerifyCode))
            {
                return true;
            }
            return false;
        }
    }
}
