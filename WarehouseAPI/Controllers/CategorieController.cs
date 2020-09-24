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
    public class CategorieController : ApiController
    {
        ICategorieRepository<int, Categorie> _categorieRepo = new CategorieRepository();

        // GET: api/Categorie
        [HttpGet]
        public IEnumerable<A.Categorie> Get()
        {
            IEnumerable<A.Categorie> listCategories = _categorieRepo.Get().Select(a => a.ToCategorie_API());
            return listCategories;
        }

        // GET: api/Categorie/5
        public A.Categorie Get(int id)
        {
            A.Categorie categorie = _categorieRepo.Get(id).ToCategorie_API();
            return categorie;
        }

        // GET: api/Categorie/GetCategorie_NotIn_Fournisseur
        [HttpGet]
        [Route("api/Categorie/GetCategorie_NotIn_Fournisseur/{id}")]
        public IEnumerable<A.Categorie> GetCategorie_NotIN_Fournisseur(int id)
        {
            IEnumerable<A.Categorie> categorie = _categorieRepo.GetCategorie_NotIn_Fournisseur(id).Select(a => a.ToCategorie_API());

            return categorie;
        }

        // GET: api/Categorie/GetCategorie_By_Fournisseur
        [HttpGet]
        [Route("api/Categorie/GetCategorie_By_Fournisseur/{id}")]
        public IEnumerable<A.Categorie> GetCategorie_By_Fournisseur(int id)
        {
            IEnumerable<A.Categorie> categorie = _categorieRepo.GetCategorie_By_Fournisseur(id).Select(a => a.ToCategorie_API());

            return categorie;
        }

        // POST: api/Categorie
        [HttpPost]
        public int Create([FromBody] Categorie form)
        {
            return _categorieRepo.Insert(form);
        }

        // PUT: api/Categorie/5
        [HttpPut]
        public int Edit(int id, [FromBody] Categorie form)
        {
            return _categorieRepo.Update(id, form);
        }

        // DELETE: api/Categorie/5
        public void Delete(int id)
        {
            _categorieRepo.Delete(id);
        }
    }
}
