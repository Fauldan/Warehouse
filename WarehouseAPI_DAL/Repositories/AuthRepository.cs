using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;
using WarehouseAPI_DAL.Mapper;
using WarehouseAPI_DAL.Models;
using WarehouseAPI_DAL.Repositories.IRepositories;

namespace WarehouseAPI_DAL.Repositories
{
    public class AuthRepository : BasicRepository, IAuthRepository<int, Utilisateur>
    {       
        public Utilisateur Login(Utilisateur form)
        {
                Command command = new Command("CheckUser", true);
                command.AddParameter("Login", form.Login);
                command.AddParameter("Password", form.Password);

                Utilisateur utilisateur = _connection.ExecuteReader(command, (reader) => reader.ToUtilisateur_DAL()).SingleOrDefault();


            return utilisateur;
        }
        public int Register(Utilisateur form)
        {          
            try
            {
                Command command = new Command("RegisterUser", true);
                command.AddParameter("Nom", form.Nom);
                command.AddParameter("Prenom", form.Prenom);
                command.AddParameter("Email", form.Email);
                command.AddParameter("Login", form.Login);
                command.AddParameter("Password", form.Password);
                command.AddParameter("NumTel", form.NumTel);
                command.AddParameter("Rue", form.Rue);
                command.AddParameter("Numero", form.Numero);
                command.AddParameter("CodePostal", form.CodePostal);
                command.AddParameter("Ville", form.Ville);
                command.AddParameter("Pays", form.Pays);


                return _connection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Utilisateur> Get()
        {
            Command command = new Command("SELECT UtilisateurId, Nom, Prenom, Email, Numero, Role, Login, NumTel, Rue, CodePostal, Ville, Pays FROM Utilisateur");
            return _connection.ExecuteReader(command, (reader) => reader.ToUtilisateur_DAL());
        }

        public Utilisateur Get(int id)
        {
            Command command = new Command("SELECT UtilisateurId, Nom, Prenom, Email, Numero, Role, Login, NumTel, Rue, CodePostal, Ville, Pays FROM Utilisateur FROM Utilisateur WHERE UtilisateurId = @UtilisateurId");
            command.AddParameter("UtilisateurId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToUtilisateur_DAL()).SingleOrDefault();
        }
        public Utilisateur Get(string login, string password)
        {
            Command command = new Command("SELECT UtilisateurId, Nom, Prenom, Email, Numero, Role, Login, NumTel, Rue, CodePostal, Ville, Pays FROM Utilisateur WHERE Login = @Login");
            command.AddParameter("Login", login);
            return _connection.ExecuteReader(command, (reader) => reader.ToUtilisateur_DAL()).SingleOrDefault();
        }
    }
}
