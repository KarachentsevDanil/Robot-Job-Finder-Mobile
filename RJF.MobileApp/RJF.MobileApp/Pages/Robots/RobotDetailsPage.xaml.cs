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