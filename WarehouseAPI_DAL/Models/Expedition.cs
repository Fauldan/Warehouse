using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI_DAL.Models
{
    public class Expedition
    {
        public int ExpeditionId { get; set; }
        public DateTime Date { get; set; }
        public int Quantite { get; set; }
        public int UtilisateurId { get; set; }
        public string UtilisateurNom { get; set; }
        public string UtilisateurPrenom { get; set; }
        public int ArticleId { get; set; }
        public string ArticleNom { get; set; }
        public string CategorieNom { get; set; }
        public int CategorieId { get; set; }
        public int ClientId { get; set; }
        public string ClientNom { get; set; }
        public string ClientPrenom { get; set; }
        public string ClientNomSociete { get; set; }
        public int ClientNumTva { get; set; }
        public string ClientRue { get; set; }
        public int ClientNumero { get; set; }
        public int ClientCodePostal { get; set; }
        public string ClientVille { get; set; }
        public string ClientPays { get; set; }
        public string ClientNumTel { get; set; }

    }
}
