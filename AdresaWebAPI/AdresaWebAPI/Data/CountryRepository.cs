using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Data
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AddressContext context;
        private readonly IMapper mapper;

        public CountryRepository(AddressContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public CountryConfirmation CreateCountry(Country country)
        {
            var createdEntity = context.Add(country);
            return mapper.Map<CountryConfirmation>(createdEntity.Entity);
        }

        public void DeleteCountry(Guid countryID)
        {
            var country = GetCountryById(countryID);
            context.Remove(country);
        }

        public Country GetCountryById(Guid countryID)
        {
            return context.Countries.FirstOrDefault(e => e.countryID == countryID);
        }

        public List<Country> GetCrountires(string countryName = null)
        {
            return context.Countries.Where(e => (countryName == null || e.countryName == countryName)).ToList();
        }

        public void UpdateCountry(Country country)
        {
            //EF implements this method, works with saveChanges()
        }

    }
}
