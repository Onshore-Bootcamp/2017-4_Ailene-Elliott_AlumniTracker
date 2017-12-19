using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NTierDAL_Alumni;
using NTierPL_Alumni.Models;
using NTierDAL_Alumni.Models;
using NTierPL_Alumni.Mapping;
using NTierBLL_Alumni.Models;
using NTierBLL_Alumni;

namespace NTierPL_Alumni.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentDAL DepartmentDataAccessLayer = new DepartmentDAL();
        private AlumniBLL AlumniBusinessLogicLayer = new AlumniBLL();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewAllDepartment()
        {
            ActionResult response = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2 || (int)Session["RoleID"]==3)
                {
                    List<DepartmentDO> departmentObjectList = DepartmentDataAccessLayer.ReadDepartment();

                    List<DepartmentBO> departmentBOList = new List<DepartmentBO>();
                    foreach (DepartmentDO objectList in departmentObjectList)
                    {
                        DepartmentBO mappedDepartmentBO = Mapper.MapDepartmentDOtoBO(objectList);
                        departmentBOList.Add(mappedDepartmentBO);
                    }
                    List<AlumniBO> alumniBOList = new List<AlumniBO>();
                    AlumniDAL alumniDataAccess = new AlumniDAL();

                    List<AlumniDO> alumniDAOList = alumniDataAccess.ReadAlumniRecord();
                    foreach (AlumniDO objectList in alumniDAOList)
                    {
                        AlumniBO mappedAlumniBO = Mapper.MapAlumniDOtoBO(objectList);
                        alumniBOList.Add(mappedAlumniBO);
                    }


                    List<DepartmentBO> departmentBOListCount = AlumniBusinessLogicLayer.LinkedToAlumniAndDepartment(departmentBOList, alumniBOList);

                    List<DepartmentPO> departmentList = new List<DepartmentPO>();
                    foreach (DepartmentBO objectList in departmentBOList)
                    {
                        DepartmentPO mappedDepartmentPO = Mapper.MapDepartmentBOtoPO(objectList);
                        departmentList.Add(mappedDepartmentPO);
                    }

                    response = View(departmentList);
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
            return response;
        }

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            ActionResult response = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2)
                {
                    response = View();
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
            return response;
        }

        [HttpPost]
        public ActionResult CreateDepartment(DepartmentPO createForm)
        {
            ActionResult result = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2)
                {
                    if (ModelState.IsValid)
                    {
                        DepartmentDO mappedDataCreate = Mapper.MapDepartmentPOtoDO(createForm);
                        DepartmentDataAccessLayer.CreateDepartment(mappedDataCreate);
                        result = RedirectToAction("ViewAllDepartment");
                    }
                    else
                    {
                        result = View(createForm);
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
            return result;
        }

        [HttpGet]
        public ActionResult UpdateDepartment(int DeptID)
        {
            ActionResult response = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2)
                {
                    DepartmentDO mappedDataIDDo = DepartmentDataAccessLayer.ViewDepartmentByID(DeptID);
                    DepartmentPO mappedDataIDPo = Mapper.MapDepartmentDOtoPO(mappedDataIDDo);
                    response = View(mappedDataIDPo);
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
            return response;
        }

        [HttpPost]
        public ActionResult UpdateDepartment(DepartmentPO updateForm)
        {
            ActionResult result = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2)
                {
                    if (ModelState.IsValid)
                    {
                        DepartmentDO mappedDataUpdate = Mapper.MapDepartmentPOtoDO(updateForm);
                        DepartmentDataAccessLayer.UpdateDepartment(mappedDataUpdate);
                        result = RedirectToAction("ViewAllDepartment");
                    }
                    else
                    {
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
            return result;
        }

        [HttpGet]
        public ActionResult DeleteDepartment(int deptID)
        {
            ActionResult response = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1 || (int)Session["RoleID"]==2)
                {
                    DepartmentDataAccessLayer.DeleteDepartment(deptID);
                    response = RedirectToAction("ViewAllDepartment");
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
            return response;
        }
    }
}