using NTierDAL_Alumni;
using NTierDAL_Alumni.Models;
using NTierPL_Alumni.Mapping;
using NTierPL_Alumni.Models;
using NTierPL_Alumni.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierPL_Alumni.Controllers
{
    public class AccountController : Controller
    {
        private UserDAL UserDataAccessLayer = new UserDAL();
        private RoleDAL RoleDataAccessLayer = new RoleDAL();
        // GET: Account

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginPO loginForm)
        {
            ActionResult response = null;
            if (ModelState.IsValid)
            {
                UserDO userInfo = UserDataAccessLayer.ViewUserByUsername(loginForm.UserName);
                if (userInfo.Password == loginForm.Password)
                {
                    //if login is a success
                    //stored info in session
                    Session["UserID"] = userInfo.UserID;
                    Session["CompleteName"] = userInfo.CompleteName;
                    Session["UserName"] = userInfo.UserName;
                    //Session["Password"] = userInfo.Password;
                    Session["RoleID"] = userInfo.RoleID;

                    //10 mins elapse between page calls,
                    //redirect user to a working page.
                    Session.Timeout = 10;
                    response = RedirectToAction("Index", "Home");
                }
                else
                {
                    //login failed due to password mismatch
                    //send user back to form.
                    
                    response = View(loginForm);
                }
            }
            else
            {
                // form was not filled properly send user back to form
                response = View(loginForm);
            }
            return response;
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register (UserPO registerForm)
        {
            ActionResult response = null;
            if(ModelState.IsValid)
            {
                registerForm.RoleID = 3;
                UserDO mappedUser = Mapper.MapUserPOtoDO(registerForm);
                bool success = UserDataAccessLayer.RegisterUser(mappedUser);
                if(success)
                {
                    response = RedirectToAction("index", "Home");
                }
                else
                {
                    response = View(registerForm);
                }
            }
            else
            {
                response = View(registerForm);
            }
            return response;
        }

        [HttpGet]
        public ActionResult ViewAllUser()
        {
            ActionResult response = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1)
                {
                    UserDAL userDataAccess = new UserDAL();
                    List<UserPO> userList = new List<UserPO>();
                    List<UserDO> userObjectList = userDataAccess.ReadUser();
                    foreach (UserDO objectList in userObjectList)
                    {
                        UserPO mappedUser = Mapper.MapUserDOtoPO(objectList);
                        userList.Add(mappedUser);
                    }
                    response = View(userList);
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
        public ActionResult CreateUser()
        {
            ActionResult response = null;
            if(Session["RoleID"]!=null)
            {
                if ((int)Session["RoleID"]==1)
                {
                    UserVM userForm = new UserVM();
                    List<RoleDO> roleObjectList = RoleDataAccessLayer.ReadRole();

                    userForm.RoleDropDown.Add(new SelectListItem { Text = "Please choose a role", Value = "0" });
                    foreach (RoleDO roleObject in roleObjectList)
                    {
                        SelectListItem roleItem = new SelectListItem();
                        roleItem.Text = roleObject.Name;
                        roleItem.Value = roleObject.RoleID.ToString();
                        userForm.RoleDropDown.Add(roleItem);
                    }
                    response =  View(userForm);
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
        public ActionResult CreateUser(UserVM userCreateForm)
        {
            ActionResult result = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1)
                {
                    if (ModelState.IsValid)
                    {
                        UserDO mappedDataCreateUser = Mapper.MapUserPOtoDO(userCreateForm.UserForm);
                        UserDataAccessLayer.CreateUser(mappedDataCreateUser);
                        result = RedirectToAction("ViewAllUser");  
                    }
                    else
                    {
                        UserVM userForm = new UserVM();
                        List<RoleDO> roleObjectList = RoleDataAccessLayer.ReadRole();

                        userForm.RoleDropDown.Add(new SelectListItem { Text = "Please choose a role", Value = "0" });
                        foreach (RoleDO roleObject in roleObjectList)
                        {
                            SelectListItem roleItem = new SelectListItem();
                            roleItem.Text = roleObject.Name;
                            roleItem.Value = roleObject.RoleID.ToString();
                            userForm.RoleDropDown.Add(roleItem);
                        }
                        result = View(userForm);
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
        public ActionResult UpdateUser(int UserID)
        {
            ActionResult response = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1)
                {
                    UserVM userViewModel = new UserVM();
                    UserDO mappedDataIDDo = UserDataAccessLayer.ViewUserByID(UserID);
                    userViewModel.UserForm = Mapper.MapUserDOtoPO(mappedDataIDDo);

                    List<RoleDO> roleObjectList = RoleDataAccessLayer.ReadRole();
                    userViewModel.RoleDropDown.Add(new SelectListItem { Text = "Please choose a role", Value = "0" });
                    foreach (RoleDO roleObject in roleObjectList)
                    {
                        SelectListItem roleItem = new SelectListItem();
                        roleItem.Text = roleObject.Name;
                        roleItem.Value = roleObject.RoleID.ToString();
                        userViewModel.RoleDropDown.Add(roleItem);
                    }
                    response = View(userViewModel);
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
        public ActionResult UpdateUser(UserVM userUpdateForm)
        {
            ActionResult result = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1)
                {
                    if (ModelState.IsValid)
                    {
                        UserDO mappedDataUpdate = Mapper.MapUserPOtoDO(userUpdateForm.UserForm);
                        UserDataAccessLayer.UpdateUser(mappedDataUpdate);
                        result = RedirectToAction("ViewAllUser");
                    }
                    else
                    {
                        result = View(userUpdateForm);
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
        public ActionResult DeleteUser(int userID)
        {
            ActionResult response = null;
            if(Session["RoleID"]!=null)
            {
                if((int)Session["RoleID"]==1)
                {
                    UserDataAccessLayer.DeleteUser(userID);
                    response = RedirectToAction("ViewAllUser");
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
