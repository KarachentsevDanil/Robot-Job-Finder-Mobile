using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Robots;
using RJF.MobileApp.Pages.Robots;
using Xamarin.Forms;

namespace RJF.MobileApp.ViewModel
{
    public class RobotsViewModel : BaseCommonViewModel
    {
        public List<Robot> RobotsModel { get; set; }
        public Command LoadItemsCommand { get; set; }

        public RobotsViewModel()
        {
            Title = "My Robots";
            RobotsModel = new List<Robot>();
            LoadItemsCommand = new Command(ExecuteLoadItemsCommand);

            MessagingCenter.Subscribe<AddRobot, Robot>(this, "AddRobot", (obj, item) =>
            {
                RobotsModel = RobotClientService.GetRobotsByOfCompany(CurrentUser.CurrentUserModel.UserId).Collection.ToList();
            });
        }

        public void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RobotsModel.Clear();
                RobotsModel = RobotClientService.GetRobotsByOfCompany(CurrentUser.CurrentUserModel.UserId).Collection.ToList();
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
