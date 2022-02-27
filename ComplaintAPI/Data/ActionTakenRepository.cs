using ComplaintService.Data.Interfaces;
using ComplaintService.Entities;
using ComplaintService.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintService.Data
{
    /// <summary>
    /// Repozitorijum za radnju na osnovu žalbe
    /// </summary>
    public class ActionTakenRepository : IActionTakenRepository
    {
        private readonly ComplaintContext context;
        
        /// <summary>
        /// Kontruktor repozitorijuma radnje na osnovu žalbe
        /// </summary>
        /// <param name="context">Db context</param>
        public ActionTakenRepository(ComplaintContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Dobijanje liste svih radnji na osnovu žalbe
        /// </summary>
        /// <param name="actionTaken">Naziv radnje na osnovu žalbe</param>
        /// <returns>Listu radnji na osnovu žalbe</returns>
        public List<ActionTaken> GetAllActionTaken(string actionTaken = null)
        {
            return context.ActionTaken
                .Where(at => (actionTaken == null || at.actionTaken == actionTaken))
                .ToList();
        }

        /// <summary>
        /// Dobijanje radnje na osnovu žalbe sa prosleđenim ID-jem
        /// </summary>
        /// <param name="actionTakenId">ID radnje na osnovu žalbe</param>
        /// <returns>Objekat radnje na osnovu žalbe</returns>
        public ActionTaken GetActionTakenById(Guid actionTakenId)
        {
            return context.ActionTaken.FirstOrDefault(at => at.actionTakenId == actionTakenId);
        }

        /// <summary>
        /// Kreiranje radnje na osnovu žalbe
        /// </summary>
        /// <param name="actionTaken">Objekat ranje na osnovu žalbe</param>
        /// <returns>Objekat potvrde kreirane radnje</returns>
        public ActionTaken CreateActionTaken(ActionTaken actionTaken)
        {
            context.ActionTaken.Add(actionTaken);
            context.SaveChanges();

            return actionTaken;
        }

        /// <summary>
        /// Izmena radnje na osnovu žalbe
        /// </summary>
        /// <param name="actionTaken">Objekat radnje na osnovu žalbe</param>
        public void UpdateActionTaken(ActionTaken actionTaken)
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Brisanje radnje na osnovu žalbe
        /// </summary>
        /// <param name="actionTakenId">ID radnje za brisanje</param>
        public void deleteActionTaken(Guid actionTakenId)
        {
            var actionTakenToDelete = GetActionTakenById(actionTakenId);

            context.ActionTaken.Remove(actionTakenToDelete);
            context.SaveChanges();
        }

        /// <summary>
        /// Validacija radnje na osnovu žalbe
        /// </summary>
        /// <param name="actionTaken">Naziv ranje na osnovu žalbe</param>
        /// <returns>
        /// true - radnja se ne nalazi u bazi, unos je validan
        /// false - radnja se već nalazi u bazi, unos nije validan
        /// </returns>
        public bool isValidActionTaken(string actionTaken)
        {
            var actionTakenList = context.ActionTaken
                .Where(at => at.actionTaken == actionTaken)
                .ToList();

            return actionTakenList.Count == 0;
        }

    }
}
