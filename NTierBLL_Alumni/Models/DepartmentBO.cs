using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierBLL_Alumni.Models
{
    public class DepartmentBO
    {
        //department table properties.
        //it hold information.
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public string Description { get; set; }
        public string DeptHead { get; set; }
        public string DeptHeadSpecialization { get; set; }
        public int AlumniCount { get; set; }
    }
}
