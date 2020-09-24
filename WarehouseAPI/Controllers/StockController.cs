using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WarehouseAPI_DAL.Models;
using WarehouseAPI_DAL.Repositories;
using WarehouseAPI_DAL.Repositories.IRepositories;
using A = WarehouseAPI.Models;
using WarehouseAPI.Mapper;

namespace WarehouseAPI.Controllers
{
    public class StockController : ApiController
    {
        IStockRepository<int, Stock> _stockRepo = new StockRepository();

        [HttpGet]
        [Route("api/Stock/Get")]
        public IEnumerable<A.Stock> Get()
        {
            IEnumerable<A.Stock> listMoveStock = _stockRepo.Get().Select(a => a.ToStock_API());
            return listMoveStock;
        }

        [HttpGet]
        [Route("api/Stock/Get/{id}")]
        public A.Stock Get(int id)
        {
            A.Stock moveStock = _stockRepo.Get(id).ToStock_API();
            return moveStock;
        }

        [HttpGet]
        [Route("api/Stock/GetStockArticle/{id}")]
        public A.Stock GetStockArticle(int id)
        {
            return _stockRepo.GetStockArticle(id).ToStock_API();
        }
        
        [HttpGet]
        [Route("api/Stock/GetMoveStock_By_ArticleId/{id}")]
        public IEnumerable<A.Stock> GetMoveStock_By_ArticleId(int id)
        {
            IEnumerable<A.Stock> listMoveStock = _stockRepo.GetMoveStock_By_ArticleId(id).Select(a => a.ToStock_API());
            return listMoveStock;
        }

        [HttpPut]
        public int Edit(int id, [FromBody] Stock form)
        {
            return _stockRepo.Update(id, form);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _stockRepo.Delete(id);
        }
    }
}
