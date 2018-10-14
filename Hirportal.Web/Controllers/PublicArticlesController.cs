using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hirportal.Web.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class PublicArticlesController : ControllerBase
    {
        public readonly IPublicArticleService publicArticleService;

        public PublicArticlesController(IPublicArticleService publicArticleService)
        {
            this.publicArticleService = publicArticleService;
        }

        [HttpGet("{id}")]
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

        [HttpPost("find")]
        public async Task<ActionResult> Find([FromBody] ArticleFilterData filter)
        {
            IEnumerable<ArticleHeaderData> article = await publicArticleService.FindAsync(filter);
            return Ok(article);
        }

        [HttpGet("column/{column}")]
        //Főoldal vagy másik rovat, max X darabot ad vissza, adott sorrendbe 
        public async Task<ActionResult> Column([FromRoute] string column)
        {
            IEnumerable<ArticleHeaderData> article = await publicArticleService.GetByColumn(column);
            return Ok(article);
        }
    }
}