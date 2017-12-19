using NTierDAL_Alumni;
using NTierDAL_Alumni.Models;
using NTierPL_Alumni.Mapping;
using NTierPL_Alumni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierPL_Alumni.Controllers
{
    public class RoleController : Controller
    {
        private RoleDAL RoleDataAccessLayer = new RoleDAL();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewAllRole()
        {
            ActionResult response = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1)
                {
                    List<RolePO> roleList = new List<RolePO>();
                    List<RoleDO> roleObjectList = RoleDataAccessLayer.ReadRole();
                    foreach (RoleDO objectList in roleObjectList)
                    {
                        RolePO mappedRole = Mapper.MapRoleDOtoPO(objectList);
                        roleList.Add(mappedRole);
                    }
                    response = View(roleList);
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
