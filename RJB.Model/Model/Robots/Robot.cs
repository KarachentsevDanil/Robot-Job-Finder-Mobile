using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RJB.Model.Model.Leases;
using RJB.Model.Model.Users;

namespace RJB.Model.Model.Robots
{
    [JsonObject(IsReference = true)]
    public class Robot
    {
        public Robot()
        {
            
        }

        public Robot(Robot robot)
        {
            RobotModelId = robot.RobotModelId;
            CompanyId = robot.CompanyId;
            PricePerDay = robot.PricePerDay;
        }

        public int RobotId { get; set; }

        public int CompanyId { get; set; }

        public int RobotModelId { get; set; }
        
        public double PricePerDay { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Company Company { get; set; }

        public virtual RobotModel RobotModel { get; set; }

        public virtual ICollection<RobotLease> RobotLeases { get; set; }

        [JsonIgnore]
        public string Specialization => RobotModel?.RobotModelSpecializations?.FirstOrDefault()?.Specialization?.Name;

        public string IsSelected { get; set; }
    }
}
