using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI_DAL.Repositories.IRepositories
{
    public interface IClientRepository<TID, TEntity> : IRepository<TID, TEntity>
    {
    }
}
