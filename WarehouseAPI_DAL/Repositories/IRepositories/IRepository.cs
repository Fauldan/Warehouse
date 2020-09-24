﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI_DAL.Repositories.IRepositories
{
    public interface IRepository<TId, TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(TId id);
        TId Insert(TEntity entity);
        int Update(TId id, TEntity entity);
        bool Delete(TId id);
    }
}
