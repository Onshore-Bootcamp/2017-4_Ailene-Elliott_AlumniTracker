using NTierPL_Alumni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierPL_Alumni.ViewModels
{
    public class UserVM
    {
        public UserVM()
        {
            AllUser = new List<UserPO>();
            RoleDropDown =  new List<SelectListItem>();
            UserForm = new UserPO();
        }

        public List<UserPO> AllUser { get; set; }

        public UserPO UserForm { get; set; }

        public List<SelectListItem> RoleDropDown { get; set; }
    }
}