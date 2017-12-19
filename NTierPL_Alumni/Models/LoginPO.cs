using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NTierPL_Alumni.Models
{
    public class LoginPO
    {
        [Required]
        [StringLength(25, ErrorMessage = "Username is too long")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*.()+=]).{4,8}",
            ErrorMessage = "Required format: 4 to 8 character in length with 1 number (0-9),1 upper case letter (A-Z),1 distinct character (!@#$%^&*.()+=)")]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}