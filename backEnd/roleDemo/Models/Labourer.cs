using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace roleDemo.Models
{
    public class Labourer
    {
        [Key]
        public int LabourerID { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public bool IsAvailable { get; set; }
        public string Availability { get; set; }
        // Child
        //public virtual ICollection<LabourerDailyQualityRating> LabourerDailyQualityRatings { get; set; }

        public virtual ICollection<LabourerSkill> LabourerSkills { get; set; }

        //public virtual ICollection<LabourerJob> LabourerJobs { get; set; }
    }

}