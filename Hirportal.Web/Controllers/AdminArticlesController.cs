using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Web.WebServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hirportal.Web.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet]
        [Route("articles")]      
        public async Task<IActionResult> GetArticleList()
        {
            IEnumerable<ArticleAdminHeaderData> articles = await adminArticleService.Get();
            return Ok(articles);
        }

        [HttpPost]
        [Route("create-article")]        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleEditCreateData article)
        {
            //Todo validation 
            article.AuthorId = new Guid((await currentUserService.GetCurrentUser()).Id);
            await adminArticleService.Create(article);
            return Ok();
        }

        [HttpDelete]
        [Route("delete-article")]    
        public async Task<IActionResult> DeleteArticle(Guid articleId)
        {           
            await adminArticleService.Delete(articleId);
            return Ok(articleId);
        }
    }
}