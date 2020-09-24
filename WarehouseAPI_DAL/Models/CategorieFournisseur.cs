using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI_DAL.Models
{
    public class CategorieFournisseur
    {
        public int CategorieId { get; set; }
        public int FournisseurId { get; set; }
        public string CategorieNom { get; set; }
    }
}
