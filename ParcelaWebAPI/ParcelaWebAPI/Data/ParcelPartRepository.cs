using AutoMapper;
using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public class ParcelPartRepository : IParcelPartRepository
    {

        private readonly ParcelContext context;
        private readonly IMapper mapper;

        public ParcelPartRepository(ParcelContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ParcelPart CreateParcelPart(ParcelPart parcelPart)
        {
            var createdEntity = context.Add(parcelPart);
            return mapper.Map<ParcelPart>(createdEntity.Entity);
        }

        public void DeleteParcelPart(Guid parcelPartId)
        {
            throw new NotImplementedException();
        }

        public ParcelPart GetParcelPartById(Guid parcelPartId)
        {
            throw new NotImplementedException();
        }

        public List<ParcelPart> GetParcelParts(string partSurfaceArea = null, int partParcelNumber = 0)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateParcelPart(ParcelPart parcelPart)
        {
            throw new NotImplementedException();
        }
    }
}
