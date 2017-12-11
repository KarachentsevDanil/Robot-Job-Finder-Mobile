using System;
using RJF.MobileApp.ViewModel.Leases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp.Pages.Leases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaseDetails : ContentPage
    {
        private LeaseDetailsViewModel _model;

        public LeaseDetails()
        {
            InitializeComponent();
        }

        public LeaseDetails(LeaseDetailsViewModel leaseDetailsViewModel)
        {
            InitializeComponent();
            _model = leaseDetailsViewModel;
            BindingContext = _model;
        }

        private async void CompleteLeaseButton_Clicked(object sender, EventArgs e)
        {
            var isComplete = _model.Lease.Rating.HasValue;
            if (isComplete)
            {
                await DisplayAlert("Info", "Lease already completed!", "Ok");
            }
            else
            {
                await Navigation.PushModalAsync(new CompleteLease(_model.Lease));
            }
        }
    }
}