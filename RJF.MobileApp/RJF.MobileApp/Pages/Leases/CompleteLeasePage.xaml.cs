using System;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Leases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp.Pages.Leases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompleteLease : ContentPage
    {
        public Lease Lease { get; set; }

        public CompleteLease()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public CompleteLease(Lease lease)
        {
            InitializeComponent();
            Lease = lease;
            BindingContext = this;
        }

        private async void CompleteButton_Clicked(object sender, EventArgs e)
        {
            RJB.Model.Model.Robots.Rating rating;
            Enum.TryParse(Rating.SelectedItem.ToString(), true, out rating);

            Lease.Rating = rating;
            Lease.Feedback = Feedback.Text;

            var isSuccess = LeaseClientService.CompleateLease(Lease);
            if (isSuccess)
            {
                await DisplayAlert("Info", "Lease successfully complete.", "Ok");
                MessagingCenter.Send(this, "AddLease", Lease);
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Info", "Error occure when lease completing. Try again.", "Ok");
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}