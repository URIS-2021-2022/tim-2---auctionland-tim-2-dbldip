using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OglasWebAPI.Data.Interfaces;
using OglasWebAPI.Entities;
using OglasWebAPI.Entities.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Data
{
    public class OglasRepository : IOglasRepository
    {
        private readonly OglasContext _context;
        private readonly IMapper _mapper;

        public OglasRepository(OglasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Oglas>> GetAllOglasi()
        {
            return await _context.Oglas
                .ToListAsync();
        }

        public async Task<Oglas> GetOglasById(Guid oglasId)
        {
            return await _context.Oglas.FirstOrDefaultAsync(o => o.OglasId == oglasId);
        }

        public async Task<Oglas> CreateOglas(Oglas oglas)
        {
            _context.Oglas.Add(oglas);
            await _context.SaveChangesAsync();
            return oglas;
        }

        public async Task DeleteOglas(Guid oglasId)
        {
            var oglas = await GetOglasById(oglasId);
            _context.Oglas.Remove(oglas);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOglas(Oglas oglas)
        {
            await _context.SaveChangesAsync();
        }

    }
}
