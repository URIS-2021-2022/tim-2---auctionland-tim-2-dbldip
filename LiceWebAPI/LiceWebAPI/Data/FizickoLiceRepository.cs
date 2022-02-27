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
    public class FizickoLiceRepository : IFizickoLiceRepository
    {
        private readonly LiceContext _context;
        private readonly IMapper _mapper;

        public FizickoLiceRepository(LiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<FizickoLice>> GetAllFizickaLica()
        {
            return await _context.FizickoLice
                .ToListAsync();
        }
        public async Task<FizickoLice> GetFizickoLiceById(Guid liceId)
        {
            return await _context.FizickoLice.FirstOrDefaultAsync(fl => fl.LiceId == liceId);
        }

        public async Task<FizickoLice> CreateFizickoLice(FizickoLice fizickoLice)
        {
            _context.FizickoLice.Add(fizickoLice);
            await _context.SaveChangesAsync();
            return fizickoLice;
        }

        public async Task DeleteFizickoLice(Guid liceId)
        {
            var fizickoLice = await GetFizickoLiceById(liceId);
            _context.FizickoLice.Remove(fizickoLice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFizickoLice(FizickoLice fizickoLice)
        {
            await _context.SaveChangesAsync();
        }
    }
}
