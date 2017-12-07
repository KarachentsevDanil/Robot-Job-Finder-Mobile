using RJB.Model.Model.Leases;

namespace RJF.MobileApp.ViewModel.Leases
{
    public class LeaseDetailsViewModel: BaseCommonViewModel
    {
        public Lease Lease { get; set; }
        public LeaseDetailsViewModel(Lease lease)
        {
            Title = $"#{lease.LeaseId}";
            Lease = lease;
        }
    }
}
