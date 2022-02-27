using LiceWebAPI.Data.Interfaces;
using LiceWebAPI.Entities;
using LiceWebAPI.Entities.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Data
{
    public class LiceRepository : ILiceRepository
    {
        private readonly IPravnoLiceRepository _pravnoLiceRepository;
        private readonly IFizickoLiceRepository _fizickoLiceRepository;


        public LiceRepository(IPravnoLiceRepository pravnoLiceRepository, IFizickoLiceRepository fizickoLiceRepository)
        {
            this._pravnoLiceRepository = pravnoLiceRepository;
            this._fizickoLiceRepository = fizickoLiceRepository;

        }
        public async Task<List<Lice>> GetAllLica()
        {
            List<Lice> lica = new List<Lice>();


            var pravnaLica = await _pravnoLiceRepository.GetAllPravnaLica();
            if (pravnaLica != null && pravnaLica.Count > 0)
                lica.AddRange(pravnaLica);

            var fizickaLica = await _fizickoLiceRepository.GetAllFizickaLica();
            if (fizickaLica != null && fizickaLica.Count > 0)
                lica.AddRange(fizickaLica);

            return lica;
        }

        public async Task<Lice> GetLiceById(Guid liceId)
        {
            Lice lice = await _fizickoLiceRepository.GetFizickoLiceById(liceId);
            if (lice == null)
                lice = await _pravnoLiceRepository.GetPravnoLiceById(liceId);

            return lice;
        }
    }
}
