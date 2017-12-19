using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTierPL_Alumni.Models
{
    public class DepartmentPO
    {
        public int DeptID { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Department Head")]
        public string DeptHead { get; set; }

        [Required]
        [Display(Name = "Department Head Specialization")]
        public string DeptHeadSpecialization { get; set; }

        public int AlumniCount { get; set; }
    }
}