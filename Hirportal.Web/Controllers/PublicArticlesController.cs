using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Bll.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hirportal.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class PublicArticlesController : ControllerBase
    {
        public readonly IPublicArticleService publicArticleService;
        public readonly IColumnService columnService;

        public PublicArticlesController(IPublicArticleService publicArticleService, IColumnService columnService)
        {
            this.publicArticleService = publicArticleService;
            this.columnService = columnService;
        }

        [HttpGet("articles/{id}")]
        /// <returns>ArcticleDisplayData-t ad vissza</returns>
        public async Task<ActionResult> Get(Guid id)
        {
            ArticleDisplayData article = await publicArticleService.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        //Todo: Configba visszaadott cikkek száma. 
        //Todo: lapozás? 
        [HttpPost("articles/find")]
        public async Task<ActionResult> Find([FromBody] ArticleFilterData filter)
        {
            IEnumerable<ArticleHeaderData> article = await publicArticleService.FindAsync(filter);
            return Ok(article);
        }

        //Todo: Configba visszaadott cikkek száma. 
        //Todo: lapozás? 
        /// <summary>
        ///Egy rovat cikkeit adja vissz
        /// </summary>   
        [HttpGet("column/{columnName}")]        
        public async Task<ActionResult> Column([FromRoute] string columnName)
        {
            IEnumerable<ArticleHeaderData> article = await publicArticleService.GetByColumn(columnName);
            return Ok(article);
        }       

        [HttpGet("mainpage")]
        public async Task<ActionResult> MainPage()
        {
            var mainPageData = await publicArticleService.GetMainPage();
            return Ok(mainPageData);
        }
    }
}