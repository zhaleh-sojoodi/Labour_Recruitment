using System;
using System.Collections.Generic;

namespace roleDemo.Models.LabourerRecruitment
{
    public partial class Labourer
    {
        public Labourer()
        {
            Availability = new HashSet<Availability>();
            Incident = new HashSet<Incident>();
            LabourerDailyQualityRating = new HashSet<LabourerDailyQualityRating>();
            LabourerSafetyRating = new HashSet<LabourerSafetyRating>();
            LabourerSkill = new HashSet<LabourerSkill>();
        }

        public int LabourerId { get; set; }
        public int? UserId { get; set; }
        public string LabourerFirstName { get; set; }
        public string LabourerLastName { get; set; }
        public int? LabourerSin { get; set; }
        public string LabourerEmail { get; set; }
        public bool? IsAvailable { get; set; }

        public virtual SystemUser User { get; set; }
        public virtual ICollection<Availability> Availability { get; set; }
        public virtual ICollection<Incident> Incident { get; set; }
        public virtual ICollection<LabourerDailyQualityRating> LabourerDailyQualityRating { get; set; }
        public virtual ICollection<LabourerSafetyRating> LabourerSafetyRating { get; set; }
        public virtual ICollection<LabourerSkill> LabourerSkill { get; set; }
    }
}
