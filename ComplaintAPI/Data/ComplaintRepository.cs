using ComplaintAPI.Models;
using ComplaintAPI.Models.Complaint;
using ComplaintService.Data.Interfaces;
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
        //private readonly ComplaintContext context;
        //private readonly IMapper mapper;
        public ComplaintConfirmationDto CreateComplaint(ComplaintDto complaint)
        {
            throw new NotImplementedException();
        }

        public void DeleteComplaint(Guid complaintId)
        {
            throw new NotImplementedException();
        }

        public List<ComplaintDto> GetAllComplaints()
        {
            throw new NotImplementedException();
        }

        public ComplaintDto GetComplaintById(Guid complaintId)
        {
            throw new NotImplementedException();
        }

        public bool isValidComplaint(ComplaintDto complaint)
        {
            throw new NotImplementedException();
        }

        public ComplaintConfirmationDto UpdateComplaint(ComplaintDto complaint)
        {
            throw new NotImplementedException();
        }
    }
}
