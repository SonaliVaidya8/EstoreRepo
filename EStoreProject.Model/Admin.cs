using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EStoreProject.Model
{
    public class Admin
    {
        [Display(Name = "First Name")]
        public string AdFirstName { get; set; }


        [Display(Name = "Last Name")]
        public string AdLastName { get; set; }


        [Display(Name = "Contact Number")]
        public string AdContactNumber { get; set; }


        [Display(Name = "Email_id")]
        public string AdEmail_id { get; set; }


        [Display(Name = "Password")]
        public string AdPassword { get; set; }




        }
    }

