using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Web.WebServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirportal.Web.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminArticlesController : Controller
    {
        private readonly CurrentUserService currentUserService;
        private readonly IAdminArticleService adminArticleService;

        public AdminArticlesController(
            CurrentUserService currentUserService,
            IAdminArticleService adminArticleService)
        {
            this.currentUserService = currentUserService;
            this.adminArticleService = adminArticleService;
        }

        [Route("authtest")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AuthTest()
        {
            var user = await currentUserService.GetCurrentUser();
            return Ok();
        }

        [Route("articles")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetArticleList()
        {
            IEnumerable<ArticleAdminHeaderData> articles = await adminArticleService.Get();
            return Ok(articles);
        }

        [Route("create-article")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleEditCreateData article)
        {
            //Todo validation 
            article.AuthorId = (await currentUserService.GetCurrentUser()).Id;
            await adminArticleService.Create(article);
            return Ok();
        }

        [HttpGet("articles/{id}")]
        /// <returns>ArcticleDisplayData-t ad vissza</returns>
        public async Task<ActionResult> Get(Guid id)
        {
            ArticleEditCreateData article = await adminArticleService.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }
    }
}