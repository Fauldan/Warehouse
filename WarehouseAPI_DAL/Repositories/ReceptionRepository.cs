using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;
using WarehouseAPI_DAL.Mapper;
using WarehouseAPI_DAL.Models;
using WarehouseAPI_DAL.Repositories.IRepositories;

namespace WarehouseAPI_DAL.Repositories
{
    public class ReceptionRepository : BasicRepository, IReceptionRepository<int, Reception>
    {
        public bool Delete(int id)
        {
            Command command = new Command("Delete FROM Reception WHERE ReceptionId = @ReceptionId");
            command.AddParameter("ReceptionId", id);
            _connection.ExecuteNonQuery(command);
            return true;
        }

        public IEnumerable<Reception> Get()
        {
            Command command = new Command("GetReceptionFull", true);
            return _connection.ExecuteReader(command, (reader) => reader.ToReception_DAL());
        }

        public Reception Get(int id)
        {
            Command command = new Command("GetReceptionFull_By_Id", true);
            command.AddParameter("ReceptionId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToReception_DAL()).SingleOrDefault();
        }

        public int Insert(Reception entity)
        {
            Command command = new Command("InsertReception", true);
            command.AddParameter("FournisseurId", entity.FournisseurId);
            command.AddParameter("ArticleId", entity.ArticleId);
            command.AddParameter("UtilisateurId", entity.UtilisateurId);
            command.AddParameter("Quantite", entity.Quantite);
            return _connection.ExecuteNonQuery(command);
        }

        public int Update(int id, Reception entity)
        {
            Command command = new Command("UpdateReception", true);
            command.AddParameter("ReceptionId", entity.ReceptionId);
            command.AddParameter("FournisseurId", entity.FournisseurId);
            command.AddParameter("ArticleId", entity.ArticleId);
            command.AddParameter("Quantite", entity.Quantite);
            return _connection.ExecuteNonQuery(command);
        }

        public int Confirmer(Reception entity)
        {
            Command command = new Command("InsertConfirmedReception", true);
            command.AddParameter("FournisseurNom", entity.FournisseurNom);
            command.AddParameter("FournisseurTva", entity.FournisseurNumTva);
            command.AddParameter("FournisseurRue", entity.FournisseurRue);
            command.AddParameter("FournisseurNumero", entity.FournisseurNumero);
            command.AddParameter("FournisseurCodePostal", entity.FournisseurCodePostal);
            command.AddParameter("FournisseurVille", entity.FournisseurVille);
            command.AddParameter("FournisseurPays", entity.FournisseurPays);
            command.AddParameter("ReceptionId", entity.ReceptionId);
            command.AddParameter("ArticleId", entity.ArticleId);
            command.AddParameter("ArticleNom", entity.ArticleNom);
            command.AddParameter("UtilisateurId", entity.UtilisateurId);
            command.AddParameter("UtilisateurNom", (entity.UtilisateurNom) + (entity.UtilisateurPrenom));
            command.AddParameter("CategorieNom", (entity.CategorieNom));
            command.AddParameter("CategorieId", (entity.CategorieId));
            command.AddParameter("Quantite", entity.Quantite);
            command.AddParameter("Date", DateTime.Now);
            return _connection.ExecuteNonQuery(command);
        }
    }
}
