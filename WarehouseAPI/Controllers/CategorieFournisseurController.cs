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
    public class CategorieFournisseurController : ApiController
    {
        ICategorieFournisseurRepository<int, CategorieFournisseur> _categorieFournisseurRepo = new CategorieFournisseurRepository();

        // GET: api/CategorieFournisseur
        [HttpGet]
        [Route("api/CategorieFournisseur/Get")]
            public IEnumerable<A.CategorieFournisseur> Get()
        {
            IEnumerable <A.CategorieFournisseur> categorieFournisseurRepo = _categorieFournisseurRepo.Get().Select(a => a.ToCategorieFournisseur_API());
            return categorieFournisseurRepo;
        }

        // GET: api/CategorieFournisseur/5
        [Route("api/CategorieFournisseur/Get")]
        public A.CategorieFournisseur Get(int id)
        {
            A.CategorieFournisseur categorieFournisseur = _categorieFournisseurRepo.Get(id).ToCategorieFournisseur_API();
            return categorieFournisseur;
        }

        // POST: api/CategorieFournisseur
        public int Create([FromBody] CategorieFournisseur form)
        {
            return _categorieFournisseurRepo.Insert(form);
        }

        // PUT: api/CategorieFournisseur/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CategorieFournisseur/5
        public void Delete(int id)
        {
        }
    }
}
