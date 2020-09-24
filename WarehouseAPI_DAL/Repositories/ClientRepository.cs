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
    public class ClientRepository : BasicRepository, IClientRepository<int, Client>
    {     
        public bool Delete(int id)
        {
            Command command = new Command("Delete FROM Client WHERE ClientId = @ClientId");
            command.AddParameter("ClientId", id);
            _connection.ExecuteNonQuery(command);
            return true;
        }
        public IEnumerable<Client> Get()
        {
            Command command = new Command("GetClientFull", true);
            return _connection.ExecuteReader(command, (reader) => reader.ToClient_DAL());
        }

        public Client Get(int id)
        {
            Command command = new Command("GetClientFull_By_Id", true);
            command.AddParameter("ClientId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToClient_DAL()).SingleOrDefault();
        }

        public int Insert(Client entity)
        {
            Command command = new Command("InsertClient", true);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("Prenom", entity.Prenom);
            command.AddParameter("NomSociete", entity.NomSociete);
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

        public int Update(int id, Client entity)
        {
            Command command = new Command("UpdateClient", true);
            command.AddParameter("ClientId", id);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("Prenom", entity.Prenom);
            command.AddParameter("NomSociete", entity.NomSociete);
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
