using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JoolServerApp.Web.ViewModels
{
    public class CreateVM
    {
        [DisplayName("User Name:")]
        public string User_Name { get; set; }
        [DisplayName("Email Address:")]
        public string User_Email { get; set; }
        [DisplayName("Profile Pic:")]
        public byte[] User_Image { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string user_Password { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string confirm_Password { get; set; }
    }
}