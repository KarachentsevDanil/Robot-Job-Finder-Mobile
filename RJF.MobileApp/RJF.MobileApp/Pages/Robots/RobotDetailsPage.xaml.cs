using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RJF.MobileApp.ViewModel;
using RJF.MobileApp.ViewModel.Robots;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RJF.MobileApp.Pages.Robots
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RobotDetails : ContentPage
    {
        private RobotDetailsViewModel _model;

        public RobotDetails()
        {
            InitializeComponent();
        }

        public RobotDetails(RobotDetailsViewModel robotDetailsViewModel)
        {
            InitializeComponent();
            _model = robotDetailsViewModel;
            BindingContext = _model;
        }
    }
}