using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RJF.MobileApp.Model.Robots;
using RJF.MobileApp.Model.Users;

namespace RJF.MobileApp.Model.Leases
{
    [JsonObject(IsReference = true)]
    public class Lease
    {
        public int LeaseId { get; set; }
        
        public int ClientId { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public string Feedback { get; set; }

        public Rating? Rating { get; set; }

        public LeaseStatus Status { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<RobotLease> RobotLeases { get; set; }
    }
}
