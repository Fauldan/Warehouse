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
    public class FournisseurController : ApiController
    {
        IFournisseurRepository<int, Fournisseur> _fournisseurRepo = new FournisseurRepository();

        // GET: api/Fournisseur
        [HttpGet]
        public IEnumerable<A.Fournisseur> Get()
        {
            IEnumerable<A.Fournisseur> listFournisseurs = _fournisseurRepo.Get().Select(a => a.ToFournisseur_API());
            return listFournisseurs;
        }

        //// GET: api/Fournisseur/5      
        [HttpGet]
        public A.Fournisseur Get(int id)
        {
            A.Fournisseur fournisseur = _fournisseurRepo.Get(id).ToFournisseur_API();
            return fournisseur;
        }

        //GET: api/Fournisseur/GetByArticle

        [HttpGet]
        [Route("api/Fournisseur/GetByArticle/{id}")]
        public IEnumerable<A.Fournisseur> GetByArticle(int id)
        {
            IEnumerable<A.Fournisseur> listFournisseurByArticle = _fournisseurRepo.GetByArticle(id).Select(a => a.ToFournisseur_API());
            return listFournisseurByArticle;
        }

        // POST: api/Fournisseur
        [HttpPost]
        public int Create([FromBody] Fournisseur form)
        {
            return _fournisseurRepo.Insert(form);
        }

        // PUT: api/Fournisseur/5
        [HttpPut]
        public int Edit(int id, [FromBody] Fournisseur form)
        {
            return _fournisseurRepo.Update(id, form);
        }

        // DELETE: api/Fournisseur/5
        public void Delete(int id)
        {
            _fournisseurRepo.Delete(id);
        }
    }
}