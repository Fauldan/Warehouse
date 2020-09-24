using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI_DAL.Repositories.IRepositories
{
    public interface IFournisseurRepository<TID, TEntity> : IRepository<TID, TEntity>
    {
        IEnumerable<TEntity> GetByArticle(TID id);
    }
}
