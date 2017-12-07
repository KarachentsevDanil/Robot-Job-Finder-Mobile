using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJB.HttpExtinction.HttpRequests.RequestHelpers;
using RJB.Model.Model.Robots;
using RJF.MobileApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp.Pages.Robots
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Robots : ContentPage
    {
        private readonly RobotsViewModel _viewModel;

        public Robots()
        {
            InitializeComponent();
            _viewModel = new RobotsViewModel
            {
                RobotsModel = RobotClientService.GetRobotsByOfCompany(CurrentUser.CurrentUserModel.UserId).Collection
                    .ToList()
            };

            BindingContext = _viewModel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Robot;
            if (item == null)
                return;

            await Navigation.PushAsync(new RobotDetails(new RobotDetailsViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddRobot_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddRobot());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.RobotsModel.Count == 0)
                _viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
