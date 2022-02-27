using ComplaintAPI.Entities;
using ComplaintService.Data.Interfaces;
using ComplaintService.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Data
{
    /// <summary>
    /// Repozitorijum za tip žalbe
    /// </summary>
    public class ComplaintTypeRepository : IComplaintTypeRepository
    {
        private readonly ComplaintContext context;

        /// <summary>
        /// Kontruktor repozitorijuma tip žalbe
        /// </summary>
        public ComplaintTypeRepository(ComplaintContext context)
        {
            this.context = context;
        }

        
        /// <summary>
        /// Dobijanje liste svih tipova žalbi
        /// </summary>
        /// <param name="complaintType">Naziv tipa žalbi</param>
        /// <returns></returns>
        public List<ComplaintType> GetAllComplaintTypes(string complaintType = null)
        {
            return context.ComplaintType
                .Where(ct => (complaintType == null || ct.complaintType == complaintType))
                .ToList();
        }

        /// <summary>
        /// Dobijanje tipa žalbe sa prosleđenim ID-jem
        /// </summary>
        /// <param name="complaintTypeId">ID tipa žalbe</param>
        /// <returns></returns>
        public ComplaintType GetComplaintTypeById(Guid complaintTypeId)
        {
            return context.ComplaintType.FirstOrDefault(ct => ct.complaintTypeId == complaintTypeId);
        }

        /// <summary>
        /// Kreiranje tipa žalbe
        /// </summary>
        /// <param name="complaintType">Objekat tipa žalbe</param>
        /// <returns>Kreirani tip žalbe</returns>
        public ComplaintType CreateComplaintType(ComplaintType complaintType)
        {
            context.ComplaintType.Add(complaintType);
            context.SaveChanges();

            return complaintType;
        }

        /// <summary>
        /// Izmena tipa žalbe
        /// </summary>
        /// <param name="complaintType">Objekat tipa žalbe</param>
        public void UpdateComplaintType(ComplaintType complaintType)
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Brisanje tipa žalbe
        /// </summary>
        /// <param name="complaintTypeId">ID tipa žalbe</param>
        public void DeleteComplaintType(Guid complaintTypeId)
        {
            var complaintTypeToDelete = GetComplaintTypeById(complaintTypeId);

            context.ComplaintType.Remove(complaintTypeToDelete);
            context.SaveChanges();
        }

        public bool isValidComplaintType(string complaintType)
        {
            var complaintTypesList = context.ComplaintType
                .Where(ct => ct.complaintType == complaintType)
                .ToList();

            return complaintTypesList.Count == 0;
        }

    }
}
