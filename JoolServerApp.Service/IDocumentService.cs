using JoolServerApp.Data;
using System.Collections.Generic;

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
