using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinKit.CustomRenders;
using XamarinKit.Models;
using XamarinKit.ViewModels;

namespace XamarinKit.Views
{
    public partial class SelecteChallengePage : GradientColorPage
    {
        private bool IsRadioSelected1 = true;
        private bool IsRadioSelected2;
        private InsterUserModel insterUSer;
        private ChallengeViewModel challangeViewModel;

        public SelecteChallengePage(InsterUserModel insterUser)
        {
            InitializeComponent();
            this.insterUSer = insterUser;
            BindingContext = challangeViewModel = new ChallengeViewModel();
            challangeViewModel.navigation = Navigation;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            createUIforRadioSection();
        }

        void ChnageChallange(object sender, System.EventArgs e)
        {
            if (this.IsRadioSelected1)
            {
                challangeViewModel.GetAuthonticationChallange(1,insterUSer.pageRoot); 
            }
            else if (this.IsRadioSelected2)
            {
                challangeViewModel.GetAuthonticationChallange(2, insterUSer.pageRoot);
            }
        }

        void RadioButton1(object sender, EventArgs e)
        {
            var param = Int32.Parse((e as TappedEventArgs).Parameter.ToString());

            if (param.Equals(1))
            {
                rabtn2.Source = "circleOutline.png";
                rabtn1.Source = "dotCircle.png";
                this.IsRadioSelected2 = false;
                this.IsRadioSelected1 = true;
            }
            else if (param.Equals(2))
            {
                rabtn1.Source = "circleOutline.png";
                rabtn2.Source = "dotCircle.png";
                this.IsRadioSelected1 = false;
                this.IsRadioSelected2 = true;
            }
        }

        private void createUIforRadioSection()
        {
            if(string.IsNullOrEmpty(insterUSer.phone))
            {
                stack1.IsEnabled = false;
                stack1.IsVisible = false;
            }
            if(string.IsNullOrEmpty(insterUSer.email))
            {
                stack2.IsEnabled = false;
                stack2.IsVisible = false;
            }
            else 
            {
                radio1Text.Text = insterUSer.phone;
                radio2Text.Text = insterUSer.email;
                stack1.IsVisible = true;
                stack2.IsVisible = true;
            }
        }

    }
}
