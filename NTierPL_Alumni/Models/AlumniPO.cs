using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierPL_Alumni.Models
{
    public class AlumniPO
    {

        //alumni records table properties.
        //it hold information.
        //Attributes are used for adding metadata, such as compiler instruction and other information
        //such as comments, description, methods and classes to a program.

        public int RecordID { get; set; }

        //prompt message that needed to fillout cause it is required.
        [Required]
        //tells the specific length of the words fill out.
        [StringLength(50, ErrorMessage = " Complete Name is too long,50 letters max.")]
        //format how you want to see the name of the box in the form.
        [Display(Name ="Complete Name")]
        public string CompleteName { get; set; }


        [Required]
        //determine how many digits you need and also the minimum and maximun number to put.
        [Range(1000,2050,ErrorMessage = "Year must be 4 digits.")]
        [Display(Name = "Year Graduated")]
        public Int16 YearGraduated { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = " Position is too long,50 letters max.")]
        [Display(Name = "Job Position")]
        public string Position { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = " Company is too long,50 letters max.")]
        [Display(Name = "Company")]
        public string Company { get; set; }


        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        public string Department { get; set; }
    }
}