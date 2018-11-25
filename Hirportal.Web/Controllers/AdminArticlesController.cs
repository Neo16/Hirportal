using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.Dtos.MainPage;
using Hirportal.Bll.Exceptions;
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
        public async Task<IActionResult> CreateArticle([FromBody] ArticleEditCreateData article)
        {            
            if (article != null && ModelState.IsValid)
            {
                article.AuthorId = (await currentUserService.GetCurrentUser()).Id;
                await adminArticleService.Create(article);
                return Ok();
            }
            throw new BusinessLogicException("Validációs hiba") { ErrorCode = ErrorCode.InvalidArgument };               
        
        }

        [HttpPost]
        [Route("update-article/{articleId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateArticle(Guid articleId, [FromBody] ArticleEditCreateData article)
        {
            if (article != null && ModelState.IsValid)
            {
                article.AuthorId = (await currentUserService.GetCurrentUser()).Id;
                await adminArticleService.Update(articleId, article);
                return Ok();
            }

            throw new BusinessLogicException("Validációs hiba") { ErrorCode = ErrorCode.InvalidArgument };
        }

        [HttpDelete]
        [Route("delete-article")]    
        public async Task<IActionResult> DeleteArticle(Guid articleId)
        {           
            await adminArticleService.Delete(articleId);
            return Ok(articleId);
        }

        [HttpGet("articles/{id}")]      
        public async Task<ActionResult> Get(Guid id)
        {
            ArticleEditCreateData article = await adminArticleService.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpGet("all-articles")]       
        public async Task<ActionResult> GetAll()
        {
            IEnumerable<ArticleHeaderData> articles = await adminArticleService.GetAll();           
            return Ok(articles);
        }

        [HttpPost("update-mainpage")]      
        public async Task<ActionResult> UpdateMainPage(MainPageData data)
        {
            if (data != null && data.Blocks!= null)
            {
                await adminArticleService.UpdateMainPage(data);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
           
        }
    }
}