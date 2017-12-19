using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Leases;
using RJB.Model.Model.Robots;
using RJB.Model.Model.Specializations;
using RJB.Model.ViewModel;
using RJF.MobileApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp.Pages.Leases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLease : ContentPage
    {
        public ObservableCollection<Robot> Robots { get; set; }
        public static List<Specialization> Specializations { get; set; }
        public List<int> SelectedIds { get; set; }
        public Command<List<Robot>> LoadRobotsCommand { get; set; }

        public AddLease()
        {
            InitializeComponent();
            Specializations = HttpSpecializationService.GetAllSpecializations().ToList();
            LoadRobotsCommand = new Command<List<Robot>>(UpdateRobotsLease);

            foreach (var specialization in Specializations)
            {
                Specialization.Items.Add(specialization.Name);
            }

            SelectedIds = new List<int>();
            Robots = new ObservableCollection<Robot>();
            BindingContext = this;
        }

        public void UpdateRobotsLease(List<Robot> robots)
        {
            if (robots == null)
                return;

            Robots.Clear();

            foreach (var robot in robots)
            {
                Robots.Add(robot);
            }
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            var specializationId =
                Specializations.FirstOrDefault(x => x.Name == Specialization.SelectedItem.ToString())
                    ?.SpecializationId ?? 0;

            var searchRobot = new SearchRobotModel
            {
                SpecializationId = specializationId,
                StartDate = StartDate.Date,
                EndDate = EndDate.Date
            };

            var robots = HttpRobotService.GetRobotsOnSpecificDateRange(searchRobot);
            AddLeaseButton.IsVisible = robots.Any();

            LoadRobotsCommand.Execute(robots);
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Robot;
            if (item == null)
                return;


            if (SelectedIds.Contains(item.RobotId))
            {
                var deleteRobot = await DisplayAlert("Lease a robot", "Would you like to delete this robot from lease list?", "Yes", "No");
                if (deleteRobot)
                {
                    SelectedIds.Remove(item.RobotId);

                    item.IsSelected = string.Empty;

                    Robots.Remove(Robots.FirstOrDefault(x => x.RobotId == item.RobotId));
                    Robots.Add(item);
                }
            }
            else
            {
                var answer = await DisplayAlert("Lease a robot", "Would you like to add this robot?", "Yes", "No");

                if (answer)
                {
                    SelectedIds.Add(item.RobotId);
                    item.IsSelected = "Selected";

                    Robots.Remove(Robots.FirstOrDefault(x => x.RobotId == item.RobotId));
                    Robots.Insert(0, item);
                }
            }

            ItemsListView.SelectedItem = null;
        }

        private async void AddLeaseButton_Clicked(object sender, EventArgs e)
        {
            if (!SelectedIds.Any())
            {
                await DisplayAlert("Info", "Select at least one robot.", "Ok");
                return;
            }

            var leaseModel = new Lease
            {
                ClientId = CurrentUser.CurrentUserModel.UserId,
                StartDate = StartDate.Date,
                EndDate = EndDate.Date,
                RobotLeases = new List<RobotLease>(SelectedIds.Capacity)
            };
            
            foreach (var robotId in SelectedIds)
            {
                leaseModel.RobotLeases.Add(new RobotLease
                {
                    RobotId = robotId
                });
            }

            var isSuccess = HttpLeaseService.CreateLease(leaseModel);
            if (isSuccess)
            {
                await DisplayAlert("Info", "Lease successfully created.", "Ok");
                MessagingCenter.Send(this, "AddLease", leaseModel);
                ClearForm();
            }
            else
            {
                await DisplayAlert("Info", "Error occure when lease create. Try one more time.", "Ok");
            }
        }

        private async void LogOff_OnClicked(object sender, EventArgs e)
        {
            CurrentUser.CurrentUserModel = null;
            await Navigation.PopAsync();
        }

        private void ClearForm()
        {
            LoadRobotsCommand.Execute(new List<Robot>());
        }
    }
}