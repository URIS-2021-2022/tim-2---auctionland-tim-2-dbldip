﻿using AutoMapper;
using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public class ParcelRepository : IParcelRepository
    {

        private readonly ParcelContext context;
        private readonly IMapper mapper;

        public ParcelRepository(ParcelContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ParcelConfirmation CreateParcel(Parcel parcel)
        {
            var createdEntity = context.Add(parcel);
            return mapper.Map<ParcelConfirmation>(createdEntity.Entity);
        }

        public void DeleteParcel(Guid parcelId)
        {
            throw new NotImplementedException();
        }

        public Parcel GetParcelById(Guid parcelId)
        {
            throw new NotImplementedException();
        }

        public List<Parcel> GetParcels(string surfaceArea = null, int parcelNumber = 0)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateParcel(Parcel parcel)
        {
            throw new NotImplementedException();
        }
    }
}
