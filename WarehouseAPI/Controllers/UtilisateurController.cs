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
    public class UtilisateurController : ApiController
    {
        IUtilisateurRepository<int, Utilisateur> _utilisateurRepo = new UtilisateurRepository();

        // GET: api/Utilisateur
        public IEnumerable<A.Utilisateur> Get()
        {
            IEnumerable<A.Utilisateur> listUtilisateurs = _utilisateurRepo.Get().Select(a => a.ToUtilisateur_API());
            return listUtilisateurs;
        }

        // GET: api/Utilisateur/5
        public A.Utilisateur Get(int id)
        {
            A.Utilisateur utilisateur = _utilisateurRepo.Get(id).ToUtilisateur_API();
            return utilisateur;
        }

        // POST: api/Utilisateur
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Utilisateur/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Utilisateur/5
        public void Delete(int id)
        {
        }
    }
}
