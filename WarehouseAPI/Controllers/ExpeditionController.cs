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
    public class ExpeditionController : ApiController
    {
        IExpeditionRepository<int, Expedition> _expeditionRepo = new ExpeditionRepository();

        [Route("api/Expedition")]
        [HttpGet]
        public IEnumerable<A.Expedition> Get()
        {
            IEnumerable<A.Expedition> listExpeditions = _expeditionRepo.Get().Select(a => a.ToExpedition_API());
            return listExpeditions;
        }

        // GET: api/Expedition/5
        public A.Expedition Get(int id)
        {
            A.Expedition expedition = _expeditionRepo.Get(id).ToExpedition_API();
            return expedition;
        }

        [Route("api/Expedition/Create")]
        [HttpPost]
        public int Create([FromBody] Expedition form)
        {
            return _expeditionRepo.Insert(form);
        }

        [HttpPut]
        public int Edit(int id, [FromBody] Expedition form)
        {
            return _expeditionRepo.Update(id, form);
        }

        [HttpPost]
        [Route("api/Expedition/ConfirmExpedition")]
        public int ConfirmExpedition([FromBody] Expedition form)
        {
            return _expeditionRepo.Confirmer(form);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _expeditionRepo.Delete(id);
        }
    }
}
