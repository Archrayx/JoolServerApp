using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JoolServerApp.Repo;
using JoolServerApp.Data;

namespace JoolServerApp.Service
{
    public class DocumentService:IDocumentService
    {
        private IRepository<tblDocument> documentRepository;
        public DocumentService(IRepository<tblDocument> documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public void DeleteDocument(long id)
        {
            tblDocument document = documentRepository.Get(id);
            documentRepository.Remove(document);
            documentRepository.SaveChanges();
        }

        public IEnumerable<tblDocument> GetAllDocuments()
        {
            return documentRepository.GetAll();
        }

        public tblDocument GetDocument(long id)
        {
            return documentRepository.Get(id);

        }

        public void insertDocument(tblDocument document)
        {
            documentRepository.Insert(document);
            documentRepository.SaveChanges();
        }

        public void UpdateDocument(tblDocument document)
        {
            documentRepository.Update(document);
            documentRepository.SaveChanges();

        }
    }
}