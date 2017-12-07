﻿using System;
using System.Collections.Generic;
using System.Linq;
using RJB.HttpExtinction.HttpRequests.Helpers;
using RJB.Model.Model.Specializations;

namespace RJB.HttpExtinction.HttpRequests.RequestHelpers
{
    public static class SpecializationClientService
    {
        private static string SpecializationUrl = "/api/specializations/";

        public static bool AddSpecialization(Specialization specialization)
        {
            try
            {
                HttpClientHelper.PostData(specialization, string.Concat(SpecializationUrl, "AddSpecialization"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<Specialization> GetAllSpecializations()
        {
            try
            {
                var specializations = HttpClientHelper.GetResult<List<Specialization>>(string.Concat(SpecializationUrl, "GetAllSpecializations"));
                return specializations;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Specialization>();
            }
        }

        public static IEnumerable<Specialization> GetSubSpecializations(int parentId)
        {
            try
            {
                var specializations = HttpClientHelper.GetResult<List<Specialization>>(string.Concat(SpecializationUrl, $"GetSubSpecializations?parentId={parentId}"));
                return specializations;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Specialization>();
            }
        }

        public static IEnumerable<Specialization> GetSpecializationsByName(string name)
        {
            try
            {
                var specializations = HttpClientHelper.GetResult<List<Specialization>>(string.Concat(SpecializationUrl, $"GetSpecializations?name={name}"));
                return specializations;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Specialization>();
            }
        }
    }
}
