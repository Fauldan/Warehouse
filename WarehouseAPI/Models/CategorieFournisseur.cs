using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseAPI.Models
{
    public class CategorieFournisseur
    {
        public int CategorieId { get; set; }
        public string CategorieNom { get; set; }
        public int FournisseurId { get; set; }
    }
}