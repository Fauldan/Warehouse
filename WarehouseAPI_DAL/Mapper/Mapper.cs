using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI_DAL.Models;

namespace WarehouseAPI_DAL.Mapper
{
    public static class Mapper
    {
        public static Article ToArticle_DAL(this IDataRecord Reader)
        {
            if (Reader is null) return null;
            return new Article
            {
                CategorieNom = (string)Reader[nameof(Article.CategorieNom)],
                ArticleId = (int)Reader[nameof(Article.ArticleId)],
                Nom = (string)Reader[nameof(Article.Nom)],
                PrixAchat = (float)Reader[nameof(Article.PrixAchat)],
                PrixVente = (float)Reader[nameof(Article.PrixVente)],
                CategorieId = (int)Reader[nameof(Article.CategorieId)],
            };
        }

        public static Categorie ToCategorie_DAL(this IDataRecord Reader)
        {
            if (Reader is null) return null;
            return new Categorie
            {
                CategorieId = (int)Reader[nameof(Categorie.CategorieId)],
                Nom = (string)Reader[nameof(Categorie.Nom)],
            };
        }
        
        public static CategorieFournisseur ToCategorieFournisseur_DAL(this IDataRecord Reader)
        {
            if (Reader is null) return null;
            return new CategorieFournisseur
            {
                CategorieId = (int)Reader[nameof(CategorieFournisseur.CategorieId)],
                CategorieNom = (string)Reader[nameof(CategorieFournisseur.CategorieNom)]
            };
        }

        public static Client ToClient_DAL(this IDataRecord Reader)
        {
            if (Reader is null) return null;
            return new Client
            {
                ClientId = (int)Reader[nameof(Client.ClientId)],
                Nom = (string)Reader[nameof(Client.Nom)],
                Prenom = (string)Reader[nameof(Client.Prenom)],
                NomSociete = (string)Reader[nameof(Client.NomSociete)],
                NumTva = (int)Reader[nameof(Client.NumTva)],
                Email = (string)Reader[nameof(Client.Email)],
                NumTel = (string)Reader[nameof(Client.NumTel)],
                Rue = (string)Reader[nameof(Client.Rue)],
                Numero = (int)Reader[nameof(Client.Numero)],
                CodePostal = (int)Reader[nameof(Client.CodePostal)],
                Ville = (string)Reader[nameof(Client.Ville)],
                Pays = (string)Reader[nameof(Client.Pays)],
            };
        }

        public static Expedition ToExpedition_DAL(this IDataRecord Reader)
        {
            if (Reader is null) return null;
            return new Expedition
            {

                ExpeditionId = (int)Reader[nameof(Expedition.ExpeditionId)],
                Date = (DateTime)Reader[nameof(Expedition.Date)],
                Quantite = (int)Reader[nameof(Expedition.Quantite)],
                UtilisateurNom = (string)Reader[nameof(Expedition.UtilisateurNom)],
                UtilisateurId = (int)Reader[nameof(Expedition.UtilisateurId)],
                ArticleId = (int)Reader[nameof(Expedition.ArticleId)],
                ClientId = (int)Reader[nameof(Expedition.ClientId)],
                ArticleNom = (string)Reader[nameof(Expedition.ArticleNom)],
                ClientNom = (string)Reader[nameof(Expedition.ClientNom)],
                ClientPrenom = (string)Reader[nameof(Expedition.ClientPrenom)],
                ClientNomSociete = (string)Reader[nameof(Expedition.ClientNomSociete)],
                ClientNumTva = (int)Reader[nameof(Expedition.ClientNumTva)],
                ClientNumTel = (string)Reader[nameof(Expedition.ClientNumTel)],
                ClientRue = (string)Reader[nameof(Expedition.ClientRue)],
                ClientNumero = (int)Reader[nameof(Expedition.ClientNumero)],
                ClientCodePostal = (int)Reader[nameof(Expedition.ClientCodePostal)],
                ClientVille = (string)Reader[nameof(Expedition.ClientVille)],
                ClientPays = (string)Reader[nameof(Expedition.ClientPays)],
                CategorieId = (int)Reader[nameof(Expedition.CategorieId)],
                CategorieNom = (string)Reader[nameof(Expedition.CategorieNom)]
            };
        }

        public static Fournisseur ToFournisseur_DAL(this IDataRecord Reader)
        {
            if (Reader is null) return null;
            return new Fournisseur
            {
                FournisseurId = (int)Reader[nameof(Fournisseur.FournisseurId)],
                Nom = (string)Reader[nameof(Fournisseur.Nom)],
                NumTva = (int?)Reader[nameof(Fournisseur.NumTva)],
                Email = (string)Reader[nameof(Fournisseur.Email)],
                NumTel = (string)Reader[nameof(Fournisseur.NumTel)],
                Rue = (string)Reader[nameof(Fournisseur.Rue)],
                Numero = (int?)Reader[nameof(Fournisseur.Numero)],
                CodePostal = (int)Reader[nameof(Fournisseur.CodePostal)],
                Ville = (string)Reader[nameof(Fournisseur.Ville)],
                Pays = (string)Reader[nameof(Fournisseur.Pays)],

            };
        }

        public static Reception ToReception_DAL(this IDataRecord Reader)
        {
            if (Reader is null) return null;
            return new Reception
            {
                ReceptionId = (int)Reader[nameof(Reception.ReceptionId)],
                Quantite = (int)Reader[nameof(Reception.Quantite)],
                UtilisateurId = (int)Reader[nameof(Reception.UtilisateurId)],
                ArticleId = (int)Reader[nameof(Reception.ArticleId)],
                Date = (DateTime)Reader[nameof(Reception.Date)],
                FournisseurId = (int)Reader[nameof(Reception.FournisseurId)],
                FournisseurNom = (string)Reader[nameof(Reception.FournisseurNom)],
                FournisseurVille = (string)Reader[nameof(Reception.FournisseurVille)],
                FournisseurPays = (string)Reader[nameof(Reception.FournisseurPays)],
                ArticleNom = (string)Reader[nameof(Reception.ArticleNom)],
                UtilisateurNom = (string)Reader[nameof(Reception.UtilisateurNom)],
                FournisseurCodePostal = (int)Reader[nameof(Reception.FournisseurCodePostal)],
                FournisseurNumero = (int)Reader[nameof(Reception.FournisseurNumero)],
                FournisseurNumTva = (int)Reader[nameof(Reception.FournisseurNumTva)],
                FournisseurRue = (string)Reader[nameof(Reception.FournisseurRue)],
                UtilisateurPrenom = (string)Reader[nameof(Reception.UtilisateurPrenom)],
                CategorieId = (int)Reader[nameof(Reception.CategorieId)],
                CategorieNom = (string)Reader[nameof(Reception.CategorieNom)]
            };
        }

        public static Stock ToStock_DAL(this IDataRecord Reader)
        {
            if (Reader is null) return null;
            return new Stock
            {
                StockId = (int)Reader[nameof(Stock.StockId)],
                Quantite = (int)Reader[nameof(Stock.Quantite)],
                UtilisateurId = (int)Reader[nameof(Stock.UtilisateurId)],
                UtilisateurNom = (string)Reader[nameof(Stock.UtilisateurNom)],
                ArticleId = (int)Reader[nameof(Stock.ArticleId)],
                ArticleNom = (string)Reader[nameof(Stock.ArticleNom)],
                TotalStock = (int)Reader[nameof(Stock.TotalStock)],
                Date = (DateTime)Reader[nameof(Stock.Date)],
                Activite = (string)Reader[nameof(Stock.Activite)]
            };
        }

        public static Utilisateur ToUtilisateur_DAL(this IDataRecord Reader)
        {
            if (Reader is null) return null;
            return new Utilisateur
            {
                UtilisateurId = (int)Reader["UtilisateurId"],
                Nom = (string)Reader["Nom"],
                Prenom = (string)Reader["Prenom"],
                Email = (string)Reader["Email"],
                Login = (string)Reader["Login"],
                CodePostal = (int)Reader["CodePostal"],
                Rue = (string)Reader["Rue"],
                Numero = (int)Reader["Numero"],
                Ville = (string)Reader["Ville"],
                Pays = (string)Reader["Pays"],
                NumTel = (string)Reader["NumTel"],
                Role = (string)Reader["Role"],
                Password = "******",


            };
        }
    }
}
