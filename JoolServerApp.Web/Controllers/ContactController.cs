
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Data;
using JoolServerApp.Service;
using JoolServerApp.Web.Models;
using JoolServerApp.Web.ViewModels;
using Microsoft.Ajax.Utilities;

namespace JoolServerApp.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IDepartmentService deptService;
        private readonly IManufacturerService manufactureService;


        public ContactController(IDepartmentService deptService, IManufacturerService manufactureService)
        {
            this.deptService = deptService;
            this.manufactureService = manufactureService;
        }

        // GET: Documents
        public ActionResult Contact()
        {
            ViewBag.Contact_Info = TempData["Product_ID"];
            List<ContactVM> contacts = new List<ContactVM> ();
            foreach (var item in ViewBag.Contact_Info)
            {
                ContactVM tempVM = new ContactVM();
                tempVM.Manufacturer_ID = item.Manufacturer_ID;
                tempVM.Manufacturer_Name = item.Manufacturer_Name;
                tempVM.Department_Phone = item.Department_Phone;
                tempVM.Department_Email = item.Department_Email;
                contacts.Add(tempVM);
            }
            return View();

        }
        
        
    }
}