﻿using labourRecruitment.Models.LabourRecruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labourRecruitment.ViewModels
{
    public class LabourerProfileVM
    {
        public Labourer Labourer { get; set; }
        public IEnumerable<Availability> Availabilities { get; set; }
        public double AverageSafety { get; set; }
        //public int SafetyRatingNumber { get; set; }
        //public int QualityRatingNumber { get; set; }
    }
}
