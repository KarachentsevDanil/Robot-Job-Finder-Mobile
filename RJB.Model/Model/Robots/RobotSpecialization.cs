using Newtonsoft.Json;
using RJF.MobileApp.Model.Specializations;

namespace RJF.MobileApp.Model.Robots
{
    [JsonObject(IsReference = true)]
    public class RobotModelSpecialization
    {
        public int RobotModelId { get; set; }
        
        public int SpecializationId { get; set; }

        public SkillLevel SkillLevel { get; set; }

        [JsonIgnore]
        public RobotModel RobotModel { get; set; }

        public Specialization Specialization { get; set; }
    }
}
