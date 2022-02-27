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
    /// Repozitorijum za status žalbe
    /// </summary>
    public class ComplaintStatusRepository : IComplaintStatusRepository
    {
        private readonly ComplaintContext context;

        /// <summary>
        /// Konstruktor Repozitorijuma statusa žalbi
        /// </summary>
        /// <param name="context">Db context</param>
        public ComplaintStatusRepository(ComplaintContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Dobijanje liste svih statusa žalbi
        /// </summary>
        /// <param name="complaintStatus">Naziv statusa žalbe</param>
        /// <returns>Listu statusa žalbi</returns>
        public List<ComplaintStatus> GetAllComplaintStatus(string complaintStatus = null)
        {
            return context.ComplaintStatus
                .Where(cs => (complaintStatus == null || cs.complaintStatus == complaintStatus))
                .ToList();
        }

        /// <summary>
        /// Dobijanje statusa žalbe sa prosleđenim ID-jem
        /// </summary>
        /// <param name="complaintStatusId">ID željenog statusa žalbe</param>
        /// <returns>Objekat statusa žalbe</returns>
        public ComplaintStatus GetComplaintStatusById(Guid complaintStatusId)
        {
            return context.ComplaintStatus.FirstOrDefault(cs => cs.complaintStatusId == complaintStatusId);
        }

        /// <summary>
        /// Kreiranje statusa žalbe
        /// </summary>
        /// <param name="complaintStatus">Objekat statusa žalbe</param>
        /// <returns>Potvrdu kreirog objekta statusa žalbe</returns>
        public ComplaintStatus CreateComplaintStatus(ComplaintStatus complaintStatus)
        {
            context.ComplaintStatus.Add(complaintStatus);
            context.SaveChanges();

            return complaintStatus;
        }

        /// <summary>
        /// Izmena statusa žalbe
        /// </summary>
        /// <param name="complaintStatus">Objekat statusa žalbe</param>
        public void UpdateComplaintStatus(ComplaintStatus complaintStatus)
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Brisanje statusa žalbe
        /// </summary>
        /// <param name="complaintStatusId">ID statusa žalbe za brisanje</param>
        public void DeleteComplaintStatus(Guid complaintStatusId)
        {
            var complaintStatusToDelete = context.ComplaintStatus.FirstOrDefault(cs => cs.complaintStatusId == complaintStatusId);

            context.ComplaintStatus.Remove(complaintStatusToDelete);
            context.SaveChanges();
        }

        /// <summary>
        /// Validacija statusa žalbe
        /// </summary>
        /// <param name="complaintStatus">Naziv statusa žalbe</param>
        /// <returns>
        /// true - status žalbe ne postoji u bazi, unos je validan
        /// false - status žalbe već postoji u bazi, unos nije validan
        /// </returns>
        public bool isValidComplaintStatus(string complaintStatus)
        {
            var complaintStatusList = context.ComplaintStatus
                .Where(cs => cs.complaintStatus == complaintStatus)
                .ToList();

            return complaintStatusList.Count == 0;
        }

    }
}
