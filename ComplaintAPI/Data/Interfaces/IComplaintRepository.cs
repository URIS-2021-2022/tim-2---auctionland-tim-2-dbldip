using ComplaintAPI.Entities;
using ComplaintAPI.Models;
using ComplaintAPI.Models.Complaint;
using ComplaintService.Entities.Confirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Data.Interfaces
{
    /// <summary>
    /// Interfejs za kreiranje repozitorijuma za žalbu
    /// </summary>
    public interface IComplaintRepository
    {
        /// <summary>
        /// Dobijanje podataka o svim žalbama
        /// </summary>
        /// <returns>Listu svih kreiranih žalbi</returns>
        List<Complaint> GetAllComplaints();

        /// <summary>
        /// Dobijanje podataka o žalbi po id-u
        /// </summary>
        /// <param name="complaintId">ID željene žalbe</param>
        /// <returns>Žalbu sa prosleđenim id-jem</returns>
        Complaint GetComplaintById(Guid complaintId);

        /// <summary>
        /// Kreiranje žalbe
        /// </summary>
        /// <param name="complaint">Žalba objekat</param>
        /// <returns>Objekat potvrde kreiranja žalbe</returns>
        ComplaintConfirmation CreateComplaint(Complaint complaint);

        /// <summary>
        /// Izmena žalbe
        /// </summary>
        /// <param name="complaint">Žalba objekat</param>
        /// <returns>Objekat potvrde izmene žalbe</returns>
        void UpdateComplaint(Complaint complaint);

        /// <summary>
        /// Brisanje žalbe
        /// </summary>
        /// <param name="complaintId">ID žalbe za brisanje</param>
        void DeleteComplaint(Guid complaintId);

        /// <summary>
        /// Provera validnosti unete žalbe
        /// </summary>
        /// <param name="complaint">Prosleđena žalba</param>
        /// <returns>Informaciju o validnosti žalbe</returns>
        bool isValidComplaint(ComplaintDto complaint);
    }
}
