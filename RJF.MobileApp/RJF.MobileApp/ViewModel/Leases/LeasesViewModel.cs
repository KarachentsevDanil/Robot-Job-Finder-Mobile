using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Leases;
using RJF.MobileApp.Pages.Leases;
using Xamarin.Forms;

namespace RJF.MobileApp.ViewModel.Leases
{
    public class LeasesViewModel: BaseCommonViewModel
    {
        public ObservableCollection<Lease> Leases { get; set; }
        public Command LoadLeasesCommand { get; set; }

        public LeasesViewModel()
        {
            Title = "My Leases";
            Leases = new ObservableCollection<Lease>();
            LoadLeasesCommand = new Command(ExecuteLoadItemsCommand);

            MessagingCenter.Subscribe<AddLease, Lease>(this, "AddLease", (obj, item) =>
            {
                RefreshData();
            });
        }

        public void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RefreshData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void RefreshData()
        {
            Leases.Clear();

            var leases = LeaseClientService.GetLeaseOfClient(CurrentUser.CurrentUserModel.UserId).Collection;
            foreach (var lease in leases)
            {
                if (Leases.All(x => x.LeaseId != lease.LeaseId))
                {
                    Leases.Add(lease);
                }
            }
        }
    }
}
