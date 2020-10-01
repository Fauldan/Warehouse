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
    public class StockRepository : BasicRepository, IStockRepository<int, Stock>
    {    
        public bool Delete(int id)
        {
            Command command = new Command("Delete FROM BonReception WHERE ReceptionId = @ReceptionId");
            command.AddParameter("ReceptionId", id);
            _connection.ExecuteNonQuery(command);
            return true;
        }

        public IEnumerable<Stock> Get()
        {
            Command command = new Command("GetMoveStock", true);
            return _connection.ExecuteReader(command, (reader) => reader.ToStock_DAL());
        }

        public Stock Get(int id)
        {
            Command command = new Command("GetMoveStock_By_Id", true);
            command.AddParameter("StockId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToStock_DAL()).SingleOrDefault();
        }

        public Stock GetStockArticle(int id)
        {
            Command command = new Command("GetStockArticle", true);
            command.AddParameter("ArticleId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToStock_DAL()).SingleOrDefault();
        }

        public IEnumerable<Stock> GetMoveStock_By_ArticleId (int id)
        {
            Command command = new Command("GetMoveStock_By_ArticleId", true);
            command.AddParameter("ArticleId", id);
            return _connection.ExecuteReader(command, (reader) => reader.ToStock_DAL());
        }        
        
        public IEnumerable<Stock> GetStockInventaire ()
        {
            Command command = new Command("GetStockInventaire", true);
            return _connection.ExecuteReader(command, (reader) => reader.ToStock_DAL());
        }

        public int Insert(Stock entity)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Stock entity)
        {
            throw new NotImplementedException(); 
        }
    }
}
