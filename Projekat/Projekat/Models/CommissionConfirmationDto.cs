using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    public class CommissionConfirmationDto 
    {
        public string PresidentName { get; set; }
        public string PresidentSurname { get; set; }
    }
}
