using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hirportal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicArticlesController : ControllerBase
    {
        public readonly IPublicArticleService publicArticleService;

        public PublicArticlesController(IPublicArticleService publicArticleService)
        {
            this.publicArticleService = publicArticleService;
        }

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

        public async Task<ActionResult> Find(ArticleFilterData filter)
        {
            IEnumerable<ArticleHeaderData> article = await publicArticleService.FindAsync(filter);       
            return Ok(article);
        }

        //Főoldal vagy másik rovat, max X darabot ad vissza, adott sorrendbe 
        public async Task<ActionResult> Column(string column)
        {
            IEnumerable<ArticleHeaderData> article = await publicArticleService.GetByColumn(column);
            return Ok(article);
        }
    }
}