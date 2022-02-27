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


        public CadastralMunicipalityRepository(ParcelContext context)
        {
            this.context = context;
        }
        public List<CadastralMunicipality> GetCadastralMunicipalities(string nameOfCadastralMunicipality = null)
        {
            return context.CadastralMunicipalities.ToList();
        }

        public CadastralMunicipality GetCadastralMunicipalityById(Guid cadastralMunicipalityId)
        {
            return context.CadastralMunicipalities.FirstOrDefault(e => e.cadastralMunicipalityId == cadastralMunicipalityId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
