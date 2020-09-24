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
    public class ArticleRepository : BasicRepository, IArticleRepository<int, Article>
    {
        public bool Delete(int id)
        {
            Command command = new Command("Delete FROM Article WHERE ArticleId = @ArticleId");
            command.AddParameter("ArticleId", id);
            _connection.ExecuteNonQuery(command);
            return true;
        }

        public IEnumerable<Article> Get()
        {
            Command command = new Command("GetArticleFull", true);
            return _connection.ExecuteReader(command, (reader) => reader.ToArticle_DAL());
        }

        public Article Get(int id)
        {
            Command command = new Command("GetArticleFull_By_Id", true);
            command.AddParameter("ArticleId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToArticle_DAL()).SingleOrDefault();
        }

        public int Insert(Article entity)
        {
            Command command = new Command("InsertArticle", true);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("PrixAchat", entity.PrixAchat);
            command.AddParameter("PrixVente", entity.PrixVente);
            command.AddParameter("CategorieId", entity.CategorieId);
            return _connection.ExecuteNonQuery(command);

        }

        public int Update(int id, Article entity)
        {
            
            Command command = new Command("UpdateArticle", true);
            command.AddParameter("ArticleId", id);
            command.AddParameter("Nom", entity.Nom);
            command.AddParameter("PrixAchat", entity.PrixAchat);
            command.AddParameter("PrixVente", entity.PrixVente);
            command.AddParameter("CategorieId", entity.CategorieId);
            return _connection.ExecuteNonQuery(command);
        }
    }
}
