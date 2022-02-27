using LiceWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Data.Interfaces
{
    public interface IPravnoLiceRepository
    {
        Task<List<PravnoLice>> GetAllPravnaLica();
        Task<PravnoLice> GetPravnoLiceById(Guid liceId);
        Task<PravnoLice> CreatePravnoLice(PravnoLice pravnoLice);
        Task DeletePravnoLice(Guid liceId);
        Task UpdatePravnoLice(PravnoLice pravnoLice);

    }
}
