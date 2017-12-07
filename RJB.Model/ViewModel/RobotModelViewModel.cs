using System.Collections.Generic;
using RJF.MobileApp.Model.Robots;
using RJF.MobileApp.Model.Specializations;

namespace RJF.MobileApp.ViewModel
{
    public class RobotModelViewModel : RobotModel
    {
        public int SpecializationId { get; set; }

        public IEnumerable<Specialization> Specializations { get; set; }
    }
}
