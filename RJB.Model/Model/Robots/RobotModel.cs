using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RJF.MobileApp.Model.Robots
{
    [JsonObject(IsReference = true)]
    public class RobotModel
    {
        public int RobotModelId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? ReleaseYear { get; set; }

        public byte[] Photo { get; set; }
        
        public virtual ICollection<Robot> Robots { get; set; }

        public virtual ICollection<RobotModelSpecialization> RobotModelSpecializations { get; set; }

        public virtual ICollection<RobotModelFeedback> RobotModelFeedbacks { get; set; }
    }
}
