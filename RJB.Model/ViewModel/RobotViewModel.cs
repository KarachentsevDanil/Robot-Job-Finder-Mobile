using System.Collections.Generic;
using RJF.MobileApp.Model.Robots;

namespace RJF.MobileApp.ViewModel
{
    public class RobotViewModel : Robot
    {
        public int Count { get; set; }

        public IEnumerable<RobotModel> RobotModels { get; set; }
    }
}
