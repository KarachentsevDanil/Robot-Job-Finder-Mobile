﻿using System;
using RJF.MobileApp.HttpRequests.Helpers;
using RJF.MobileApp.Model.Leases;
using RJF.MobileApp.ViewModel;

namespace RJF.MobileApp.HttpRequests.RequestHelpers
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

        public static bool CompleateLease(LeaseViewModel lease)
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

        public static LeaseModel GetLeaseDetails(int leaseId)
        {
            try
            {
                var lease = HttpClientHelper.GetResult<LeaseModel>(string.Concat(LeasesUrl, $"GetLeaseDetails?leaseId={leaseId}"));
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
