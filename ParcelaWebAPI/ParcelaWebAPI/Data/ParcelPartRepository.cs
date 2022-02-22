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
        public ParcelPartConfirmation CreateParcelPart(ParcelPartCreation parcelPart)
        {
            var mappedParcelPart = mapper.Map<ParcelPart>(parcelPart);
            var createdEntity = context.Add(mappedParcelPart);
            return mapper.Map<ParcelPartConfirmation>(createdEntity.Entity);
        }

        public void DeleteParcelPart(Guid parcelPartId)
        {
            var parcelPart = GetParcelPartById(parcelPartId);
            context.Remove(parcelPart);
        }

        public ParcelPart GetParcelPartById(Guid parcelPartId)
        {
            return context.ParcelParts.FirstOrDefault(e => e.parcelPartId == parcelPartId);
        }

        public List<ParcelPart> GetParcelParts(string partSurfaceArea = null, int partParcelNumber = 0)
        {
            return context.ParcelParts.ToList();
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
