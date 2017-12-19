using System;
using System.Collections.Generic;
using RJB.HttpExtinction.HttpRequests.Helpers;
using RJB.Model.Model.Specializations;

namespace RJB.HttpExtinction.HttpRequests.RequestHelpers
{
    public static class HttpSpecializationService
    {
        public static bool AddSpecialization(Specialization specialization)
        {
            try
            {
                HttpClientHelper.PostData(specialization, string.Concat(Constants.SpecializationUrl, "AddSpecialization"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<Specialization> GetAllSpecializations()
        {
            var specializations = HttpClientHelper.GetResult<List<Specialization>>(string.Concat(Constants.SpecializationUrl, "GetAllSpecializations"));
            return specializations;
        }
    }
}
