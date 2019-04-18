using System;
using Android.App;
using Xamarin.Forms;
using XamarinKit.Droid.Utility;
using XamarinKit.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(AppClose))]
namespace XamarinKit.Droid.Utility
{
    public class AppClose: IAppClose
    {
        public AppClose()
        {
        }

        public void CloseApplication()
        {
            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
        }
    }
}
