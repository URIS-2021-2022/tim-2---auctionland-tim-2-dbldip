using OglasWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Data.Interfaces
{
    public interface IOglasRepository
    {
        Task<List<Oglas>> GetAllOglasi();
        Task<Oglas> GetOglasById(Guid oglasId);
        Task<Oglas> CreateOglas(Oglas oglas);
        Task DeleteOglas(Guid oglasId);
        Task UpdateOglas(Oglas oglas);
    }
}
