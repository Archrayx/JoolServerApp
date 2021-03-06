using JoolServerApp.Service;
using JoolServerApp.Web.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace JoolServerApp.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IDepartmentService deptService;
        private readonly IManufacturerService manufactureService;
        private readonly IProductService productService;

        public ContactController(IDepartmentService deptService, IManufacturerService manufactureService, IProductService productService)
        {
            this.deptService = deptService;
            this.manufactureService = manufactureService;
            this.productService = productService;
        }


        public ActionResult Contact(ProductDetailsVM obj)
        {
            var Contact_Info = from department in deptService.GetAllDepartments()
                               where department.Manufacturer_ID == obj.Manufacturer_ID
                               select department;

            List<ContactVM> contacts = new List<ContactVM>();
            foreach (var item in Contact_Info)
            {
                Debug.WriteLine(item);
                ContactVM tempVM = new ContactVM
                {
                    Manufacturer_ID = item.Manufacturer_ID,
                    Department_Name = item.Department_Name,
                    Department_Phone = item.Department_Phone,
                    Department_Email = item.Department_Email
                };
                contacts.Add(tempVM);
            }
            ViewBag.contact = contacts;
            return View("Contact", obj);

        }


    }
}