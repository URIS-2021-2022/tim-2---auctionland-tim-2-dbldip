﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaWebAPI.Models.ParcelUserDtos
{
    public class ParcelUserCreationDto
    {


        public string name { get; set; }

        public string surname { get; set; }


        public string jmbg { get; set; }

        public string address { get; set; }
    }
}
