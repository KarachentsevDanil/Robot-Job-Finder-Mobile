using System;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Leases;
using RJB.Model.Model.Robots;
using RJF.MobileApp.ViewModel.Leases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp.Pages.Leases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompleteLease : ContentPage
    {
        public Lease Lease { get; set; }
        public LeaseDetails LeaseDetails { get; set; }

        public CompleteLease()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public CompleteLease(Lease lease, LeaseDetails leaseDetails)
        {
            InitializeComponent();
            Lease = lease;
            LeaseDetails = leaseDetails;
            BindingContext = this;
        }

        private async void CompleteButton_Clicked(object sender, EventArgs e)
        {
            Enum.TryParse(Rating.SelectedItem.ToString(), true, out Rating rating);

            Lease.Rating = rating;
            Lease.Feedback = Feedback.Text;

            var isSuccess = HttpLeaseService.CompleateLease(Lease);
            LeaseDetails.LeaseDetailsViewModel.Lease = HttpLeaseService.GetLeaseDetails(Lease.LeaseId);

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