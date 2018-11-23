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
    [Route("api/admin")]
    [ApiController]
    public class AdminTagsController : ControllerBase
    {
        public readonly IAdminTagService TagService;

        public AdminTagsController(IAdminTagService TagService)
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

        [HttpPost]
        [Route("create-tag")]
        public async Task<IActionResult> CreateTag([FromBody] TagData tag)
        {
            Guid createdTagId = await TagService.Create(tag);
            return Ok(createdTagId);
        }

        [HttpDelete]
        [Route("delete-tag")]
        public async Task<IActionResult> DeleteTag(Guid tagId)
        {
            await TagService.Delete(tagId);
            return Ok(tagId);
        }

        [HttpPut]
        [Route("update-tag")]
        public async Task<IActionResult> UpdateTag([FromBody] TagData tag)
        {
            await TagService.Update(tag);
            return Ok(tag);
        }
    }    
}