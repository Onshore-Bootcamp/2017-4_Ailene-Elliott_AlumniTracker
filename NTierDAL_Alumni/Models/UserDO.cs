using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDAL_Alumni.Models
{
     public class UserDO
    {
        public Int64 UserID { get; set; }
        public string CompleteName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
    }
}
