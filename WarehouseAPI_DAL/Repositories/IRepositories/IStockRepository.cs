using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI_DAL.Repositories.IRepositories
{
    public interface IStockRepository<TID, TEntity> : IRepository<TID, TEntity>
    {
        TEntity GetStockArticle(TID id);
        IEnumerable<TEntity> GetMoveStock_By_ArticleId(TID id);
    }
}
