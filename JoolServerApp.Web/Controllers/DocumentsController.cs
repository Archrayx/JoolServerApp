using JoolServerApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

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

        public ActionResult Download()
        {

            var doc = documentService.GetDocument(1);
            string filepath = doc.Document_Folder_Path;
            string fullfilepath = AppDomain.CurrentDomain.BaseDirectory + filepath;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filepath,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);

        }

    }
    }