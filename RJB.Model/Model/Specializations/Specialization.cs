using System.Collections.Generic;
using Newtonsoft.Json;

namespace RJB.Model.Model.Specializations
{
    [JsonObject(IsReference = true)]
    public class Specialization
    {
        public int SpecializationId { get; set; }
        
        public string Name { get; set; }

        public int? ParentSpecializationId { get; set; }

        public virtual Specialization ParentSpecialization { get; set; }

        public ICollection<Specialization> SubSpecializations { get; set; }
    }
}
