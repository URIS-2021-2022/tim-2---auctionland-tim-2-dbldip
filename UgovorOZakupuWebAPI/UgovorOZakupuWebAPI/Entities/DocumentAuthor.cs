using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UgovorOZakupuWebAPI.Entities
{
    public class DocumentAuthor
    {
        public Guid DocumentAuthorId { get; set; }
        public string AgencyInfo { get; set; }
        //od korisnika sistema ime prezime
    }
}
