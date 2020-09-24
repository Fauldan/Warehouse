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
    public class CategorieRepository : BasicRepository, ICategorieRepository<int, Categorie>
    {
        public bool Delete(int id)
        {
            Command command = new Command("Delete FROM Categorie WHERE CategorieId = @CategorieId");
            command.AddParameter("CategorieId", id);
            _connection.ExecuteNonQuery(command);
            return true;
        }

        public IEnumerable<Categorie> Get()
        {
            Command command = new Command("SELECT CategorieId, Nom FROM Categorie");
            return _connection.ExecuteReader(command, (reader) => reader.ToCategorie_DAL());
        }

        public Categorie Get(int id)
        {
            Command command = new Command("SELECT CategorieId, Nom FROM Categorie WHERE CategorieId = @CategorieId");
            command.AddParameter("CategorieId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToCategorie_DAL()).SingleOrDefault();
        }
        public IEnumerable<Categorie> GetCategorie_NotIn_Fournisseur(int id)
        {
            Command command = new Command("GetCategorie_NotIn_Fournisseur", true);
            command.AddParameter("FournisseurId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToCategorie_DAL());
        }

        public IEnumerable<Categorie> GetCategorie_By_Fournisseur(int id)
        {
            Command command = new Command("GetCategorie_By_Fournisseur", true);
            command.AddParameter("FournisseurId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToCategorie_DAL());
        }

        public int Insert(Categorie entity)
        {
            Command command = new Command("INSERT INTO Categorie (Nom) VALUES (@Nom)");
            command.AddParameter("Nom", entity.Nom);
            return _connection.ExecuteNonQuery(command);
        }

        public int Update(int id, Categorie entity)
        {
            Command command = new Command("UPDATE Categorie SET Nom = @Nom WHERE CategorieId = @CategorieId");
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("CategorieId", entity.CategorieId);
            return _connection.ExecuteNonQuery(command);
        }
    }
}
