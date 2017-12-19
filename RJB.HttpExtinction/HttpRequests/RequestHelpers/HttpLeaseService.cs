using System;
using System.Collections.Generic;
using RJB.HttpExtinction.HttpRequests.Helpers;
using RJB.Model.Model.Leases;
using RJB.Model.ViewModel;

namespace RJB.HttpExtinction.HttpRequests.RequestHelpers
{
    public static class HttpLeaseService
    {
        public static bool CreateLease(Lease lease)
        {
            try
            {
                HttpClientHelper.PostData(lease, string.Concat(Constants.LeasesUrl, "CreateLease"));
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
                HttpClientHelper.PostData(lease, string.Concat(Constants.LeasesUrl, "CompleateLease"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Lease GetLeaseDetails(int leaseId)
        {
            var lease = HttpClientHelper.GetResult<Lease>(string.Concat(Constants.LeasesUrl, $"GetLeaseDetails?leaseId={leaseId}"));
            return lease;
        }

        public static List<Lease> GetLeaseOfClient(int clientId)
        {
            var lease = HttpClientHelper.GetResult<List<Lease>>(string.Concat(Constants.LeasesUrl, $"GetLeaseOfClient?clientId={clientId}"));
            return lease;
        }
    }
}
