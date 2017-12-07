using System;
using System.Collections.Generic;
using RJF.MobileApp.Model.Robots;
using RJF.MobileApp.Model.Specializations;

namespace RJF.MobileApp.ViewModel
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