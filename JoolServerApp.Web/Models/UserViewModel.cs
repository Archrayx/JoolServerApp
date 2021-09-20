using System;
using System.ComponentModel.DataAnnotations;
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