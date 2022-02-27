using AdresaWebAPI.Entities;
using AdresaWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdresaWebAPI.Data
{
    public interface IAddressRepository
    {
        List<Address> GetAddresses(string streetName = null, string town = null, string municipality = null);
        Address GetAddressById(Guid addressId);
        AddressConfirmation CreateAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(Guid addressId);
        bool SaveChanges();

    }
}
