using AutoMapper;
using ComplaintAPI.Entities;
using ComplaintAPI.Models;
using ComplaintAPI.Models.Complaint;
using ComplaintService.Data.Interfaces;
using ComplaintService.Entities.Confirmations;
using ComplaintService.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Data
{
    /// <summary>
    /// Repozitorijum za žalbu
    /// </summary>
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly ComplaintContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Kontruktor repozitorijuma žačbe
        /// </summary>
        /// <param name="context">Db context</param>
        /// <param name="mapper">AutoMapper</param>
        public ComplaintRepository(ComplaintContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Kreiranje žalbe
        /// </summary>
        /// <param name="complaint">Objekat žalbe</param>
        public ComplaintConfirmation CreateComplaint(Complaint complaint)
        {
            var createdEntity = context.Add(complaint);
            context.SaveChanges();
            return mapper.Map<ComplaintConfirmation>(createdEntity.Entity) ;
        }

        /// <summary>
        /// Brisanje žalbe
        /// </summary>
        /// <param name="complaintId">Id žalbe za brisanje</param>
        public void DeleteComplaint(Guid complaintId)
        {
            var complaintToDelete = GetComplaintById(complaintId);
            context.Complaint.Remove(complaintToDelete);
            context.SaveChanges();
        }

        /// <summary>
        /// Dobijanje liste svih žalbi
        /// </summary>
        public List<Complaint> GetAllComplaints()
        {
            var complaints = context.Complaint.ToList();
            if(complaints == null || complaints.Count == 0)
            {
                return null;
            }

            List<Complaint> returnList = mapper.Map<List<Complaint>>(complaints);
            foreach(var com in returnList)
            {
                com.complaintStatus = context.ComplaintStatus.FirstOrDefault(cs => cs.complaintStatusId == com.complaintStatusId);
                com.complaintType = context.ComplaintType.FirstOrDefault(ct => ct.complaintTypeId == com.complaintTypeId);
                com.actionTaken = context.ActionTaken.FirstOrDefault(at => at.actionTakenId == com.actionTakenId);
            }

            return returnList;
        }

        /// <summary>
        /// Dobijanje žalbe sa prosleđenim Id-jem
        /// </summary>
        /// <param name="complaintId">Id žalbe</param>
        public Complaint GetComplaintById(Guid complaintId)
        {
            var complaint = context.Complaint.FirstOrDefault(com => com.complaintId == complaintId);
            if(complaint == null)
            {
                return null;
            }

            var returnComplaint = mapper.Map<Complaint>(complaint);

            returnComplaint.complaintStatus = context.ComplaintStatus.FirstOrDefault(cs => cs.complaintStatusId == returnComplaint.complaintStatusId);
            returnComplaint.complaintType = context.ComplaintType.FirstOrDefault(ct => ct.complaintTypeId == returnComplaint.complaintTypeId);
            returnComplaint.actionTaken = context.ActionTaken.FirstOrDefault(at => at.actionTakenId == returnComplaint.actionTakenId);
            return returnComplaint;

        }

        /// <summary>
        /// Provera da li je žalba validna
        /// </summary>
        /// <param name="complaint">Objekat žalba</param>
        /// <returns>
        /// true - ne postoji već
        /// false - već postoji u bazi
        /// </returns>
        public bool isValidComplaint(ComplaintDto complaint)
        {
            var existingComplaints = context.Complaint.Where(a => a.procedureNumber == complaint.procedureNumber || a.decisionNumber == complaint.decisionNumber).ToList();
            return existingComplaints.Count() == 0;
        }

        /// <summary>
        /// Izmena žalbe
        /// </summary>
        /// <param name="complaint">Objekat žalbe za izmenu</param>
        public void UpdateComplaint(Complaint complaint)
        {
            context.SaveChanges();
        }
    }
}
