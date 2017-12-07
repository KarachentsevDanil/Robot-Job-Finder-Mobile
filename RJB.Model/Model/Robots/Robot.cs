﻿using System.Collections.Generic;
using Newtonsoft.Json;
using RJF.MobileApp.Model.Leases;
using RJF.MobileApp.Model.Users;

namespace RJF.MobileApp.Model.Robots
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
    }
}