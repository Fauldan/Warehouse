﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseAPI.Models
{
    public class Reception
    {
        public int ReceptionId { get; set; }
        public string FournisseurNom { get; set; }
        public int FournisseurNumTva { get; set; }
        public string FournisseurRue { get; set; }
        public int FournisseurNumero { get; set; }
        public int FournisseurCodePostal { get; set; }
        public string FournisseurVille { get; set; }
        public string FournisseurPays { get; set; }
        public int FournisseurId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleNom { get; set; }
        public int UtilisateurId { get; set; }
        public string UtilisateurNom { get; set; }
        public string UtilisateurPrenom { get; set; }
        public int Quantite { get; set; }
        public DateTime Date { get; set; }
        public string CategorieNom { get; set; }
        public int CategorieId { get; set; }
    }
}