using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace JoolServerApp.Web.ViewModel
{
    public class SearchVM
    {
        [DisplayName("Category:")]
        public string Category_Name { get; set; }
        [DisplayName("Product:")]
        public string Product_Name { get; set; }
    }
}