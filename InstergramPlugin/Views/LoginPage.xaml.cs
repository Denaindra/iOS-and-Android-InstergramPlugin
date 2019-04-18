using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinKit.Constant;
using XamarinKit.ViewModels;

namespace XamarinKit.Views
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel loginViewmodel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = loginViewmodel = new LoginViewModel();
            loginViewmodel.navigation = Navigation;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }
       async void LoginClicked(object sender, System.EventArgs e)
        {

            if (loginViewmodel.FeildValidation())
            {
                erroMsg.TextColor = Color.Red;
                DisplayMessage();
            }
            else
            {
                if (! await loginViewmodel.AuthonticationAsync())
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

       private void EntryUnfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            loginGrid.TranslateTo(0, 0, 400, Easing.SinIn);
        }


    }
}
