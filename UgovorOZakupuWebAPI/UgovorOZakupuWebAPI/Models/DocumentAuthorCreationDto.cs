﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Models
{
    public class DocumentAuthorCreationDto
    {
        public Guid DocumentAuthorId { get; set; }
        public string AgencyInfo { get; set; }
    }
}
