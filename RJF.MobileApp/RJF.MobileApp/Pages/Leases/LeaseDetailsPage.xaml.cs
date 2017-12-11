using System;
using RJF.MobileApp.ViewModel.Leases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp.Pages.Leases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaseDetails : ContentPage
    {
        public LeaseDetailsViewModel LeaseDetailsViewModel;

        public LeaseDetails()
        {
            InitializeComponent();
        }

        public LeaseDetails(LeaseDetailsViewModel leaseDetailsViewLeaseDetailsViewModel)
        {
            InitializeComponent();
            LeaseDetailsViewModel = leaseDetailsViewLeaseDetailsViewModel;
            BindingContext = LeaseDetailsViewModel;
        }

        private async void CompleteLeaseButton_Clicked(object sender, EventArgs e)
        {
            var isComplete = LeaseDetailsViewModel.Lease.Rating.HasValue;
            if (isComplete)
            {
                await DisplayAlert("Info", "Lease already completed!", "Ok");
            }
            else
            {
                await Navigation.PushModalAsync(new CompleteLease(LeaseDetailsViewModel.Lease, this));
            }
        }
    }
}