using System;
using System.Threading;
using XamarinKit.Interfaces;
using XamarinKit.iOS.Utility;

[assembly: Xamarin.Forms.Dependency(typeof(AppClose))]
namespace XamarinKit.iOS.Utility
{
    public class AppClose: IAppClose
    {
        public AppClose()
        {
        }

        public void CloseApplication()
        {
            Thread.CurrentThread.Abort();
        }

    }
}
