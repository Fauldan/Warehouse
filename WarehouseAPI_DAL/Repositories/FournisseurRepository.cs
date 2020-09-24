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
    public class FournisseurRepository : BasicRepository, IFournisseurRepository<int, Fournisseur>
    {
        public bool Delete(int id)
        {
            Command command = new Command("Delete FROM Fournisseur WHERE FournisseurId = @FournisseurId");
            command.AddParameter("FournisseurId", id);
            _connection.ExecuteNonQuery(command);
            return true;
        }

        public IEnumerable<Fournisseur> Get()
        {
            Command command = new Command("GetFournisseurFull", true);
            return _connection.ExecuteReader(command, (reader) => reader.ToFournisseur_DAL());
        }

        public Fournisseur Get(int id)
        {
            Command command = new Command("GetFournisseurFull_By_Id", true);
            command.AddParameter("FournisseurId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToFournisseur_DAL()).SingleOrDefault(); 
        }

        public IEnumerable<Fournisseur> GetByArticle(int articleId)
        {
            Command command = new Command("GetFournisseur_By_Article", true);
            command.AddParameter("ArticleId", articleId);
            return _connection.ExecuteReader(command, (reader) => reader.ToFournisseur_DAL());
        }

        public int Insert(Fournisseur entity)
        {
            Command command = new Command("InsertFournisseur", true);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("NumTva", entity.NumTva);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("NumTel", entity.NumTel);
            command.AddParameter("Rue", entity.Rue);
            command.AddParameter("Numero", entity.Numero);
            command.AddParameter("CodePostal", entity.CodePostal);
            command.AddParameter("Ville", entity.Ville);
            command.AddParameter("Pays", entity.Pays);
            return _connection.ExecuteNonQuery(command);
        }

        public int Update(int id, Fournisseur entity)
        {  
            Command command = new Command("UpdateFournisseur", true);
            command.AddParameter("FournisseurId", id);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("NumTva", entity.NumTva);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("NumTel", entity.NumTel);
            command.AddParameter("Rue", entity.Rue);
            command.AddParameter("Numero", entity.Numero);
            command.AddParameter("CodePostal", entity.CodePostal);
            command.AddParameter("Ville", entity.Ville);
            command.AddParameter("Pays", entity.Pays);
            return _connection.ExecuteNonQuery(command);
        }
    }
}
