using AutoMapper;
using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public class CadastralMunicipalityRepository : ICadastralMunicipalityRepository
    {

        private readonly ParcelContext context;
        private readonly IMapper mapper;

        public CadastralMunicipalityRepository(ParcelContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<CadastralMunicipality> GetCadastralMunicipalities(string nameOfCadastralMunicipality = null)
        {
            throw new NotImplementedException();
        }

        public CadastralMunicipality GetCadastralMunicipalityById(Guid cadastralMunicipalityId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
