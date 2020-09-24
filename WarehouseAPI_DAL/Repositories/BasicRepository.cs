using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;

namespace WarehouseAPI_DAL.Repositories
{
    public abstract class BasicRepository
    {
        protected Connection _connection;
        private ConnectionStringSettings ConnectionString { get { return ConfigurationManager.ConnectionStrings["LaboWarehouse"]; } }

        public BasicRepository()
        {
            _connection = new Connection(DbProviderFactories.GetFactory(ConnectionString.ProviderName), ConnectionString.ConnectionString);
        }
    }
}
