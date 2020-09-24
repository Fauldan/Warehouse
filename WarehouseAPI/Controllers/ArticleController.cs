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
    public class ArticleController : ApiController
    {
        IArticleRepository<int, Article> _articleRepo = new ArticleRepository();

        // GET: api/Article
        [HttpGet]
        public IEnumerable<A.Article> Get()
        {
            IEnumerable<A.Article> listArticles = _articleRepo.Get().Select(a => a.ToArticle_API());
            return listArticles;
        }

        // GET: api/Article/5
        public A.Article Get(int id)
        {
            A.Article article = _articleRepo.Get(id).ToArticle_API();
            return article;
        }

        [HttpPost]
        // POST: api/Article
        public int Create([FromBody] Article form)
        {
            return _articleRepo.Insert(form);
        }

        [HttpPut]
        // PUT: api/Article/Edit
        public int Edit(int id, [FromBody] Article form)
        {
            form.PrixAchat = (float) form.PrixAchat;
            return _articleRepo.Update(id, form);
        }

        // DELETE: api/Article/5
        public void Delete(int id)
        {
            _articleRepo.Delete(id);
        }
    }
}