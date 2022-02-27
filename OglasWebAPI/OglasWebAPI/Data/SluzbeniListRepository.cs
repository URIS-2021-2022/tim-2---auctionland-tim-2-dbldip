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
    public class SluzbeniListRepository : ISluzbeniListRepository
    {
        private readonly OglasContext _context;
        private readonly IMapper mapper;

        public SluzbeniListRepository(OglasContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<List<SluzbeniList>> GetAllSluzbeniListovi()
        {
            return await _context.SluzbeniList
                .ToListAsync();
        }

        public async Task<SluzbeniList> GetSluzbeniListById(Guid sluzbeniListId)
        {
            return await _context.SluzbeniList.FirstOrDefaultAsync(sl => sl.SluzbeniListId == sluzbeniListId);
        }

        public async Task<SluzbeniList> CreateSluzbeniList(SluzbeniList sluzbeniList)
        {
            _context.SluzbeniList.Add(sluzbeniList);
            await _context.SaveChangesAsync();
            return sluzbeniList;
        }

        public async Task DeleteSluzbeniList(Guid sluzbeniListId)
        {
            var sluzbeniList = await GetSluzbeniListById(sluzbeniListId);
            _context.SluzbeniList.Remove(sluzbeniList);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSluzbeniList(SluzbeniList sluzbeniList)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsValidSluzbeniList(string broj)
        {
            var listaSluzbenihListova = await _context.SluzbeniList.Where(sl => sl.Broj == broj).ToListAsync();
            return listaSluzbenihListova.Count == 0;
        }
    }
}
