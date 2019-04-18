using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinKit.CustomRenders;
using XamarinKit.ViewModels;

namespace XamarinKit.Views
{
    public partial class InstergramVeryfiyCode : GradientColorPage
    {
        private VeryfiyCodeViewModel verfyViewmodel;
        public InstergramVeryfiyCode(int rootPage)
        {
            InitializeComponent();
          
            BindingContext = verfyViewmodel = new VeryfiyCodeViewModel();
            verfyViewmodel.navigation = Navigation;
            verfyViewmodel.RootPage = rootPage;
        }

        async void VerifyCode(object sender, System.EventArgs e)
        {
            if (verfyViewmodel.FeildValidation())
            {
                erroMsg.TextColor = Color.Red;
                await DisplayAlert("Verification", "Please enter valide code", "OK");
            }
            else
            {
                if (! await verfyViewmodel.VerfyCode())
                {
                    erroMsg.TextColor = Color.Red;
                    await DisplayAlert("Invalid", "Please enter valide code", "OK");
                }
            }

        }

        void EntryFocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            erroMsg.TextColor = Color.Transparent;
            loginGrid.TranslateTo(0, -40, 400, Easing.SinIn);
        }
        void EntryUnFocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            loginGrid.TranslateTo(0, 0, 400, Easing.SinIn);
        }
    }
}
