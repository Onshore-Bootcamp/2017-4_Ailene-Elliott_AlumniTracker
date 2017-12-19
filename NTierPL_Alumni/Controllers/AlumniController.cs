using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTierDAL_Alumni;
using NTierPL_Alumni.Models;
using NTierDAL_Alumni.Models;
using NTierPL_Alumni.Mapping;
using NTierPL_Alumni.ViewModels;
using NTierBLL_Alumni.Models;
using NTierBLL_Alumni;

namespace NTierPL_Alumni.Controllers
{
    public class AlumniController : Controller
    {
        //an instance to hold entire info of a class/layer.
        private AlumniDAL AlumniDataAccessLayer = new AlumniDAL();
        private DepartmentDAL DepartmentDataAccessLayer = new DepartmentDAL();
        private AlumniBLL AlumniBusinessLogicLayer = new AlumniBLL();

        [HttpGet]
        public ActionResult Index()
        {
            //showing the home page or index to the user.
            return View();
        }

        [HttpGet]
        public ActionResult ViewAllAlumni()
        {
            //a default value for action result
            ActionResult response = null;

            if(Session["RoleID"]!=null)
            {
                //session that check if someone log in or none
                //if there is log in run the condition.
                //if there is none then go to else option

                if((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2 || (int)Session["RoleID"]==3)
                {
                    //session that determine what user is log in.
                    //if any of these role is not log in then go to else option.

                    //an instance to hold new list of AlumniPO info
                    List<AlumniPO> alumniList = new List<AlumniPO>();

                    //alumni data object identifier that holds program of read alumni record method.
                    List<AlumniDO> alumniObjectList = AlumniDataAccessLayer.ReadAlumniRecord();

                    foreach (AlumniDO objectList in alumniObjectList)
                    {
                        //a program which data object is being converted to a presentation object
                        //one by one,using a foreach loop then by mapper to convert.
                        AlumniPO mappedAlumni = Mapper.MapAlumniDOtoPO(objectList);
                        alumniList.Add(mappedAlumni);
                    }
                    //passing on all the converted info to identifier alumniList to be viewed.
                    response =  View(alumniList);
                }
                else
                {
                    response = RedirectToAction("Index", "Home");
                }
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            //returning a list value or redirect.
            return response;
        }

        [HttpGet]
        public ActionResult CreateAlumniRecord()
        {
            //a default value for action result
            ActionResult response = null;

            if(Session["RoleID"]!=null)
            {
                //session that check if someone log in or none
                //if there is log in run the condition.
                //if there is none then go to else option

                if ((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2 || (int)Session["RoleID"]==3)
                {
                    //session that determine what user is log in.
                    //if any of these role is not log in then go to else option.

                    //an instance to hold new info from ViewModel specially the form.
                    AlumniVM alumniForm = new AlumniVM();

                    //department data object identifier that holds program of read department method.
                    List<DepartmentDO> departmentObjectList = DepartmentDataAccessLayer.ReadDepartment();

                    //program that makes a dropdown option for department.
                    //calling the instance then targetting the dropdown then add to the list whichever run in to the foreach loop.
                    alumniForm.DepartmentDropDown.Add(new SelectListItem { Text = "Please choose a department", Value = "0" });
                    foreach (DepartmentDO departmentObject in departmentObjectList)
                    {
                        SelectListItem item = new SelectListItem();
                        item.Text = departmentObject.DeptName;
                        item.Value = departmentObject.DeptID.ToString();
                        alumniForm.DepartmentDropDown.Add(item);
                    }
                    //showing the form with the dropdown department.
                    response = View(alumniForm);
                }
                else
                {
                    response = RedirectToAction("Index", "Home");
                }
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            //returning a form value or redirect.
            return response;
        }

        [HttpPost]
        public ActionResult CreateAlumniRecord(AlumniVM registerForm)
        {
            //method holds whatever info does user add in the form.

            //a default value for action result
            ActionResult result = null;

            if(Session["RoleID"]!=null)
            {
                //session that check if someone log in or none
                //if there is log in run the condition.
                //if there is none then go to else option

                if ((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2 || (int)Session["RoleID"]==3)
                {
                    //session that determine what user is log in.
                    //if any of these role is not log in then go to else option.

                    if (ModelState.IsValid)
                    {
                        //if everything is valid in a model state,run the program
                        //if it doesnt meet any requirements, run else option.

                        //a DO identifier that hold info from the form
                        //info coming from the form obtain form the user will be converted to data access
                        //object and be added to the database.
                        AlumniDO mappedDataCreate = Mapper.MapAlumniPOtoDO(registerForm.AlumniForm);

                        //calling the data access layer instance to create a new record with the info from user.
                        AlumniDataAccessLayer.CreateAlumniRecord(mappedDataCreate);

                        //after it is added to database redirect to view to check new entry.
                        result = RedirectToAction("ViewAllAlumni");
                    }
                    else
                    {
                        //this is a program for dropdown to the form.
                        AlumniVM alumniForm = new AlumniVM();
                        List<DepartmentDO> departmentObjectList = DepartmentDataAccessLayer.ReadDepartment();

                        alumniForm.DepartmentDropDown.Add(new SelectListItem { Text = "Please choose a department", Value = "0" });
                        foreach (DepartmentDO departmentObject in departmentObjectList)
                        {
                            SelectListItem item = new SelectListItem();
                            item.Text = departmentObject.DeptName;
                            item.Value = departmentObject.DeptID.ToString();
                            alumniForm.DepartmentDropDown.Add(item);
                        }
                        //throwing a view form with a dropdown.
                        result = View(alumniForm);
                    }
                }
                else
                {
                    result = RedirectToAction("Index", "Home");
                }
            }
            else
            {
                result = RedirectToAction("Index", "Home");
            }
            //returning a form or redirect.
            return result;
        }

        [HttpGet]
        public ActionResult UpdateAlumniRecord(int RecordID)
        {
            //method holds the record ID that need to be updated

            //a default value for action result
            ActionResult response = null;

            if(Session["RoleID"]!=null)
            {
                //session that check if someone log in or none
                //if there is log in run the condition.
                //if there is none then go to else option

                if ((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2 || (int)Session["RoleID"]==3)
                {
                    //session that determine what user is log in.
                    //if any of these role is not log in then go to else option.

                    //an instance to hold new info from ViewModel specially the form.
                    AlumniVM alumniUpdateForm = new AlumniVM();

                    //identifier for data access object that holds the program,view alumni by ID.
                    AlumniDO mappedDataIDDo = AlumniDataAccessLayer.ViewAlumniRecordByID(RecordID);

                    //calling view model to populate the form with the exsisting info from the database
                    //then converting it to presentation object
                    alumniUpdateForm.AlumniForm = Mapper.MapAlumniDOtoPO(mappedDataIDDo);

                    //department data object identifier that holds program of read department method.
                    List<DepartmentDO> departmentObjectList = DepartmentDataAccessLayer.ReadDepartment();

                    //program that makes a dropdown option for department.
                    //calling the instance then targetting the dropdown then add to the list whichever run in to the foreach loop.
                    alumniUpdateForm.DepartmentDropDown.Add(new SelectListItem { Text = "Please choose a department", Value = "0" });
                    foreach (DepartmentDO departmentObject in departmentObjectList)
                    {
                        SelectListItem item = new SelectListItem();
                        item.Text = departmentObject.DeptName;
                        item.Value = departmentObject.DeptID.ToString();
                        alumniUpdateForm.DepartmentDropDown.Add(item);
                    }
                    //showing the form with info and the dropdown department.
                    response = View(alumniUpdateForm);
                }
                else
                {
                    response = RedirectToAction("Index", "Home");
                }
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            //returning a populated form value or redirect.
            return response;
        }

        [HttpPost]
        public ActionResult UpdateAlumniRecord(AlumniVM updateForm)
        {
            //method holds whatever info does user add in the form.

            //a default value for action result
            ActionResult result = null;

            if(Session["RoleID"]!=null)
            {
                //session that check if someone log in or none
                //if there is log in run the condition.
                //if there is none then go to else option

                if ((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2 || (int)Session["RoleID"]==3)
                {
                    //session that determine what user is log in.
                    //if any of these role is not log in then go to else option.

                    if (ModelState.IsValid)
                    {
                        //if everything is valid in a model state,run the program
                        //if it doesnt meet any requirements, run else option.

                        //a DO identifier that hold info from the form
                        //info coming from the form obtain form the user will be converted to data access
                        //object and be added to the database.
                        AlumniDO mappedDataUpdate = Mapper.MapAlumniPOtoDO(updateForm.AlumniForm);
                        AlumniDataAccessLayer.UpdateAlumniRecord(mappedDataUpdate);

                        //after it is added to database redirect to view to check new entry.
                        result = RedirectToAction("ViewAllAlumni");
                    }
                    else
                    {
                        //throwing a view form with a dropdown.
                        result = View(updateForm);
                    }
                }
                else
                {
                    result = RedirectToAction("Index", "Home");
                }
            }
            else
            {
                result = RedirectToAction("Index", "Home");
            }
            //returning a form ,a view all or a redirect.
            return result;
        }

        [HttpGet]
        public ActionResult DeleteAlumniRecord(int recordID)
        {
            //method holds the record ID that need to be deleted.

            //a default value for action result
            ActionResult response = null;

            if (Session["RoleID"] != null)
            {
                //session that check if someone log in or none
                //if there is log in run the condition.
                //if there is none then go to else option

                if ((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2 || (int)Session["RoleID"]==3)
                {
                    //session that determine what user is log in.
                    //if any of these role is not log in then go to else option.

                    //delete a record using the id.
                    AlumniDataAccessLayer.DeleteAlumniRecord(recordID);

                    //after delete,go to view to check record.
                    response = RedirectToAction("ViewAllAlumni");
                }
                else
                {
                    response = RedirectToAction("Index", "Home");
                }
            }
            else
            {
                response = RedirectToAction("Index", "Home");
            }
            //returning a view all alumni or redirect.
            return response;
        }   
    }
}
