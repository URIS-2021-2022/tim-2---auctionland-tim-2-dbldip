﻿using CommissionWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Models
{
    public class CommissionCreationDto 
    {
        public Guid CommissionId { get; set; }
        [Required]
        public Guid PresidentId { get; set; }

        public List<Guid> Members { get; set; }

    }
}
