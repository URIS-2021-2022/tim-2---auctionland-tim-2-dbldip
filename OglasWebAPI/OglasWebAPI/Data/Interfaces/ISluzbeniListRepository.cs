using OglasWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglasWebAPI.Data.Interfaces
{
    public interface ISluzbeniListRepository
    {
        Task<List<SluzbeniList>> GetAllSluzbeniListovi();
        Task<SluzbeniList> GetSluzbeniListById(Guid sluzbeniListId);
        Task<SluzbeniList> CreateSluzbeniList(SluzbeniList sluzbeniList);
        Task DeleteSluzbeniList(Guid sluzbeniListId);
        Task UpdateSluzbeniList(SluzbeniList sluzbeniList);
        Task<bool> IsValidSluzbeniList(string broj);

    }
}
