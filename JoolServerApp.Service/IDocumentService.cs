using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoolServerApp.Data;

namespace JoolServerApp.Service
{
    public interface IDocumentService
    {
        IEnumerable<tblDocument> GetAllDocuments();
        tblDocument GetDocument(long id);
        void insertDocument(tblDocument document);
        void UpdateDocument(tblDocument document);
        void DeleteDocument(long id);
    }
}
