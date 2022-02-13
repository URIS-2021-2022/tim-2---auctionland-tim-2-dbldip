﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class Priority
    {
        [Key]
        public Guid priorityID { get; set; }
        public string priorityDescription { get; set; }

    }
}
