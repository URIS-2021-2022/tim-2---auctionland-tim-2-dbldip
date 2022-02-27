using ParcelaWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Data
{
    public interface ICadastralMunicipalityRepository 
    {
        List<CadastralMunicipality> GetCadastralMunicipalities(string nameOfCadastralMunicipality = null);
        CadastralMunicipality GetCadastralMunicipalityById(Guid cadastralMunicipalityId);
        bool SaveChanges();
    }
}
