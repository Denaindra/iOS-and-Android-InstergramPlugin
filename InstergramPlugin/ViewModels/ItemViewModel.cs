using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using XamarinKit.Models;
using XamarinKit.Utilityies;
using XamarinKit.Utilityies.Services;
using XamarinKit.Views;

namespace XamarinKit.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        private ObservableCollection<Service> menue;
        private PropertiesDictionary appProperty;
        private LoadindIndicator indicator;
        private bool isEmptyList;
        private UserDetailSerivces userDetailsServices;
        public ItemViewModel()
        {
            menue = new ObservableCollection<Service>();
            indicator = new LoadindIndicator();
            appProperty = PropertiesDictionary.PropertyInstants;
            userDetailsServices = new UserDetailSerivces();
        }

        public async void LoadUserList(string token)
        {
            indicator.StartIndicator();
            Menue.Clear();
            var userList = await userDetailsServices.GetFriendsList(token);

            
            FriendListResponseModel friendResponsModel = JsonConvert.DeserializeObject<FriendListResponseModel>(userList);

            if (friendResponsModel.status.Equals("ok"))
            {
                if (!friendResponsModel.services.Any())
                {
                    IsEmptyList = true;
                }
                else
                {
                    foreach (var user in friendResponsModel.services)
                    {

                        menue.Add(new Service() { USERNAME = user.USERNAME, PICTURE_URL = user.PICTURE_URL });
                    }

                    IsEmptyList = false;
                }
            }

            indicator.EndIndicator();
        }

        public void PageNavigation(Service selectedUser)
        {
            navigation.PushAsync(new InstergramLogin(selectedUser));
        }

        public ObservableCollection<Service> Menue
        {
            get
            {
                return menue;
            }
            set
            {
                menue = value;
                NotifyPropertyChanged(nameof(Menue));
            }
        }
        public bool IsEmptyList
        {
            get
            {
                return isEmptyList;
            }
            set
            {
                isEmptyList = value;
                NotifyPropertyChanged(nameof(IsEmptyList));
            }
        }
        public void removeUserFromApp()
        {
            appProperty.Removeproperty(loginUser);
        }


        public void Logout()
        {
            navigation.PopAsync();
        }

    }
}
