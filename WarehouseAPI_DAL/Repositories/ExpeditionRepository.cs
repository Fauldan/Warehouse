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
    public class ExpeditionRepository : BasicRepository, IExpeditionRepository<int, Expedition>
    {
        public bool Delete(int id)
        {
            Command command = new Command("Delete FROM Expedition WHERE ExpeditionId = @ExpeditionId");
            command.AddParameter("ExpeditionId", id);
            _connection.ExecuteNonQuery(command);
            return true;
        }

        public IEnumerable<Expedition> Get()
        {
            Command command = new Command("GetExpeditionFull", true);
            return _connection.ExecuteReader(command, (reader) => reader.ToExpedition_DAL());
        }

        public Expedition Get(int id)
        {
            Command command = new Command("GetExpeditionFull_By_Id", true);
            command.AddParameter("ExpeditionId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToExpedition_DAL()).SingleOrDefault();
        }

        public int Insert(Expedition entity)
        {
            Command command = new Command("InsertExpedition", true);
            command.AddParameter("ClientId", entity.ClientId);
            command.AddParameter("ArticleId", entity.ArticleId);
            command.AddParameter("UtilisateurId", entity.UtilisateurId);
            command.AddParameter("Quantite", entity.Quantite);
            return _connection.ExecuteNonQuery(command);
        }

        public int Update(int id, Expedition entity)
        {
            Command command = new Command("UpdateExpedition", true);
            command.AddParameter("ExpeditionId", entity.ExpeditionId);
            command.AddParameter("ClientId", entity.ClientId);
            command.AddParameter("ArticleId", entity.ArticleId);
            command.AddParameter("Quantite", entity.Quantite);
            return _connection.ExecuteNonQuery(command);
        }

        public int Confirmer(Expedition entity)
        {
            Command command = new Command("InsertConfirmedExpedition", true);
            command.AddParameter("ClientNom", entity.ClientNom);            
            command.AddParameter("ClientPrenom", entity.ClientPrenom);
            command.AddParameter("ClientNumTva", entity.ClientNumTva);
            command.AddParameter("ClientNomSociete", entity.ClientNomSociete);
            command.AddParameter("ClientRue", entity.ClientRue);
            command.AddParameter("ClientNumero", entity.ClientNumero);           
            command.AddParameter("ClientCodePostal", entity.ClientCodePostal);
            command.AddParameter("ClientVille", entity.ClientVille);
            command.AddParameter("ClientPays", entity.ClientPays);
            command.AddParameter("ExpeditionId", entity.ExpeditionId);
            command.AddParameter("ArticleId", entity.ArticleId);
            command.AddParameter("ArticleNom", entity.ArticleNom);
            command.AddParameter("UtilisateurId", entity.UtilisateurId);
            command.AddParameter("UtilisateurNom", entity.UtilisateurNom);
            command.AddParameter("CategorieNom", (entity.CategorieNom));
            command.AddParameter("CategorieId", (entity.CategorieId));
            command.AddParameter("Quantite", entity.Quantite);
            command.AddParameter("Date", DateTime.Now);
            return _connection.ExecuteNonQuery(command);
        }
    }
}
