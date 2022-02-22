using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using UgovorOZakupuWebAPI.Entities;
using UgovorOZakupuWebAPI.Models;

namespace UgovorOZakupuWebAPI.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<Entities.Document, DocumentDto>();
            CreateMap<DocumentDto, Entities.Document>();
            CreateMap<Entities.Document, Entities.Document>();
            CreateMap<Entities.Document, DocumentConfirmation>();
        }
    }
}
