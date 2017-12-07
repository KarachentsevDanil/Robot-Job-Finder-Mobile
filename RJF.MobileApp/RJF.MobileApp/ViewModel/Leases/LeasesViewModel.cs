using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Leases;
using RJB.Model.Model.Robots;
using RJF.MobileApp.Pages.Leases;
using Xamarin.Forms;

namespace RJF.MobileApp.ViewModel.Leases
{
    public class LeasesViewModel: BaseCommonViewModel
    {
        public List<Lease> Leases { get; set; }
        public Command LoadLeasesCommand { get; set; }

        public LeasesViewModel()
        {
            Title = "My Leases";
            Leases = new List<Lease>();
            LoadLeasesCommand = new Command(ExecuteLoadItemsCommand);

            MessagingCenter.Subscribe<AddLease, Lease>(this, "AddLease", (obj, item) =>
            {
                Leases = LeaseClientService.GetLeaseOfClient(CurrentUser.CurrentUserModel.UserId).Collection.ToList();
            });
        }

        public void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Leases.Clear();
                Leases = LeaseClientService.GetLeaseOfClient(CurrentUser.CurrentUserModel.UserId).Collection.ToList();
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
    }
}
