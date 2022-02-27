using LiceWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Data.Interfaces
{
    public interface ILiceRepository
    {
        Task<List<Lice>> GetAllLica();
        Task<Lice> GetLiceById(Guid liceId);
    }
}
