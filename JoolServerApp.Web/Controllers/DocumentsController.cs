using JoolServerApp.Service;
using JoolServerApp.Web.ViewModels;
using System;
using System.Diagnostics;
using System.Net;
using System.Web;
using System.Web.Mvc;

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


        public ActionResult Document(ProductDetailsVM obj)
        {

            return View(obj);
        }
        public ActionResult Download(object sender, EventArgs e, ProductDetailsVM obj)
        {

            var doc = documentService.GetDocument(obj.Document_ID);
            string filename = doc.Document_Folder_Path;
            string filepath = AppDomain.CurrentDomain.BaseDirectory + @"Documents\" + filename;
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

            return View("Document", obj);



        }

    }
}