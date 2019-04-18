using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinKit.CustomRenders;
using XamarinKit.Models;
using XamarinKit.ViewModels;

namespace XamarinKit.Views
{
    public partial class InstergramLogin : GradientColorPage
    {
        private InstergramLoginViewModel instergramLogin;
        public InstergramLogin()
        {
            InitializeComponent();
     
        }
        public InstergramLogin(Service selectUser)
        {
            InitializeComponent();
            BindingContext = instergramLogin = new InstergramLoginViewModel();
            instergramLogin.navigation = Navigation;
            instergramLogin.Username = selectUser.USERNAME;
        }

        public async void LoginClicked(object sender, System.EventArgs e)
        {
            if (instergramLogin.FeildValidation())
            {
                erroMsg.TextColor = Color.Red;
                DisplayMessage();
            }
            else
            {
                if (!await instergramLogin.Authontication())
                {
                    erroMsg.TextColor = Color.Red;
                    DisplayMessage();
                }
            }

        }

        private void DisplayMessage()
        {
            DisplayAlert("Login", "Please check Username and Password", "OK");
        }

        private void EntryFocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            erroMsg.TextColor = Color.Transparent;
            loginGrid.TranslateTo(0, -40, 400, Easing.SinIn);
        }

        private void EntrUnFocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            loginGrid.TranslateTo(0,0, 400, Easing.SinIn);
        }
    }
}
