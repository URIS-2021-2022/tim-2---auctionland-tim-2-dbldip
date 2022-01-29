using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Data
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext context;
        private readonly IMapper mapper;

        public AddressRepository(AddressContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public AddressConfirmation CreateAddress(Address address)
        {
            var createdEntity = context.Add(address);
            return mapper.Map<AddressConfirmation>(createdEntity.Entity);
        }

        public void DeleteAddress(Guid addressId)
        {
            var address = GetAddressById(addressId);
            context.Remove(address);
        }

        public Address GetAddressById(Guid addressId)
        {
            return context.Addresses.FirstOrDefault(e => e.addressId == addressId);
        }

        public List<Address> GetAddresses(string streetName = null, string town = null, string municipality = null)
        {
            return context.Addresses.Where(e => (streetName == null || e.addressStreet == streetName) 
                                                && (town == null || e.addressTown == town) 
                                                && (municipality == null || e.addressMunicipality == municipality)).ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateAddress(Address address)
        {
        }
    }
}
