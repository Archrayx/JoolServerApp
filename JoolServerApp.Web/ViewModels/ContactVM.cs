using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace JoolServerApp.Web.ViewModels
{
    public class ContactVM
    {
        public string Manufacturer_Name { get; set; }

        public string Department_Name { get; set; }

        public string Department_Phone { get; set; }

        public string Department_Email { get; set; }

        public int Manufacturer_ID { get; set; }
    }
}
