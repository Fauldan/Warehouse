using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseAPI.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public int FournisseurId { get; set; }
        public string FournisseurNom { get; set; }
        public int ArticleId { get; set; }
        public string ArticleNom { get; set; }
        public int UtilisateurId { get; set; }
        public string UtilisateurNom { get; set; }
        public int Quantite { get; set; }
        public int TotalStock { get; set; }
        public DateTime Date { get; set; }
        public string Activite { get; set; }
    }
}