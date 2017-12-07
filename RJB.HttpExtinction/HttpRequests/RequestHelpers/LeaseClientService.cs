using System;
using RJB.HttpExtinction.HttpRequests.Helpers;
using RJB.Model.Model.Leases;
using RJB.Model.ViewModel;

namespace RJB.HttpExtinction.HttpRequests.RequestHelpers
{
    public static class LeaseClientService
    {
        private static string LeasesUrl = "/api/lease/";

        public static bool CreateLease(Lease lease)
        {
            try
            {
                HttpClientHelper.PostData(lease, string.Concat(LeasesUrl, "CreateLease"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CompleateLease(Lease lease)
        {
            try
            {
                HttpClientHelper.PostData(lease, string.Concat(LeasesUrl, "CompleateLease"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Lease GetLeaseDetails(int leaseId)
        {
            try
            {
                var lease = HttpClientHelper.GetResult<Lease>(string.Concat(LeasesUrl, $"GetLeaseDetails?leaseId={leaseId}"));
                return lease;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static CollectionResult<Lease> GetLeaseOfClient(int clientId)
        {
            try
            {
                var lease = HttpClientHelper.GetResult<CollectionResult<Lease>>(string.Concat(LeasesUrl, $"GetLeaseOfClient?clientId={clientId}"));
                return lease;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
