using AuctionAPI.Entities;
using AuctionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionAPI.Data
{
    /// <summary>
    /// Interfejs za kreiranje repozitorijuma licitacija
    /// </summary>
    public interface IAuctionRepository
    {
        /// <summary>
        /// Dobijannje podataka o svim licitacijama
        /// </summary>
        /// <returns>Listu svih lictacija</returns>
        List<Auction> GetAuctions();

        /// <summary>
        /// Kreiranje licitacije
        /// </summary>
        /// <param name="auctionCreation">Objekat kreiranja licitacije</param>
        /// <returns>Potvrdu kreirane licitacije</returns>
        AuctionConfirmation CreateAuction(CreationAuctionDto auctionCreation);

        /// <summary>
        /// Dobijanje licitacije na osnovu prosleđenog ID-ja
        /// </summary>
        /// <param name="auctionId">ID licitacije</param>
        /// <returns>Objekat licitacije</returns>
        Auction GetAuctionById(Guid auctionId);

        /// <summary>
        /// Dobijanje licitacije na osnovu prosleđenog broja licitacije
        /// </summary>
        /// <param name="auctionNumber">Broj licitacije</param>
        /// <returns>Objekat licitacije</returns>
        Auction GetAuctionByNumber(int auctionNumber);

        /// <summary>
        /// Izmena licitacije
        /// </summary>
        /// <param name="auction">Objekat izmene lictacije</param>
        void UpdateAuction(AuctionUpdateDto auction);

        /// <summary>
        /// Brisanje lictacije
        /// </summary>
        /// <param name="auctionId">ID lictacije za brisanje</param>
        void DeleteAuction(Guid auctionId);

        /// <summary>
        /// Čuvanje promena
        /// </summary>
        void SaveChanges();
    }
}
