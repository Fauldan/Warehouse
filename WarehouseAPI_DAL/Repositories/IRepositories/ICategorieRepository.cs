using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI_DAL.Repositories.IRepositories
{
    public interface ICategorieRepository<TID, TEntity> : IRepository<TID, TEntity>
    {
        IEnumerable<TEntity> GetCategorie_By_Fournisseur(TID id);
        IEnumerable<TEntity> GetCategorie_NotIn_Fournisseur(TID id);
    }
}
