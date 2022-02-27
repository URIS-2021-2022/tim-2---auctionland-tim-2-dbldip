using AutoMapper;
using LiceWebAPI.Data.Interfaces;
using LiceWebAPI.Entities;
using LiceWebAPI.Entities.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Data
{
    public class PravnoLiceRepository : IPravnoLiceRepository
    {
        private readonly LiceContext _context;
        private readonly IMapper mapper;

        public PravnoLiceRepository(LiceContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }
        public async Task<List<PravnoLice>> GetAllPravnaLica()
        {
            return await _context.PravnoLice
                .ToListAsync();
        }

        public async Task<PravnoLice> GetPravnoLiceById(Guid liceId)
        {
            return await _context.PravnoLice.FirstOrDefaultAsync(pl => pl.LiceId == liceId);
        }
        public async Task<PravnoLice> CreatePravnoLice(PravnoLice pravnoLice)
        {
            _context.PravnoLice.Add(pravnoLice);
            await _context.SaveChangesAsync();
            return pravnoLice;
        }

        public async Task DeletePravnoLice(Guid liceId)
        {
            var pravnoLice = await GetPravnoLiceById(liceId);
            _context.PravnoLice.Remove(pravnoLice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePravnoLice(PravnoLice pravnoLice)
        {
            await _context.SaveChangesAsync();
        }
    }
}
