using System;
using System.Collections.Generic;

namespace roleDemo.Models.LabourerRecruitment
{
    public partial class Availability
    {
        public int AvailabilityId { get; set; }
        public int? LabourerId { get; set; }
        public string AvailabilityTime { get; set; }

        public virtual Labourer Labourer { get; set; }
    }
}
