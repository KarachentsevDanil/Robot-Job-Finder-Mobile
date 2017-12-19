using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Users;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterCompanyPage : ContentPage
    {
        public RegisterCompanyPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var company = new Company
            {
                Name = Name.Text,
                Email = Email.Text,
                Password = Password.Text
            };

            bool isSuccessed = HttpUserService.RegisterCompany(company);
            if (!isSuccessed)
            {
                RegisterFailed.IsVisible = true;
            }
            else
            {
                RegisterFailed.IsVisible = false;
                await Navigation.PopAsync();
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}