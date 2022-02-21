﻿using CommissionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    public class Commission
    {

        public Guid CommissionId { get; set; }

        #region President
        [ForeignKey("President")]
        public Guid PresidentId { get; set; }
        public Person President { get; set; }
        #endregion

        public bool? IsDelete { get; set; }


        

    }
}
