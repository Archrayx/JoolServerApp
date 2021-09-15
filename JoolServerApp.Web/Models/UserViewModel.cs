using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoolServerApp.Web.Models
{
    public class UserViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
    }
}