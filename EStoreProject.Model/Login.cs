using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EStoreProject.Model
{
   public class Login
    {
        [Display(Name = "Email_id")]
        public string AdEmail_id { get; set; }


        [Display(Name = "Password")]
        public string AdPassword { get; set; }


    }
}
