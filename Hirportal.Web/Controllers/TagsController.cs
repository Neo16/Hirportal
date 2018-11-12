using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirportal.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        public readonly ITagService TagService;

        public TagsController(ITagService TagService)
        {           
            this.TagService = TagService;
        }

        /// <summary>
        /// Az összes rovat nevét adja vissza
        /// </summary>   
        [HttpGet("Tags")]
        public async Task<ActionResult> ListTags()
        {
            IEnumerable<TagData> tags = await TagService.Get();
            return Ok(tags);
        }
    }    
}