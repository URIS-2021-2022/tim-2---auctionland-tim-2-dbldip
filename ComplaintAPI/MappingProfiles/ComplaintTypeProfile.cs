using AutoMapper;
using ComplaintAPI.Entities;
using ComplaintAPI.Models.ComplaintType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.MappingProfiles
{
    /// <summary>
    /// Maper za klasu tip žalbe
    /// </summary>
    public class ComplaintTypeProfile : Profile
    {
        /// <summary>
        /// Konstruktor za mapiranje tipa žalbe
        /// </summary>
        public ComplaintTypeProfile()
        {
            CreateMap<ComplaintType, ComplaintTypeCreateDto>().ReverseMap();
            CreateMap<ComplaintTypeUpdateDto, ComplaintType>();
            CreateMap<ComplaintType, ComplaintType>();
            CreateMap<ComplaintType, ComplaintTypeDto>();
        }
    }
}
