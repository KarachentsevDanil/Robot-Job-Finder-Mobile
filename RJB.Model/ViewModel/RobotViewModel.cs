using System.Collections.Generic;
using RJB.Model.Model.Robots;

namespace RJB.Model.ViewModel
{
    public class RobotViewModel : Robot
    {
        public int Count { get; set; }

        public IEnumerable<RobotModel> RobotModels { get; set; }
    }
}
