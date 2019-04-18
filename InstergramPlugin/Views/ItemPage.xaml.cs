using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamarinKit.Models;
using XamarinKit.ViewModels;

namespace XamarinKit.Views
{
    public partial class ItemPage : ContentPage
    {
        private ItemViewModel itemViewModel;
        private string token;
        public ItemPage(string token)
        {
            InitializeComponent();
            this.token = token;
            BindingContext = itemViewModel = new ItemViewModel();
            itemViewModel.navigation = Navigation;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadUserList();
        }

        void Handle_Refreshing(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void LoadUserList()
        {
            itemViewModel.LoadUserList(this.token);
        }
        private void RefreshData()
        {
            ItemView.IsRefreshing = false;
        }

        void ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectItem = (Service)e.SelectedItem;
            var slectedUser = new Service() { USERNAME = selectItem.USERNAME };


            itemViewModel.PageNavigation(slectedUser);
        }


        void LogOutClick(object sender, System.EventArgs e)
        {
            itemViewModel.Logout();
        }
    }
}
