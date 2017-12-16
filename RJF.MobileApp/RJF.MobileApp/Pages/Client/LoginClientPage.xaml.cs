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

            var userViewModel = UserClientService.ClientLogin(loginModel);
            if (userViewModel == null)
            {
                LoginInfo.IsVisible = true;
            }
            else
            {
                LoginInfo.IsVisible = false;
                CurrentUser.CurrentUserModel = userViewModel;
                HttpClientHelper.User = userViewModel;

                await Navigation.PushModalAsync(new ClientMainLayoutPage());
            }
        }

        private async void ReginstrationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterClientPage());
        }
    }
}