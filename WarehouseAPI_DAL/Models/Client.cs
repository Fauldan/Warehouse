﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WarehouseAPI_DAL.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomSociete { get; set; }
        public int NumTva { get; set; }
        public string Email { get; set; }
        public string NumTel { get; set; }
        public string Rue { get; set; }
        public int Numero { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
    }
}
