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
    public class KontaktOsobaRepository : IKontaktOsobaRepository
    {
        private readonly LiceContext _context;
        private readonly IMapper _mapper;

        public KontaktOsobaRepository(LiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<KontaktOsoba>> GetAllKontaktOsobe()
        {
            return await _context.KontaktOsoba
                .ToListAsync();
        }

        public async Task<KontaktOsoba> GetKontaktOsobaById(Guid kontaktOsobaId)
        {
            return await _context.KontaktOsoba.FirstOrDefaultAsync(ko => ko.KontaktOsobaId == kontaktOsobaId);
        }
        public async Task<KontaktOsoba> CreateKontaktOsoba(KontaktOsoba kontaktOsoba)
        {
            _context.KontaktOsoba.Add(kontaktOsoba);
            await _context.SaveChangesAsync();
            return kontaktOsoba;
        }

        public async Task DeleteKontaktOsoba(Guid kontaktOsobaId)
        {
            var kontaktOsoba = await GetKontaktOsobaById(kontaktOsobaId);
            _context.KontaktOsoba.Remove(kontaktOsoba);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKontaktOsoba(KontaktOsoba kontaktOsoba)
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsValidKontaktOsoba(string telefon)
        {
            var listaKontaktOsoba = await _context.KontaktOsoba.Where(ko => ko.Telefon == telefon).ToListAsync();
            return listaKontaktOsoba.Count == 0;
        }
    }
}
