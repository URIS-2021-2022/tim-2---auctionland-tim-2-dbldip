using ComplaintAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Data.Interfaces
{
    /// <summary>
    /// Interfejs za kreiranje repozitorijuma za tip žalbe
    /// </summary>
    public interface IComplaintTypeRepository
    {
        /// <summary>
        /// Prikazivanje liste sa podacima svih tipova žalbi
        /// </summary>
        /// <returns>Listu tipova žalbi</returns>
        public List<ComplaintType> GetAllComplaintTypes(string complaintType = null);

        /// <summary>
        /// Prikazivanje tipa žalbe na osnovu prosleđenog ID-ja
        /// </summary>
        /// <param name="complaintTypeId">ID tipa žalbe</param>
        /// <returns>Objekat tipa žalbe</returns>
        public ComplaintType GetComplaintTypeById(Guid complaintTypeId);

        /// <summary>
        /// Kreiranje tipa žalbe
        /// </summary>
        /// <param name="complaintType">Objekat tipa žačbe</param>
        public ComplaintType CreateComplaintType(ComplaintType complaintType);

        /// <summary>
        /// Izmena tipa žalbe
        /// </summary>
        /// <param name="complaintType">Objekat tipa žalbe</param>
        public void UpdateComplaintType(ComplaintType complaintType);

        /// <summary>
        /// Brisanje tipa žalbe
        /// </summary>
        /// <param name="complaintType">Objekat tipa žalbe</param>
        public void DeleteComplaintType(Guid complaintTypeId);

        /// <summary>
        /// Provera validnosti unešenog tipa žalbe
        /// </summary>
        /// <param name="complaintType">Naziv tipa žalbe</param>
        /// <returns>
        /// true - tip žalbe ne postoji u bazi
        /// false - tip žalbe već postoji u bazi
        /// </returns>
        public bool isValidComplaintType(string complaintType);
    }
}
