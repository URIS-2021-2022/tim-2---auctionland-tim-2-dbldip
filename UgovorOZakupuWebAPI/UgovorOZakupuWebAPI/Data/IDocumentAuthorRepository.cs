using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public interface IDocumentAuthorRepository
    {
        List<DocumentAuthor> GetDocumentAuthors();
        DocumentAuthor GetDocumentAuthorById(Guid documentAuthorId);
        DocumentAuthorConfirmation CreateDocumentAuthor(DocumentAuthor documentAuthor);
        void UpdateDocumentAuthor(DocumentAuthor documentAuthor);
        void DeleteDocumentAuthor(Guid documentAuthorId);
        bool SaveChanges();
    }
}
