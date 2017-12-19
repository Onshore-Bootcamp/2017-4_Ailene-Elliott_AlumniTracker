using NTierBLL_Alumni.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierBLL_Alumni
{
    public class AlumniBLL
    {
        private LoggingBLL LoggingBusinessLogicLayer = new LoggingBLL();
        //an instance for LoggingBll to hold information


        public List<DepartmentBO> LinkedToAlumniAndDepartment(List<DepartmentBO> departmentList, List<AlumniBO> alumniList)
        {
            //the method is holding a list info of department and alumni
            //with a return of department list

            foreach (DepartmentBO departmentObject in departmentList)
            {
                //run though foreach loop to get the info one by one in a dept list

                List<int> alumniCount = alumniList.Where(alumniBO => alumniBO.DepartmentID == departmentObject.DeptID)
                    //with the condition,department ID on the alumniList and departmentList must be equal
                    .Select(alumniBO => alumniBO.DepartmentID)
                    //to be selected
                    .ToList();
                    //and to be added to the new list

                departmentObject.AlumniCount = alumniCount.Count();
                //which count the number of the alumni in each department.
            }
            return departmentList;
        }

    }
}

