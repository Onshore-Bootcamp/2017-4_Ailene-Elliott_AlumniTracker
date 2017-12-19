using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDAL_Alumni.Models
{
    public class AlumniDO
    {
        //alumni records object properties.
        //it hold information.
        public int RecordID { get; set; }
        public string CompleteName { get; set; }
        public Int16 YearGraduated { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string ContactNumber { get; set; }
        public int DepartmentID { get; set; }
        public DepartmentDO Department { get; set; }

        
        public AlumniDO()
        {
            //this method is a constructor that tied DepartmentDO to the DeptName to give value to the property.
            Department = new DepartmentDO();
        }
    }
}
