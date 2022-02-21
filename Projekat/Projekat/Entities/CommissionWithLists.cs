using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionWebAPI.Entities
{
    public class CommissionWithLists
    {
        public Guid CommissionId { get; set; }

        #region President
        public Guid PresidentId { get; set; }
        public Person President { get; set; }
        #endregion

        #region Members
         public List<Members> Members { get; set; }
        #endregion

        public bool IsDelete { get; set; }
    }
}
