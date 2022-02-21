using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly LeaseAgreementContext context;
        private readonly IMapper mapper;

        public DocumentRepository(LeaseAgreementContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public DocumentConfirmation CreateDocument(Document document)
        {
            var createdEntity = context.Add(document);
            return mapper.Map<DocumentConfirmation>(createdEntity.Entity);
        }

        public void DeleteDocument(Guid documentId)
        {
            var document = GetDocumentById(documentId);
            context.Remove(document);
        }

        public Document GetDocumentById(Guid documentId)
        {
            return context.Documents.FirstOrDefault(e => e.DocumentId == documentId);
        }

        public List<Document> GetDocuments(string fileNumber = null)
        {
            return context.Documents.Where(e => (fileNumber == null || e.FileNumber == fileNumber)).ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateDocument(Document document)
        {
        }
    }
}
