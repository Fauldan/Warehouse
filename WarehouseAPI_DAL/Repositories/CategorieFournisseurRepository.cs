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
    public class CategorieFournisseurRepository : BasicRepository, ICategorieFournisseurRepository<int, CategorieFournisseur>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategorieFournisseur> Get()
        {
            throw new NotImplementedException();
        }

        public CategorieFournisseur Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(CategorieFournisseur entity)
        {
                Command command = new Command("InsertCategorie_Fournisseur", true);
                command.AddParameter("CategorieId", entity.CategorieId);
                command.AddParameter("FournisseurId", entity.FournisseurId);
                return _connection.ExecuteNonQuery(command);
        }

        public int Update(int id, CategorieFournisseur entity)
        {
            throw new NotImplementedException();
        }
    }
}
