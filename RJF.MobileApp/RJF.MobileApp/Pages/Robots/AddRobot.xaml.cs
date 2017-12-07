using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Robots;
using RJB.Model.ViewModel;
using RJF.MobileApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp.Pages.Robots
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRobot : ContentPage
    {
        public static IEnumerable<RobotModel> RobotModels;

        public AddRobot()
        {
            InitializeComponent();
            RobotModels = RobotClientService.GetRobotsModel();

            foreach (var robotModel in RobotModels)
            {
                RobotModel.Items.Add(robotModel.Name);
            }
        }

        private async void AddRobotButton_Clicked(object sender, EventArgs e)
        {
            var robotModelId = RobotModels.FirstOrDefault(x => x.Name == RobotModel.SelectedItem.ToString())
                ?.RobotModelId ?? 0;

            var robot = new RobotViewModel
            {
                CompanyId = CurrentUser.CurrentUserModel.UserId,
                Count = int.Parse(CountRobots.Text),
                PricePerDay = double.Parse(PricePerDay.Text),
                RobotModelId = robotModelId
            };

            var isRobotAdd = RobotClientService.AddRobot(robot);
            if (!isRobotAdd)
            {
                AddRobotFailed.IsVisible = true;
            }
            else
            {
                ClearForm();
                MessagingCenter.Send(this, "AddItem", robot);
                await DisplayAlert("Info", "Robots was added", "OK");
            }
        }

        private void ClearForm()
        {
            AddRobotFailed.IsVisible = false;
            CountRobots.Text = string.Empty;
            PricePerDay.Text = string.Empty;
        }
    }
}