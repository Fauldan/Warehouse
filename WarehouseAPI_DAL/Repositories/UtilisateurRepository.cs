using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;
using WarehouseAPI_DAL.Models;
using WarehouseAPI_DAL.Repositories.IRepositories;
using WarehouseAPI_DAL.Mapper;

namespace WarehouseAPI_DAL.Repositories
{
    public class UtilisateurRepository : BasicRepository, IUtilisateurRepository<int, Utilisateur>
    {
        public bool Delete(int id)
        {
            Command command = new Command("DELETE FROM Utilisateur WHERE UtilisateurId = @UtilisateurId");
            command.AddParameter("UtilisateurId", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Utilisateur> Get()
        {
            Command command = new Command("GetUtilisateurFull", true);
            return _connection.ExecuteReader(command, (reader) => reader.ToUtilisateur_DAL());
        }

        public Utilisateur Get(int id)
        {
            Command command = new Command("GetUtilisateurFull_By_Id", true);
            command.AddParameter("UtilisateurId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToUtilisateur_DAL()).Single();
        }

        public int Insert(Utilisateur entity)
        {
            Command command = new Command("InsertUtilisateur", true);
            command.AddParameter("UtilisateurId", entity.UtilisateurId);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("Prenom", entity.Prenom);
            command.AddParameter("Email", entity.Email);
            command.AddParameter("Numero", entity.Numero);
            command.AddParameter("NumTel", entity.NumTel);
            command.AddParameter("Rue", entity.Rue);
            command.AddParameter("CodePostal", entity.CodePostal);
            command.AddParameter("Ville", entity.Ville);
            command.AddParameter("Pays", entity.Pays);
            return _connection.ExecuteNonQuery(command);
        }

        public int Update(int id, Utilisateur entity)
        {
            throw new NotImplementedException();
        }
    }
}
