using RJB.Model.Model.Robots;

namespace RJF.MobileApp.ViewModel.Robots
{
    public class RobotDetailsViewModel : BaseCommonViewModel
    {
        public Robot Robot { get; set; }
        public RobotDetailsViewModel(Robot robot)
        {
            Title = $"#{robot.RobotId} - {robot?.RobotModel.Name}";
            Robot = robot;
        }
    }
}
