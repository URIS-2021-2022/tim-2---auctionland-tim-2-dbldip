using AutoMapper;
using ComplaintAPI.Entities;
using ComplaintAPI.Models;
using ComplaintAPI.Models.Complaint;
using ComplaintService.Entities.Confirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.MappingProfiles
{
    /// <summary>
    /// Maper za klasu žalba
    /// </summary>
    public class ComplaintProfile : Profile
    {
        /// <summary>
        /// Konstruktor za mapiranje žalbe
        /// </summary>
        public ComplaintProfile()
        {
            CreateMap<Complaint, ComplaintDto>()
                .ForMember(
                    dest => dest.complaintStatus,
                    opt => opt.MapFrom(src => $"{ src.complaintStatus.complaintStatus}"))
                .ForMember(
                    dest => dest.complaintType,
                    opt => opt.MapFrom(src => $"{ src.complaintType.complaintType}"))
                .ForMember(
                    dest => dest.actionTaken,
                    opt => opt.MapFrom(src => $"{ src.actionTaken.actionTaken}"));

            CreateMap<Complaint, ComplaintDto>().ReverseMap();
            CreateMap<ComplaintUpdateDto, Complaint>().ReverseMap();
            CreateMap<Complaint, Complaint>();
            CreateMap<ComplaintConfirmation, ComplaintConfirmationDto>();
            CreateMap<Complaint, ComplaintConfirmation>();
        }
    }
}
