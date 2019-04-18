using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XamarinKit.ViewModels
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public INavigation navigation;
        public const string loginUser = "loggedUser";
        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
