using System;
using Newtonsoft.Json;
using RJB.Model.Model.Users;

namespace RJB.Model.Model.Robots
{
    [JsonObject(IsReference = true)]
    public class RobotModelFeedback
    {
        public int RobotFeedbackId { get; set; }

        public int RobotModelId { get; set; }

        public int ClientId { get; set; }

        public Rating Rate { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual RobotModel RobotModel { get; set; }

        public virtual Client Client { get; set; }
    }
}
