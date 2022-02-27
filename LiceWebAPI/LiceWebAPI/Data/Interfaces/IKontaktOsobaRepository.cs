using LiceWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Data.Interfaces
{
    public interface IKontaktOsobaRepository
    {
        Task<List<KontaktOsoba>> GetAllKontaktOsobe();
        Task<KontaktOsoba> GetKontaktOsobaById(Guid kontaktOsobaId);
        Task<KontaktOsoba> CreateKontaktOsoba(KontaktOsoba kontaktOsoba);
        Task DeleteKontaktOsoba(Guid kontaktOsobaId);
        Task UpdateKontaktOsoba(KontaktOsoba kontaktOsoba);
        Task<bool> IsValidKontaktOsoba(string telefon);
    }
}
