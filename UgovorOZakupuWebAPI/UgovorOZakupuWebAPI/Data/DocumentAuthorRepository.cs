using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;

namespace UgovorOZakupuWebAPI.Data
{
    public class DocumentAuthorRepository : IDocumentAuthorRepository
    {
        private readonly LeaseAgreementContext context;
        private readonly IMapper mapper;

        public DocumentAuthorRepository(LeaseAgreementContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public DocumentAuthorConfirmation CreateDocumentAuthor(DocumentAuthor documentAuthor)
        {
            var createdEntity = context.Add(documentAuthor);
            return mapper.Map<DocumentAuthorConfirmation>(createdEntity.Entity);
        }

        public void DeleteDocumentAuthor(Guid documentAuthorId)
        {
            var documentAuthor = GetDocumentAuthorById(documentAuthorId);
            context.Remove(documentAuthor);
        }

        public DocumentAuthor GetDocumentAuthorById(Guid documentAuthorId)
        {
            return context.DocumentAuthors.FirstOrDefault(e => e.DocumentAuthorId == documentAuthorId);
        }

        public List<DocumentAuthor> GetDocumentAuthors()
        {
            return context.DocumentAuthors.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateDocumentAuthor(DocumentAuthor documentAuthor)
        {
            
        }
    }
}
