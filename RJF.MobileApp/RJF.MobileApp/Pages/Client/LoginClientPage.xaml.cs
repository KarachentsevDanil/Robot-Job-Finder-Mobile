using System;
using RJB.HttpExtinction.HttpRequests.Helpers;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.ViewModel;
using RJF.MobileApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RJF.MobileApp.Pages.Layouts;

namespace RJF.MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginClientPage : ContentPage
    {
        public LoginClientPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var loginModel = new UserLoginModel
            {
                UserName = Username.Text,
                Password = Password.Text
            };

            var userViewModel = HttpUserService.ClientLogin(loginModel);
            if (userViewModel == null)
            {
                LoginInfo.IsVisible = true;
            }
            else
            {
                ClearForm();
                CurrentUser.CurrentUserModel = userViewModel;
                HttpClientHelper.User = userViewModel;

                await Navigation.PushModalAsync(new ClientMainLayoutPage());
            }
        }

        private void ClearForm()
        {
            LoginInfo.IsVisible = false;
            Username.Text = string.Empty;
            Password.Text = string.Empty;
        }

        private async void ReginstrationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterClientPage());
        }
    }
}