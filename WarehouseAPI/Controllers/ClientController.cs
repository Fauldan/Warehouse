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
    public class ClientController : ApiController
    {
        IClientRepository<int, Client> _clientRepo = new ClientRepository();

        // GET: api/Client
        [HttpGet]
        public IEnumerable<A.Client> Get()
        {
            IEnumerable<A.Client> listClients = _clientRepo.Get().Select(a => a.ToClient_API());
            return listClients;
        }

        // GET: api/Client/5
        public A.Client Get(int id)
        {
            A.Client client = _clientRepo.Get(id).ToClient_API();
            return client;
        }

        // POST: api/Client
        [HttpPost]
        public int Create([FromBody]Client form)
        {
            return _clientRepo.Insert(form);
        }

        // PUT: api/Client/5
        [HttpPut]
        public int Edit(int id, [FromBody]Client form)
        {
            return _clientRepo.Update(id, form);
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
            Client client = _clientRepo.Get(id);
            _clientRepo.Delete(id);
        }
    }
}