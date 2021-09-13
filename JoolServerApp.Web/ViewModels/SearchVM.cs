using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JoolServerApp.Web.ViewModels
{
    public class SearchVM
    {
        public string Category_Name { get; set; }
        public string Product_Name { get; set; }

        public int Category_ID { get; set; }

        public int SubCategory_ID { get; set; }
    }

}