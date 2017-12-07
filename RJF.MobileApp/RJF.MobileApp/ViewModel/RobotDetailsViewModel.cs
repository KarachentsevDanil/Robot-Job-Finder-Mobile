using RJB.Model.Model.Robots;

namespace RJF.MobileApp.ViewModel
{
    public class RobotDetailsViewModel : BaseRobotsViewModel
    {
        public Robot Robot { get; set; }
        public RobotDetailsViewModel(Robot robot)
        {
            Title = $"#{robot.RobotId} - {robot?.RobotModel.Name}";
            Robot = robot;
        }
    }
}
