﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class GuaranteeType
    {
        public Guid GuaranteeTypeId { get; set; }
        
        public string Type { get; set; }
    }
}
