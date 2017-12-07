using System;
using System.Collections.Generic;
using RJB.Model.Model.Robots;
using RJB.Model.Model.Specializations;

namespace RJB.Model.ViewModel
{
    public class LeaseViewModel
    {
        public int LeaseId { get; set; }

        public int SpecializationId { get; set; }

        public int CountRobots { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Feedback { get; set; }

        public Rating Rating { get; set; }

        public IEnumerable<Specialization> Specializations { get; set; }

        public int[] RobotIds { get; set; }
    }
}