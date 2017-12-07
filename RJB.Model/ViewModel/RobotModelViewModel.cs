using System.Collections.Generic;
using RJB.Model.Model.Robots;
using RJB.Model.Model.Specializations;

namespace RJB.Model.ViewModel
{
    public class RobotModelViewModel : RobotModel
    {
        public int SpecializationId { get; set; }

        public IEnumerable<Specialization> Specializations { get; set; }
    }
}
