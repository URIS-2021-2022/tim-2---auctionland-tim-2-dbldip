using AutoMapper;
using ComplaintAPI.Models.ActionTaken;
using ComplaintService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.MappingProfiles
{
    /// <summary>
    /// Maper za klasu radnja na osnovu žalbe
    /// </summary>
    public class ActionTakenProfile : Profile
    {
        /// <summary>
        /// Konstruktor za mapiranje radnje na osnovu žalbe
        /// </summary>
        public ActionTakenProfile()
        {
            CreateMap<ActionTaken, ActionTakenCreateDto>().ReverseMap();
            CreateMap<ActionTakenUpdateDto, ActionTaken>();
            CreateMap<ActionTaken, ActionTaken>();
            CreateMap<ActionTaken, ActionTakenDto>();
        }
    }
}
