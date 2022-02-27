using LiceWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiceWebAPI.Data.Interfaces
{
    public interface IFizickoLiceRepository
    {
        Task<List<FizickoLice>> GetAllFizickaLica();
        Task<FizickoLice> GetFizickoLiceById(Guid liceId);
        Task<FizickoLice> CreateFizickoLice(FizickoLice fizickoLice);
        Task DeleteFizickoLice(Guid liceId);
        Task UpdateFizickoLice(FizickoLice fizickoLice);

    }
}
