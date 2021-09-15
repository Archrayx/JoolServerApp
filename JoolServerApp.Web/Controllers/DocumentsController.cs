using JoolServerApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Reflection.Metadata;
using System.Diagnostics;

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

        public ActionResult Document()
        {

            return View();
        }

        public ActionResult Download(object sender, EventArgs e)
        {

            var doc = documentService.GetDocument(1);
            string filename = doc.Document_Folder_Path;
            string filepath = AppDomain.CurrentDomain.BaseDirectory + @"Item_Docs\" + filename;
            Debug.WriteLine(filepath);
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };
            WebClient req = new WebClient();
            HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath(filename) + "\"");
            byte[] data = req.DownloadData(Server.MapPath(filename));
            response.BinaryWrite(data);
            response.End();

            return View("Document");

            

        }

    }
    }