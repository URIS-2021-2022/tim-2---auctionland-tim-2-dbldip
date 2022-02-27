using AutoMapper;
using ComplaintAPI.Entities;
using ComplaintAPI.Models.ComplaintStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.MappingProfiles
{
    /// <summary>
    /// Maper za klasu status žalbe
    /// </summary>
    public class ComplaintStatusProfile : Profile
    {
        /// <summary>
        /// Konstruktor za mapiranje statusa žalbe
        /// </summary>
        public ComplaintStatusProfile()
        {
            CreateMap<ComplaintStatus, ComplaintStatusDto>().ReverseMap();
            CreateMap<ComplaintStatusUpdateDto, ComplaintStatus>();
            CreateMap<ComplaintStatus, ComplaintStatus>();
            CreateMap<ComplaintStatus, ComplaintStatusDto>();
        }
    }
}
