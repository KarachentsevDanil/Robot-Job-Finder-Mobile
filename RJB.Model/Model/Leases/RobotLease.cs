using Newtonsoft.Json;
using RJF.MobileApp.Model.Robots;

namespace RJF.MobileApp.Model.Leases
{
    [JsonObject(IsReference = true)]
    public class RobotLease
    {
        public int RobotLeaseId { get; set; }

        public int RobotId { get; set; }

        public int LeaseId { get; set; }

        public virtual Robot Robot { get; set; }

        public virtual Lease Lease { get; set; }
    }
}
