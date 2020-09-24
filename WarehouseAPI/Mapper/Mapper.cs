using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using D = WarehouseAPI_DAL.Models;
using A = WarehouseAPI.Models;
using System.Data;

namespace WarehouseAPI.Mapper
{
    public static class Mapper
    {
        public static A.Categorie ToCategorie_API(this D.Categorie a)
        {
            if (a == null) return null;
            return new A.Categorie
            {
                CategorieId = a.CategorieId,
                Nom = a.Nom
            };
        }
        
        public static A.CategorieFournisseur ToCategorieFournisseur_API(this D.CategorieFournisseur a)
        {
            if (a == null) return null;
            return new A.CategorieFournisseur
            {
                CategorieId = a.CategorieId,
                FournisseurId = a.FournisseurId,
                CategorieNom = a.CategorieNom
            };
        }

        public static A.Article ToArticle_API(this D.Article a)
        {
            if (a == null) return null;
            return new A.Article
            {
                ArticleId = a.ArticleId,
                Nom = a.Nom,
                PrixAchat = a.PrixAchat,
                PrixVente = a.PrixVente,
                CategorieId = a.CategorieId,
                CategorieNom = a.CategorieNom,
            };
        }
        public static A.Fournisseur ToFournisseur_API(this D.Fournisseur a)
        {
            if (a == null) return null;
            return new A.Fournisseur
            {
                FournisseurId = a.FournisseurId,
                Nom = a.Nom,
                NumTva = a.NumTva,
                Email = a.Email,
                NumTel = a.NumTel,
                Rue = a.Rue,
                Numero = a.Numero,
                CodePostal = a.CodePostal,
                Ville = a.Ville,
                Pays = a.Pays,
            };
        }
        public static A.Client ToClient_API(this D.Client a)
        {
            if (a == null) return null;
            return new A.Client
            {
                ClientId = a.ClientId,
                Nom = a.Nom,
                Prenom = a.Prenom,
                NomSociete = a.NomSociete,
                NumTva = a.NumTva,
                Email = a.Email,
                NumTel = a.NumTel,
                Rue = a.Rue,
                Numero = a.Numero,
                CodePostal = a.CodePostal,
                Ville = a.Ville,
                Pays = a.Pays,
            };
        }
        public static A.Reception ToReception_API(this D.Reception a)
        {
            if (a == null) return null;
            return new A.Reception
            {
                ReceptionId = a.ReceptionId,
                ArticleId = a.ArticleId,
                FournisseurId = a.FournisseurId,
                ArticleNom = a.ArticleNom,
                UtilisateurId = a.UtilisateurId,
                CategorieNom = a.CategorieNom,
                CategorieId = a.CategorieId,
                Quantite = a.Quantite,
                Date = a.Date,
                FournisseurNom = a.FournisseurNom,
                FournisseurPays = a.FournisseurPays,
                FournisseurVille = a.FournisseurVille,
                UtilisateurNom = a.UtilisateurNom,
                FournisseurRue = a.FournisseurRue,
                FournisseurNumTva = a.FournisseurNumTva,
                FournisseurNumero = a.FournisseurNumero,
                FournisseurCodePostal = a.FournisseurCodePostal,
                UtilisateurPrenom = a.UtilisateurPrenom
            };
        }
        public static A.Stock ToStock_API(this D.Stock a)
        {
            if (a == null) return null;
            return new A.Stock
            {
                StockId = a.StockId,
                FournisseurId = a.FournisseurId,
                ArticleId = a.ArticleId,
                ArticleNom = a.ArticleNom,
                UtilisateurId = a.UtilisateurId,
                FournisseurNom = a.FournisseurNom,
                UtilisateurNom = a.UtilisateurNom,
                Quantite = a.Quantite,
                TotalStock = a.TotalStock,
                Date = a.Date,
                Activite = a.Activite 
            };
        }
        public static A.Utilisateur ToUtilisateur_API(this D.Utilisateur a)
        {
            if (a == null) return null;
            return new A.Utilisateur
            {
                UtilisateurId = a.UtilisateurId,
                Nom = a.Nom,
                Prenom = a.Prenom,
                Email = a.Email,
                NumTel = a.NumTel,
                Rue = a.Rue,
                Numero = a.Numero,
                CodePostal = a.CodePostal,
                Ville = a.Ville,
                Pays = a.Pays,
                Login = a.Login,
                Password = a.Password,
                Role = a.Role
            };
        }
        public static A.Expedition ToExpedition_API(this D.Expedition a)
        {
            if (a == null) return null;
            return new A.Expedition
            {
                ClientVille = a.ClientVille,
                UtilisateurNom = a.UtilisateurNom,
                UtilisateurPrenom = a.UtilisateurPrenom,
                ClientRue = a.ClientRue,
                ClientPays = a.ClientPays,
                ArticleId = a.ArticleId,
                ArticleNom = a.ArticleNom,
                CategorieNom = a.CategorieNom,
                CategorieId = a.CategorieId,
                ClientId = a.ClientId,
                ClientNom = a.ClientNom,
                ClientNumTel = a.ClientNumTel,
                ClientPrenom = a.ClientPrenom,
                ClientCodePostal = a.ClientCodePostal,
                ClientNomSociete = a.ClientNomSociete,
                ClientNumero = a.ClientNumero,
                ClientNumTva = a.ClientNumTva,
                Quantite = a.Quantite,
                UtilisateurId = a.UtilisateurId,
                Date = a.Date,
                ExpeditionId = a.ExpeditionId
            };
        }
    }
}