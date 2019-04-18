using System;
using System.Threading.Tasks;
using XamarinKit.Utilityies;
using XamarinKit.Utilityies.Services;
using XamarinKit.Views;

namespace XamarinKit.ViewModels
{
    public class ChallengeViewModel : BaseViewModel
    {
        private ChallengeServices challangeServices;
        private LoadindIndicator indicator;

        public ChallengeViewModel()
        {
            challangeServices = new ChallengeServices();
            indicator = LoadindIndicator.Indicator;

        }

        public async void GetAuthonticationChallange(int id,int rootPage)
        {
            indicator.StartIndicator();
            var challnageResult = await challangeServices.GetChallange(id);

            if(challnageResult)
            {
               await navigation.PushAsync(new InstergramVeryfiyCode(rootPage));
            }
            else
            {
            
            }
            indicator.EndIndicator();

        }
    }
}
