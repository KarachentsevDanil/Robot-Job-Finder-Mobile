﻿using System;
using System.Collections.Generic;
using System.Linq;
using RJB.HttpExtinction.HttpRequests.Helpers;
using RJB.Model.Model.Robots;
using RJB.Model.ViewModel;

namespace RJB.HttpExtinction.HttpRequests.RequestHelpers
{
    public static class RobotClientService
    {
        private static string RobotsUrl = "/api/robot/";

        public static bool AddRobot(RobotViewModel robot)
        {
            try
            {
                HttpClientHelper.PostData(robot, string.Concat(RobotsUrl, "AddRobot"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddRobotModel(RobotModel robotModel)
        {
            try
            {
                HttpClientHelper.PostData(robotModel, string.Concat(RobotsUrl, "AddRobotModel"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<RobotModel> GetRobotsModel()
        {
            try
            {
                var robots = HttpClientHelper.GetResult<List<RobotModel>>(string.Concat(RobotsUrl, "GetRobotsModel"));
                return robots;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<RobotModel>();
            }
        }

        public static IEnumerable<Robot> GetRobotsOnSpecificDateRange(SearchRobotModel searchRobotModel)
        {
            try
            {
                var robots = HttpClientHelper.PostDataAndGetResult<SearchRobotModel, List<Robot>>(searchRobotModel, string.Concat(RobotsUrl, "GetRobotsOnSpecificDateRange"));
                return robots;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Robot>();
            }
        }

        public static IEnumerable<RobotViewModel> GetRobotsBySpecialization(string name)
        {
            try
            {
                var robots = HttpClientHelper.GetResult<List<RobotViewModel>>(string.Concat(RobotsUrl, $"GetRobotsBySpecialization?name={name}"));
                return robots;
            }
            catch (Exception)
            {
                return Enumerable.Empty<RobotViewModel>();
            }
        }

        public static RobotViewModel GetRobotById(int robotId)
        {
            try
            {
                var robot = HttpClientHelper.GetResult<RobotViewModel>(string.Concat(RobotsUrl, $"GetRobotById?robotId={robotId}"));
                return robot;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

        public static CollectionResult<Robot> GetRobotsByOfCompany(int companyId)
        {
            try
            {
                var robots = HttpClientHelper.GetResult<CollectionResult<Robot>>(string.Concat(RobotsUrl, $"GetRobotsByOfCompany?companyId={companyId}"));
                return robots;
            }
            catch (Exception exp)
            {
                return new CollectionResult<Robot>();
            }
        }
    }
}
