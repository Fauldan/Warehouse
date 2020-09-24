using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseAPI.Models
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