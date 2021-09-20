using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoolServerApp.Web.ViewModels
{
    public class ProductDetailsVM
    {
        public int? Product_ID { get; set; }
        public string Product_Name { get; set; }
        //public string Product_Image { get; set; } 
        public string Series { get; set; }
        public string Model { get; set; }
        public string Series_Info { get; set; }
        public int? Manufacturer_ID { get; set; }
        public int? Sales_ID { get; set; }
        public int ? SubCategory_ID { get; set;}
        public int Document_ID { get; set; }




    }
}