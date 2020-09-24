using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WarehouseAPI_DAL.Models;
using WarehouseAPI_DAL.Repositories;
using WarehouseAPI_DAL.Repositories.IRepositories;

namespace WarehouseAPI.Controllers
{
    public class AuthController : ApiController
    {
        IAuthRepository<int, Utilisateur> _authRepo = new AuthRepository();
        
        [HttpPost]
        [Route("api/Auth/Login")]
        public Utilisateur Login([FromBody] Utilisateur form)
        {
            return _authRepo.Login(form);
        }

        [HttpPost]
        [Route("api/Auth/Register")]
        public int Register([FromBody] Utilisateur form)
        {
            return _authRepo.Register(form);
        }

    }
}
