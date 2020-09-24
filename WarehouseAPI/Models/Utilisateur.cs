using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseAPI.Models
{
    public class Utilisateur
    {
        public int UtilisateurId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string NumTel { get; set; }
        public string Rue { get; set; }
        public int Numero { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
}