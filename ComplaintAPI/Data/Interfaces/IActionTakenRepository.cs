using ComplaintService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Data.Interfaces
{
    /// <summary>
    /// Interfejs za kreiranje repozitorijuma za preuzetu radnju na osnovu žalbe
    /// </summary>
    interface IActionTakenRepository
    {
        /// <summary>
        /// Prikaz liste svih radnji na osnovu žalbe
        /// </summary>
        /// <param name="actionTaken"></param>
        /// <returns></returns>
        public List<ActionTaken> GetAllActionTaken(string actionTaken = null);

        /// <summary>
        /// Prikaz radnje sa prosleđenim ID-jem
        /// </summary>
        /// <param name="actionTakenId">ID radnje</param>
        /// <returns>Objekat radnje na osnovu žalbe</returns>
        public ActionTaken GetActionTakenById(Guid actionTakenId);
        
        /// <summary>
        /// Kreiranje radnje na osnovu žalbe
        /// </summary>
        /// <param name="actionTaken">Objekat ranje na osnovu žalbe</param>
        public ActionTaken CreateActionTaken(ActionTaken actionTaken);

        /// <summary>
        /// Izmena radnje na osnovu žalbe
        /// </summary>
        /// <param name="actionTaken">Objekat radnje na osnovu žalbe</param>
        public void UpdateActionTaken(ActionTaken actionTaken);
        
        /// <summary>
        /// Brisanje radnje na osnovu žalbe
        /// </summary>
        /// <param name="actionTakenId">ID radnje</param>
        public void deleteActionTaken(Guid actionTakenId);

        /// <summary>
        /// Validacija za unos radnje na osnovu žalbe
        /// </summary>
        /// <param name="actionTaken">Id radnje na osnovu žalbe</param>
        /// <returns>
        /// true - radnja ne postoji u bazi
        /// false - radnja već postoji u bazi
        /// </returns>
        public bool isValidActionTaken(string actionTaken);
    }
}
