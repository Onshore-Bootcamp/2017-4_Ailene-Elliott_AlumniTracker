namespace NTierPL_Alumni.ViewModels
{
    using NTierDAL_Alumni.Models;
    using NTierPL_Alumni.Models;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class AlumniVM
    {
        public AlumniVM()
        {
            //this method is a constructor that tied list of alumniPO to the AllAlumni,
            AllAlumni = new List<AlumniPO>();

            //tied select list items to the department drop down,
            DepartmentDropDown = new List<SelectListItem>();

            //tied alumniPO to the alumni form to give value to the property.
            AlumniForm = new AlumniPO();
        }


        //view model object properties.
        //it hold information.
        public List<AlumniPO> AllAlumni { get; set; }

        public AlumniPO AlumniForm { get; set; }

        public List<SelectListItem> DepartmentDropDown { get; set; }
    }
}