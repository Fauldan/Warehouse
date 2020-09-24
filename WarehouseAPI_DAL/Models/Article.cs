using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI_DAL.Models;

namespace WarehouseAPI_DAL.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Nom { get; set; }
        public float PrixAchat { get; set; }
        public float PrixVente { get; set; }
        public int CategorieId { get; set; }
        public string CategorieNom { get; set; }
    }
}
