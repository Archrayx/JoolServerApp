
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JoolServerApp.Data;
using JoolServerApp.Service;
using JoolServerApp.Web.Models;
using Microsoft.Ajax.Utilities;

namespace JoolServerApp.Web.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IDocumentService documentService;
        // GET: Documents

        public DocumentsController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }
        public ActionResult Documents()
        {
            

            return View();
        }
    }
}