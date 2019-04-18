using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using XamarinKit.Interfaces;

namespace XamarinKit.Views
{
    public partial class CompletionPage : ContentPage
    {
        public CompletionPage()
        {
            InitializeComponent();
        }

        void CloseClicked(object sender, System.EventArgs e)
        {
            DependencyService.Get<IAppClose>().CloseApplication();
        }
    }
}
