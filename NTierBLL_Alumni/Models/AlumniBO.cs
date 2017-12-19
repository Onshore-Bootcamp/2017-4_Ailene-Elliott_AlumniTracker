using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierBLL_Alumni.Models
{
     public class AlumniBO
    {
        //alumni records table properties.
        //it hold information.
        public int RecordID { get; set; }
        public string CompleteName { get; set; }
        public Int16 YearGraduated { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string ContactNumber { get; set; }
        public int DepartmentID { get; set; }
    }
}
