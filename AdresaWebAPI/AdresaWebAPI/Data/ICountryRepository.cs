using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Data
{
    public interface ICountryRepository
    {
        List<Country> GetCrountires(string countryName = null);
        Country GetCountryById(Guid countryID);
        CountryConfirmation CreateCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(Guid countryID);
        bool SaveChanges();
    }
}
