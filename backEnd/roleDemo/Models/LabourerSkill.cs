using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace roleDemo.Models
{
    public class LabourerSkill
    {
        [Key]
        public int LabourerSkillID { get; set; }
        public int LabourerID { get; set; }
        public int SkillID { get; set; }
    }
}
