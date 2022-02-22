﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Models.ParcelPartDtos
{
    public class ParcelPartCreationDto
    {
        public int partSurfaceArea { get; set; }
        public int partParcelNumber { get; set; }
        public string partRealEstateListNumber { get; set; }
    }
}
