using Newtonsoft.Json;
using RJB.Model.Model.Robots;

namespace RJB.Model.Model.Leases
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
