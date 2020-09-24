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
    public class ReceptionController : ApiController
    {
        IReceptionRepository<int, Reception> _receptionRepo = new ReceptionRepository();

        [Route("api/Reception")]
        [HttpGet]
        public IEnumerable<A.Reception> Get()
        {
            IEnumerable<A.Reception> listReceptions = _receptionRepo.Get().Select(a => a.ToReception_API());
            return listReceptions;
        }

        
        public A.Reception Get(int id)
        {
            A.Reception reception = _receptionRepo.Get(id).ToReception_API();
            return reception;           
        }

        [Route("api/Reception/Create")]
        [HttpPost]
        public int Create([FromBody] Reception form)
        {
            return _receptionRepo.Insert(form);
        }

        [HttpPut]
        public int Edit(int id, [FromBody] Reception form)
        {
            return _receptionRepo.Update(id, form);
        }

        [HttpPost]
        [Route("api/Reception/ConfirmReception")]
        public int ConfirmReception([FromBody] Reception form)
        {
            return _receptionRepo.Confirmer(form);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _receptionRepo.Delete(id);
        }
    }
}
