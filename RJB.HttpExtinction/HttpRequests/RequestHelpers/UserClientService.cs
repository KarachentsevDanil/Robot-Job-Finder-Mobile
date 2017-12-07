﻿using System;
using RJF.MobileApp.HttpRequests.Helpers;
using RJF.MobileApp.Model.Users;
using RJF.MobileApp.ViewModel;

namespace RJF.MobileApp.HttpRequests.RequestHelpers
{
    public static class UserClientService
    {
        private static string UserUrl = "/api/users/";

        public static bool ClientLogin(UserLoginModel loginModel)
        {
            try
            {
                HttpClientHelper.PostData(loginModel, string.Concat(UserUrl, "ClientLogin"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RegisterClient(Client client)
        {
            try
            {
                HttpClientHelper.PostData(client, string.Concat(UserUrl, "RegisterClient"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CompanyLogin(UserLoginModel loginModel)
        {
            try
            {
                HttpClientHelper.PostData(loginModel, string.Concat(UserUrl, "CompanyLogin"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RegisterCompany(Company company)
        {
            try
            {
                HttpClientHelper.PostData(company, string.Concat(UserUrl, "RegisterCompany"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static CurrentUserViewModel GetCurrentUser()
        {
            return HttpClientHelper.GetResult<CurrentUserViewModel>(string.Concat(UserUrl, "GetCurrentUser"));
        }

        public static void LogOff()
        {
            HttpClientHelper.Post(string.Concat(UserUrl, "LogOff"));
        }
    }
}
