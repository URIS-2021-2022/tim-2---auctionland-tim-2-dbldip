using ComplaintAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Data.Interfaces
{
    /// <summary>
    /// Interfejs za keriranje repozitorijuma za status žalbe
    /// </summary>
    interface IComplaintStatusRepository
    {
        /// <summary>
        /// Prikazivanje liste sa podacima svih statusa žalbi
        /// </summary>
        /// <retuns>Listu statusa žalbi</retuns>
        public List<ComplaintStatus> GetAllComplaintStatus(string complaintStatus = null);

        /// <summary>
        /// Prikazivanje statusa žalbe po ID-ju
        /// </summary>
        /// <param name="complaintStatusId">ID statusa žalbe</param>
        /// <returns>Objekat statusa žalbe</returns>
        public ComplaintStatus GetComplaintStatusById(Guid complaintStatusId);

        /// <summary>
        /// Kreiranje statusa žalbe
        /// </summary>
        /// <param name="complaintStatus">Objekat statusa žalbe</param>
        public ComplaintStatus CreateComplaintStatus(ComplaintStatus complaintStatus);


        /// <summary>
        /// Brisanje statusa žalbe
        /// </summary>
        /// <param name="complaintStatusId">ID statusa žalbe</param>
        public void DeleteComplaintStatus(Guid complaintStatusId);


        /// <summary>
        /// Izmena statusa žalbe
        /// </summary>
        /// <param name="complaintStatus">Objekat statusa žalbe</param>
        public void UpdateComplaintStatus(ComplaintStatus complaintStatus);

        /// <summary>
        /// Provera validnosti unesenog statusa žalbe
        /// </summary>
        /// <param name="complaintStatus">Objekat statusa žalbe</param>
        /// <returns>
        /// true - status žalbe ne postoji u bazi
        /// false - status žalbe već postoji u bazi
        /// </returns>
        public bool isValidComplaintStatus(string complaintStatus);
    }
}
