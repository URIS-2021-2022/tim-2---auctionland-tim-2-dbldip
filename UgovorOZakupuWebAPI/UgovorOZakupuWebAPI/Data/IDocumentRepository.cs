using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public interface IDocumentRepository
    {
        List<Document> GetDocuments(string fileNumber = null);
        Document GetDocumentById(Guid documentId);
        DocumentConfirmation CreateDocument(Document document);
        void UpdateDocument(Document document);
        void DeleteDocument(Guid documentId);
        bool SaveChanges();

    }
}
